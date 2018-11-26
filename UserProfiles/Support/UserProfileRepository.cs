using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UserProfiles.Model
{
   public class UserProfileRepository : IRepository
    {
        public string ConnectionString { get; } = Properties.Settings.Default["ConnectionString"].ToString();

        public List<UserLevelCategory> GetUserLevelCategories()
        {
            string queryUserLevelCategory = @"
SELECT 
	UserLevelCategoryId [Id], 
	ISNULL(UserLevelCategoryName,' ') [Name], 
	s.LocalSystemId [SystemId], 
	s.LocalSystemName [SystemName] 
FROM [dbo].[UserLevelCategory] c
	INNER JOIN [dbo].[LocalSystem] s ON s.LocalSystemId = c.UserLevelCategoryLocalSystemId AND s.LocalSystemName IS NOT NULL";

            var userLevelCategories = new List<UserLevelCategory>();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(queryUserLevelCategory, connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        userLevelCategories.Add(new UserLevelCategory { Id = (int)row["Id"], Name = row["Name"].ToString(), LocalSystemId = (int)row["SystemId"] });
                        //userLevelCategories.Add(new UserLevelCategory { Id = (int)row["Id"], Name = row["Name"].ToString(), System = new LocalSystem { Id = (int)row["SystemId"], Name = row["SystemName"].ToString() } });
                    }
                }
            }
            return userLevelCategories;
        }

        public UserProfile GetUserProfile(int userProfileId)
        {
            string querySystems = 
                @"
                    SELECT [UserProfileId]
                          ,[UserProfileStatus]
                          ,[UserProfileAccount]
                          ,[UserProfileDomainName]
                          ,[UserProfileName]
                          ,[UserProfileMailAddress]
                          ,[UserProfileUserLevelToUserAdmin]
                          ,[UserProfileOperatorId]
                          ,[UserProfileTimeStamp]
                    FROM [dbo].[UserProfile]
                    WHERE [UserProfileId] = @userProfileId
                ";

            UserProfile profile = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(querySystems, connection))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows.Count == 1 && dt.Rows[0] != null)
                    {
                        var row = dt.Rows[0];
                        Status status;
                        profile = new UserProfile
                        {
                            Id = (int)row["UserProfileId"],
                            Status = (!(row["UserProfileStatus"] is DBNull) && Enum.TryParse<Status>(row["UserProfileStatus"].ToString(), out status) ? status : Status.Undefined),
                            Account = row["UserProfileAccount"].ToString(),
                            DomainName = row["UserProfileDomainName"].ToString(),
                            Name = row["UserProfileName"].ToString(),
                            MailAddress = row["UserProfileMailAddress"].ToString(),
                            IsAdmin = row["UserProfileUserLevelToUserAdmin"].ToString() == "Y",
                            InsertedBy = (row["UserProfileOperatorId"] is DBNull) ? default(int?) : (int)row["UserProfileOperatorId"],
                            InsertedAt = (row["UserProfileTimeStamp"] is DBNull) ? default(DateTime?) : (DateTime)row["UserProfileTimeStamp"]
                        };
                    }
                }
            }
            return profile;
        }

        public List<LocalSystem> GetSystems()
        {
            string querySystems = @"SELECT LocalSystemId AS Id, LocalSystemName AS Name FROM [dbo].[LocalSystem]";

            var systems = new List<LocalSystem>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(querySystems, connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        systems.Add(new LocalSystem { Id = (int)row["Id"], Name = row["Name"].ToString() });
                    }
                }
            }
            return systems;
        }

        public List<Branch> GetBranches()
        {
            string querySystems = @"SELECT [BranchCode], [BranchName] FROM [dbo].[Branch]";

            var branches = new List<Branch>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(querySystems, connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        branches.Add(new Branch { Code = row["BranchCode"].ToString(), Name = row["BranchName"].ToString() });
                    }
                }
            }
            return branches;
        }

        public AggregationBindingList<UserProfileSystemSetting> GetSystemSettings(int userProfileId)
        {
            string queryBranchSettings =
                @"
SELECT 
    SystemId,
	SystemName,
	CAST(CASE WHEN [LN] = 0 THEN 1 ELSE 0 END AS BIT) [LN],
	CAST(CASE WHEN [BR] = 0 THEN 1 ELSE 0 END AS BIT) [BR],
	CAST(CASE WHEN [PR] = 0 THEN 1 ELSE 0 END AS BIT) [PR],
	CAST(CASE WHEN [DF] = 0 THEN 1 ELSE 0 END AS BIT) [DF]
FROM (
	SELECT 
		s.LocalSystemId [SystemId],
		s.LocalSystemName [SystemName], 
		MAX(CASE BranchCode WHEN 'LN' THEN sb.LocalSystemBranchStatus END) [LN],
		MAX(CASE BranchCode WHEN 'BR' THEN sb.LocalSystemBranchStatus END) [BR],
		MAX(CASE BranchCode WHEN 'PR' THEN sb.LocalSystemBranchStatus END) [PR],
		MAX(CASE BranchCode WHEN 'DF' THEN sb.LocalSystemBranchStatus END) [DF]
	FROM 
		[dbo].[LocalSystemBranch] sb
		RIGHT JOIN [dbo].[LocalSystem] s  ON s.LocalSystemId = sb.LocalSystemBranchLocalSystemId AND sb.LocalSystemBranchUserProfileId = @userProfileId 
		LEFT JOIN [dbo].[Branch] b ON b.BranchCode = sb.LocalSystemBranchCode AND b.BranchCode IS NOT NULL
		LEFT JOIN [dbo].[UserProfile] u ON u.UserProfileId = sb.LocalSystemBranchUserProfileId
	WHERE 
		s.LocalSystemName IS NOT NULL
	GROUP BY 
		s.LocalSystemId, 
		s.LocalSystemName
) AS BranchSettings
ORDER BY 
	SystemId;
SELECT
	[SystemId],
	[SystemName],
	[CategoryId],
	[CategoryName],
	[AccessId]
FROM
(
	SELECT 
		s.LocalSystemId [SystemId],
		s.LocalSystemName [SystemName],
		uc.UserLevelCategoryId [CategoryId],
		uc.UserLevelCategoryName [CategoryName],
		ua.UserAccessId [AccessId]
	FROM
		[dbo].[UserAccess] ua 
		INNER JOIN [dbo].[UserProfile] u ON ua.UserAccessUserProfileId = u.UserProfileId 
		INNER JOIN [dbo].[UserLevelCategory] uc ON uc.UserLevelCategoryId = ua.UserAccessUserLevelCategoryId 
		INNER JOIN [dbo].[LocalSystem] s ON s.LocalSystemId = ua.UserAccessLocalSystemId
	WHERE
		u.UserProfileId = @userProfileId
) AS CategorySettings
ORDER BY 
	SystemId
;
";

            AggregationBindingList<UserProfileSystemSetting> settings = new AggregationBindingList<UserProfileSystemSetting>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(queryBranchSettings, connection))
                {
                    adapter.TableMappings.Add("BranchSettings", "BranchSettings");
                    adapter.TableMappings.Add("CategorySettings", "CategorySettings");
                    adapter.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    string query = adapter.SelectCommand.CommandText;
                    DataSet ds = new DataSet();
                    //adapter.TableMappings.Add("BranchSettings", "CategorySettings");
                    //DataTable dt = new DataTable();
                    adapter.Fill(ds);

                    foreach (DataRow row in ds.Tables["BranchSettings"].Rows)
                    {
                        settings.Add(
                            new UserProfileSystemSetting
                            {
                                LocalSystem = (row["SystemId"] is DBNull) ? new LocalSystem() : new LocalSystem
                                {
                                    Id = (int)row["SystemId"],
                                    Name = row["SystemName"].ToString()
                                },
                                IsBranchLnActive = (bool)row["LN"],
                                IsBranchBrActive = (bool)row["BR"],
                                IsBranchPrActive = (bool)row["PR"],
                                IsBranchDfActive = (bool)row["DF"]
                            });
                    }

                    foreach (DataRow row in ds.Tables["CategorySettings"].Rows)
                    {
                        var setting = settings.First(s => s.LocalSystem.Id == (int)row["SystemId"]);
                        setting.Category = (row["CategoryId"] is DBNull) ? new UserLevelCategory() : new UserLevelCategory()
                        {
                            Id = (int)row["CategoryId"],
                            Name = row["CategoryName"].ToString(),
                            LocalSystemId = (int)row["SystemId"]
                        };
                    }
                }
            }
            return settings;
        }
        public void DeleteUserData(int userProfileId)
        {
            string querySystems =
                @"
                    UPDATE        
                ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(querySystems, connection))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1 && dt.Rows[0] != null)
                    {
                   
                    }
                }
            }
            
        }

        public void UpdateUserSystemSettings(AggregationBindingList<UserProfileSystemSetting> userSystemSettings)
        {
            StringBuilder queries = new StringBuilder();
            foreach (var setting in userSystemSettings)
            {
                queries.AppendLine(@"UPDATE ");
            }

            /*
            //1. update UserAccess
            string queryUpdateUserAccess =
                @"
                    UPDATE        
                ";

            //2. update LocalSystemBranch
            string queryUpdateLocalSystemBranch =


            //3. update user profile details
            string queryUpdateUserProfile =

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(querySystems, connection))
                {
                    //sda.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1 && dt.Rows[0] != null)
                    {

                    }
                }
            }
            */
        }
    }
}
