using System.Collections.Generic;

namespace UserProfiles.Model
{
    public interface IRepository
    {       
        List<Branch> GetBranches();
        List<LocalSystem> GetSystems();
        AggregationBindingList<UserProfileSystemSetting> GetSystemSettings(int userProfileId);
        List<UserLevelCategory> GetUserLevelCategories();
        UserProfile GetUserProfile(int userProfileId);
        void UpdateUserSystemSettings(AggregationBindingList<UserProfileSystemSetting> userSystemSettings);
        void DeleteUserDetails(int userProfileId);
    }
}