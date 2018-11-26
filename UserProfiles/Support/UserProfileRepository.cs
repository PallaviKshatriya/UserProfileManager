using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UserProfiles.Support;

namespace UserProfiles.Model
{
    public class UserProfileRepository : IRepository
    {
        public string ConnectionString { get; } = Properties.Settings.Default["ConnectionString"].ToString();

        public List<UserLevelCategory> GetUserLevelCategories()
        {
            var userLevelCategories = new List<UserLevelCategory>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(Queries.QueryUserLevelCategory, connection))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        userLevelCategories.Add(new UserLevelCategory { Id = (int)row["Id"], Name = row["Name"].ToString(), LocalSystemId = (int)row["SystemId"] });
                    }
                }
            }
            return userLevelCategories;
        }

        public UserProfile GetUserProfile(int userProfileId)
        {
            UserProfile profile = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(Queries.QueryUserProfile, connection))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    DataTable dt = new DataTable();
                    connection.Open();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1 && dt.Rows[0] != null)
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

        public List<Branch> GetBranches()
        {
            var branches = new List<Branch>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(Queries.QueryBranches, connection))
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
            AggregationBindingList<UserProfileSystemSetting> settings = new AggregationBindingList<UserProfileSystemSetting>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(Queries.QueryUserProfileSettings, connection))
                {
                    adapter.TableMappings.Add("Table", "BranchSettings");
                    adapter.TableMappings.Add("Table1", "CategorySettings");
                    adapter.SelectCommand.Parameters.AddWithValue("@userProfileId", userProfileId); //Prevent SQL Injection
                    string query = adapter.SelectCommand.CommandText;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    foreach (DataRow row in ds.Tables["BranchSettings"].Rows)
                    {
                        settings.Add(
                            new UserProfileSystemSetting
                            {
                                UserProfileId = userProfileId,
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
                        setting.UserAccessId = (int)row["AccessId"];
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

        public void DeleteUserDetails(int UserProfileId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand(Queries.QueryDeleteAccess, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@userProfileId", UserProfileId);
                    connection.Open();
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUserSystemSettings(AggregationBindingList<UserProfileSystemSetting> userSystemSettings)
        {
            StringBuilder queries = new StringBuilder();
            queries.AppendLine(Queries.QueryUpdateUserAccess);
            queries.AppendLine(Queries.QueryUpdateBranchAccessLN);
            queries.AppendLine(Queries.QueryUpdateBranchAccessBR);
            queries.AppendLine(Queries.QueryUpdateBranchAccessPR);
            queries.AppendLine(Queries.QueryUpdateBranchAccessDF);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand())
                {
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.CommandText = queries.ToString();
                    cmdUpdate.Connection = connection;

                    foreach (var setting in userSystemSettings)
                    {
                        cmdUpdate.Parameters.Clear();

                        cmdUpdate.Parameters.AddWithValue("@userAccessId", setting.UserAccessId);
                        cmdUpdate.Parameters.AddWithValue("@userAccessUserProfileId", setting.UserProfileId);
                        cmdUpdate.Parameters.AddWithValue("@userAccessLocalSystemId", setting.LocalSystem.Id);
                        cmdUpdate.Parameters.AddWithValue("@userAccessStatus", 0);
                        cmdUpdate.Parameters.AddWithValue("@userAccessUserLevelCategoryId", setting.Category.Id);
                        cmdUpdate.Parameters.AddWithValue("@branchStatusLN", setting.IsBranchLnActive ? 0 : -1);
                        cmdUpdate.Parameters.AddWithValue("@branchStatusBR", setting.IsBranchBrActive ? 0 : -1);
                        cmdUpdate.Parameters.AddWithValue("@branchStatusPR", setting.IsBranchPrActive ? 0 : -1);
                        cmdUpdate.Parameters.AddWithValue("@branchStatusDF", setting.IsBranchDfActive ? 0 : -1);
                        cmdUpdate.Parameters.AddWithValue("@branchCodeLN", "LN");
                        cmdUpdate.Parameters.AddWithValue("@branchCodeBR", "BR");
                        cmdUpdate.Parameters.AddWithValue("@branchCodePR", "PR");
                        cmdUpdate.Parameters.AddWithValue("@branchCodeDF", "DF");

                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmdUpdate = new SqlCommand(Queries.UpdateUserProfile, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@userProfileId", userProfile.Id);
                    cmdUpdate.Parameters.AddWithValue("@account", userProfile.Account);
                    cmdUpdate.Parameters.AddWithValue("@domainName", userProfile.DomainName);
                    cmdUpdate.Parameters.AddWithValue("@fullName", userProfile.DomainName + @"\" + userProfile.Account);
                    cmdUpdate.Parameters.AddWithValue("@emailAddress", userProfile.MailAddress);
                    cmdUpdate.Parameters.AddWithValue("@isAdmin", userProfile.IsAdmin ? "Y" : "N");
                    connection.Open();
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }
    }
}