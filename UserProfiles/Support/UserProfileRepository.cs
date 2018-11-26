using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            string querySettings =
                @"SELECT 
    SystemId,
	SystemName,
	CAST(CASE WHEN [LN] = 0 THEN 1 ELSE 0 END AS BIT) [LN],
	CAST(CASE WHEN [BR] = 0 THEN 1 ELSE 0 END AS BIT) [BR],
	CAST(CASE WHEN [PR] = 0 THEN 1 ELSE 0 END AS BIT) [PR],
	CAST(CASE WHEN [DF] = 0 THEN 1 ELSE 0 END AS BIT) [DF],
	COALESCE(CategoryId, EmptyCategoryId, -1) [CategoryId],
	ISNULL(CategoryName, ' ') [CategoryName]
FROM 
(
	SELECT 
        s.LocalSystemId [SystemId],
		s.LocalSystemName [SystemName], 
		MIN(Case BranchCode When 'LN' Then sb.LocalSystemBranchStatus End) [LN],
		MIN(Case BranchCode When 'BR' Then sb.LocalSystemBranchStatus End) [BR],
		MIN(Case BranchCode When 'PR' Then sb.LocalSystemBranchStatus End) [PR],
		MIN(Case BranchCode When 'DF' Then sb.LocalSystemBranchStatus End) [DF],
		uc.UserLevelCategoryId  [CategoryId],
		uc.UserLevelCategoryName [CategoryName],
		EmptyCategories.UserLevelCategoryId [EmptyCategoryId]
	FROM 
		[dbo].[LocalSystem] s 
		LEFT JOIN [dbo].[LocalSystemBranch] sb ON s.LocalSystemId = sb.LocalSystemBranchLocalSystemId AND sb.LocalSystemBranchUserProfileId = @userProfileId 
		LEFT JOIN [dbo].[Branch] b ON b.BranchCode = sb.LocalSystemBranchCode AND b.BranchCode IS NOT NULL
		LEFT JOIN [dbo].[UserProfile] u ON u.UserProfileId = sb.LocalSystemBranchUserProfileId
		LEFT JOIN [dbo].[UserAccess] ua ON ua.UserAccessUserProfileId = u.UserProfileId 
			AND ua.UserAccessLocalSystemId = s.LocalSystemId 
			AND ua.UserAccessStatus = 0 
			AND ua.UserAccessUserProfileId = @userProfileId
		LEFT JOIN [dbo].[UserLevelCategory] uc ON uc.UserLevelCategoryId = ua.UserAccessUserLevelCategoryId 
		LEFT JOIN 
		(
			SELECT c.UserLevelCategoryId, ls.LocalSystemId FROM [dbo].[UserLevelCategory] c INNER JOIN [dbo].[LocalSystem] ls ON c.UserLevelCategoryLocalSystemId = ls.LocalSystemId AND c.UserLevelCategoryName IS NULL
		) EmptyCategories ON s.LocalSystemId = EmptyCategories.LocalSystemId
    WHERE 
		s.LocalSystemName IS NOT NULL
		
	GROUP BY 
		s.LocalSystemId, 
		s.LocalSystemName,
		uc.UserLevelCategoryId,
		uc.UserLevelCategoryName,
		EmptyCategories.UserLevelCategoryId
) AS UserProfileSettings";

            AggregationBindingList<UserProfileSystemSetting> settings = new AggregationBindingList<UserProfileSystemSetting>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(querySettings, connection))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    string query = sda.SelectCommand.CommandText;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        settings.Add(
                            new UserProfileSystemSetting
                            {
                                LocalSystem = (row["CategoryId"] is DBNull) ? new LocalSystem() : new LocalSystem
                                {
                                    Id = (int) row["SystemId"],
                                    Name = row["SystemName"].ToString()
                                },
                                IsBranchLnActive = (bool)row["LN"],
                                IsBranchBrActive = (bool)row["BR"],
                                IsBranchPrActive = (bool)row["PR"],
                                IsBranchDfActive = (bool)row["DF"],
                                Category = (row["CategoryId"] is DBNull) ? new UserLevelCategory() : new UserLevelCategory()
                                {
                                    Id = (int) row["CategoryId"],
                                    Name = row["CategoryName"].ToString(),
                                    LocalSystemId = (int) row["SystemId"]
                                }
                            });
                    }
                }
            }
            return settings;
        }
      
        public void DeleteUserDetails(int UserProfileId)
        {

            string sqlUserAccess = "BEGIN UPDATE [dbo].[UserAccess] SET[UserAccessStatus] = -1 WHERE [UserAccessUserProfileId] = @userProfileId;",
                   sqlUserSettings = "UPDATE [dbo].[LocalSystemBranch] SET[LocalSystemBranchStatus] = -1 WHERE [LocalSystemBranchUserProfileId] = @userProfileId;",
                   sqlUserProfile = "UPDATE [dbo].[UserProfile] SET[UserProfileStatus] = -1 WHERE [UserProfileOperatorId] = @userProfileId; END;";

            string sql = string.Format("{0}{1}{2}", sqlUserAccess,sqlUserSettings,sqlUserProfile);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand(sql, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@userProfileId", UserProfileId);
                    connection.Open();
                    int recs = cmdUpdate.ExecuteNonQuery();
                }
                
            }
        }

        public void UpdateUserSystemSettings(AggregationBindingList<UserProfileSystemSetting> userSystemSettings)
        {
            //foreach(var setting in userSystemSettings)
            //{
            //    setting.Category
            //}

            ////1. update UserAccess
            //string queryUpdateUserAccess =
            //    @"
            //        UPDATE        
            //    ";

            ////2. update LocalSystemBranch
            //string queryUpdateLocalSystemBranch =


            ////3. update user profile details
            //string queryUpdateUserProfile =


            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();

            //    using (SqlDataAdapter sda = new SqlDataAdapter(querySystems, connection))
            //    {
            //        //sda.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
            //        DataTable dt = new DataTable();
            //        sda.Fill(dt);
            //        if (dt.Rows.Count == 1 && dt.Rows[0] != null)
            //        {

            //        }
            //    }
            //}
        }
    }
}
