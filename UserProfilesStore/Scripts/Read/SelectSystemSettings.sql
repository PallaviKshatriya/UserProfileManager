USE [Assignment]
DECLARE @userProfileId INT
SET @userProfileId = 1

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
	SystemId
;

SELECT 
	s.LocalSystemId [SystemId],
	s.LocalSystemName [SystemName],
	uc.UserLevelCategoryId [CategoryId],
	uc.UserLevelCategoryName [CategoryName] 
FROM
	[dbo].[UserAccess] ua 
	INNER JOIN [dbo].[UserProfile] u ON ua.UserAccessUserProfileId = u.UserProfileId 
	INNER JOIN [dbo].[UserLevelCategory] uc ON uc.UserLevelCategoryId = ua.UserAccessUserLevelCategoryId 
	INNER JOIN [dbo].[LocalSystem] s ON s.LocalSystemId = ua.UserAccessLocalSystemId
WHERE
	u.UserProfileId = @userProfileId
ORDER BY 
	SystemId
;
