using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserProfiles.Support
{
    internal static class Queries
    {
        internal const string QueryUserLevelCategory = @"
SELECT 
	UserLevelCategoryId [Id], 
	ISNULL(UserLevelCategoryName,' ') [Name], 
	s.LocalSystemId [SystemId], 
	s.LocalSystemName [SystemName] 
FROM [dbo].[UserLevelCategory] c
	INNER JOIN [dbo].[LocalSystem] s ON s.LocalSystemId = c.UserLevelCategoryLocalSystemId AND s.LocalSystemName IS NOT NULL;";

        internal const string QueryBranches = @"SELECT [BranchCode], [BranchName] FROM [dbo].[Branch]";

        internal const string QueryUserProfile = @"
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
WHERE [UserProfileId] = @userProfileId;
";

        internal const string QueryUserProfileSettings =
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
        AND ua.UserAccessStatus = 0
) AS CategorySettings
ORDER BY 
	SystemId;";

        internal const string QueryUpdateUserAccess = @"
IF EXISTS (
	SELECT 1 FROM [dbo].[UserAccess] 
	WHERE [UserAccessId] = @userAccessId 
			AND [UserAccessUserProfileId] = @userAccessUserProfileId
			AND [UserAccessLocalSystemId] = @userAccessLocalSystemId
	)
	UPDATE [dbo].[UserAccess]
		SET [UserAccessStatus] = @userAccessStatus 
			,[UserAccessUserLevelCategoryId] = @userAccessUserLevelCategoryId
		WHERE [UserAccessId] = @userAccessId
			AND [UserAccessUserProfileId] = @userAccessUserProfileId
			AND [UserAccessLocalSystemId] = @userAccessLocalSystemId;
ELSE
	INSERT INTO [dbo].[UserAccess]
				([UserAccessStatus]
				,[UserAccessUserProfileId]
				,[UserAccessLocalSystemId]
				,[UserAccessUserLevelCategoryId])
			VALUES
				(@userAccessStatus 
				,@userAccessUserProfileId
				,@userAccessLocalSystemId
				,@userAccessUserLevelCategoryId);";

        internal const string QueryUpdateBranchAccessLN = @"
IF EXISTS (
	SELECT 1 FROM [dbo].[LocalSystemBranch]
	WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
		AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
		AND [LocalSystemBranchCode] = @branchCodeLN
	)
	UPDATE [dbo].[LocalSystemBranch]
		SET [LocalSystemBranchStatus] = @branchStatusLN
		WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
			AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
			AND [LocalSystemBranchCode] = @branchCodeLN;
ELSE
	INSERT INTO [dbo].[LocalSystemBranch]
				([LocalSystemBranchStatus]
				,[LocalSystemBranchUserProfileId]
				,[LocalSystemBranchLocalSystemId]
				,[LocalSystemBranchCode])
			VALUES
				(@branchStatusLN
				,@userAccessUserProfileId
				,@userAccessLocalSystemId
				,@branchCodeLN);";

        internal const string QueryUpdateBranchAccessBR = @"
IF EXISTS (
	SELECT 1 FROM [dbo].[LocalSystemBranch]
	WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
		AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
		AND [LocalSystemBranchCode] = @branchCodeBR
	)
	UPDATE [dbo].[LocalSystemBranch]
		SET [LocalSystemBranchStatus] = @branchStatusBR
		WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
			AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
			AND [LocalSystemBranchCode] = @branchCodeBR;
ELSE
	INSERT INTO [dbo].[LocalSystemBranch]
				([LocalSystemBranchStatus]
				,[LocalSystemBranchUserProfileId]
				,[LocalSystemBranchLocalSystemId]
				,[LocalSystemBranchCode])
			VALUES
				(@branchStatusBR
				,@userAccessUserProfileId
				,@userAccessLocalSystemId
				,@branchCodeBR);";

        internal const string QueryUpdateBranchAccessPR = @"
IF EXISTS (
	SELECT 1 FROM [dbo].[LocalSystemBranch]
	WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
		AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
		AND [LocalSystemBranchCode] = @branchCodePR
	)
	UPDATE [dbo].[LocalSystemBranch]
		SET [LocalSystemBranchStatus] = @branchStatusPR
		WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
			AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
			AND [LocalSystemBranchCode] = @branchCodePR;
ELSE
	INSERT INTO [dbo].[LocalSystemBranch]
				([LocalSystemBranchStatus]
				,[LocalSystemBranchUserProfileId]
				,[LocalSystemBranchLocalSystemId]
				,[LocalSystemBranchCode])
			VALUES
				(@branchStatusPR
				,@userAccessUserProfileId
				,@userAccessLocalSystemId
				,@branchCodePR);";

        internal const string QueryUpdateBranchAccessDF = @"
IF EXISTS (
	SELECT 1 FROM [dbo].[LocalSystemBranch]
	WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
		AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
		AND [LocalSystemBranchCode] = @branchCodeDF
	)
	UPDATE [dbo].[LocalSystemBranch]
		SET [LocalSystemBranchStatus] = @branchStatusDF
		WHERE [LocalSystemBranchLocalSystemId] = @userAccessLocalSystemId
			AND [LocalSystemBranchUserProfileId] = @userAccessUserProfileId
			AND [LocalSystemBranchCode] = @branchCodeDF;
ELSE
	INSERT INTO [dbo].[LocalSystemBranch]
				([LocalSystemBranchStatus]
				,[LocalSystemBranchUserProfileId]
				,[LocalSystemBranchLocalSystemId]
				,[LocalSystemBranchCode])
			VALUES
				(@branchStatusDF
				,@userAccessUserProfileId
				,@userAccessLocalSystemId
				,@branchCodeDF);";

        internal const string QueryDeleteAccess = @"
UPDATE [dbo].[UserAccess] SET[UserAccessStatus] = -1 WHERE [UserAccessUserProfileId] = @userProfileId;
UPDATE [dbo].[LocalSystemBranch] SET[LocalSystemBranchStatus] = -1 WHERE [LocalSystemBranchUserProfileId] = @userProfileId;
UPDATE [dbo].[UserProfile] SET[UserProfileStatus] = -1 WHERE [UserProfileOperatorId] = @userProfileId;
        ";

        internal const string UpdateUserProfile = @"
UPDATE [dbo].[UserProfile]
   SET [UserProfileAccount] = @account
      ,[UserProfileDomainName] = @domainName
      ,[UserProfileName] = @fullName 
      ,[UserProfileMailAddress] = @emailAddress
      ,[UserProfileUserLevelToUserAdmin] = @isAdmin
 WHERE [UserProfileId] = @userProfileId
        ";

    }
}
