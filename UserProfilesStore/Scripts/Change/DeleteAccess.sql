UPDATE [dbo].[UserAccess] SET[UserAccessStatus] = -1 WHERE [UserAccessUserProfileId] = @userProfileId;
UPDATE [dbo].[LocalSystemBranch] SET[LocalSystemBranchStatus] = -1 WHERE [LocalSystemBranchUserProfileId] = @userProfileId;
UPDATE [dbo].[UserProfile] SET[UserProfileStatus] = -1 WHERE [UserProfileOperatorId] = @userProfileId;
