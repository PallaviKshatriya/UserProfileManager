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
   public class UserProfileRepository
    {
        public List<UserLevelCategory> GetUserLevelCategories()
        {
            string queryUserLevelCategory = @"SELECT UserLevelCategoryId AS Id, UserLevelCategoryName AS Name, s.LocalSystemId AS SystemId, s.LocalSystemName AS SystemName 
                FROM [dbo].[UserLevelCategory] c
                INNER JOIN [dbo].[LocalSystem] s ON s.LocalSystemId = c.UserLevelCategoryLocalSystemId AND s.LocalSystemName IS NOT NULL";

            var userLevelCategories = new List<UserLevelCategory>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
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

        /*
        public List<Branch> GetBranches() => new List<Branch>
            {
                new Branch { Code = "LN", Name = "London" },
                new Branch { Code = "BR", Name = "Brussels" },
                new Branch { Code = "PR", Name = "Paris" },
                new Branch { Code = "DF", Name = "Dusseldorf" }
            };
        */

        /*
        public DataTable GetGridColumns()
        {
            var query = "SELECT [BranchCode],[BranchName] FROM [dbo].[Branch]";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                    else
                    {
                        MessageBox.Show("Please Check your Username & password");
                        return null;
                    }
                }
            }
        }
        */

        /*
        public AggregationBindingList<UserProfileSystemSetting> GetSystemSettings(int userProfileId)
        {
            var system1 = new LocalSystem { Id = 1, Name = "System A" };
            var system2 = new LocalSystem { Id = 2, Name = "System B" };
            var system3 = new LocalSystem { Id = 3, Name = "System C" };
            return new AggregationBindingList<UserProfileSystemSetting>
            {
                new UserProfileSystemSetting { System = system1 , LN = true, BR = false, DF = true, PR = true, Category = new UserLevelCategory { Id = 3, Name = "Front Office Dept 1", SystemId = 1} },
                new UserProfileSystemSetting { System = system2 , LN = false, BR = false, DF = false, PR = true, Category = new UserLevelCategory { Id = 9, Name = "System Administrator", SystemId = 2} },
                new UserProfileSystemSetting { System = system3 , LN = true, BR = true, DF = true, PR = false, Category = new UserLevelCategory { Id = 17, Name = "Middle Office Senior Manager", SystemId = 3 }},
            };
        }
        */

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
	CategoryId,
	CategoryName
FROM 
(
	SELECT 
        s.LocalSystemId [SystemId],
		s.LocalSystemName [SystemName], 
		MIN(Case BranchCode When 'LN' Then sb.LocalSystemBranchStatus End) [LN],
		MIN(Case BranchCode When 'BR' Then sb.LocalSystemBranchStatus End) [BR],
		MIN(Case BranchCode When 'PR' Then sb.LocalSystemBranchStatus End) [PR],
		MIN(Case BranchCode When 'DF' Then sb.LocalSystemBranchStatus End) [DF],
		uc.UserLevelCategoryId [CategoryId],
		uc.UserLevelCategoryName [CategoryName]
	FROM 
		[dbo].[LocalSystem] s 
		LEFT JOIN [dbo].[LocalSystemBranch] sb ON s.LocalSystemId = sb.LocalSystemBranchLocalSystemId AND sb.LocalSystemBranchUserProfileId = @userProfileId 
		LEFT JOIN [dbo].[Branch] b ON b.BranchCode = sb.LocalSystemBranchCode AND b.BranchCode IS NOT NULL
		LEFT JOIN [dbo].[UserProfile] u ON u.UserProfileId = sb.LocalSystemBranchUserProfileId
		LEFT JOIN [dbo].[UserAccess] ua ON ua.UserAccessUserProfileId = u.UserProfileId AND ua.UserAccessLocalSystemId = s.LocalSystemId AND ua.UserAccessStatus = 0 AND ua.UserAccessUserProfileId = @userProfileId
		LEFT JOIN [dbo].[UserLevelCategory] uc ON uc.UserLevelCategoryId = ua.UserAccessUserLevelCategoryId 
    WHERE 
		s.LocalSystemName IS NOT NULL
		
	GROUP BY 
		s.LocalSystemId, 
		s.LocalSystemName,
		uc.UserLevelCategoryId,
		uc.UserLevelCategoryName
) AS UserProfileSettings";

            AggregationBindingList<UserProfileSystemSetting> settings = new AggregationBindingList<UserProfileSystemSetting>();

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
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
        public void DeleteUserData(int userProfileId)
        {
            string querySystems =
                @"
                    UPDATE        
                ";

            UserProfile profile = null;
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=UserProfiles;Integrated Security=True"))
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

    }
}
