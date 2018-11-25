USE [UserProfiles]
DECLARE @userProfileId INT
SET @userProfileId = 1
SELECT 
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
) AS UserProfileSettings