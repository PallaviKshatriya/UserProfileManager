USE [UserProfiles]
SELECT 
	UserLevelCategoryId [Id], 
	ISNULL(UserLevelCategoryName,' ') [Name], 
	s.LocalSystemId [SystemId], 
	s.LocalSystemName [SystemName] 
FROM [dbo].[UserLevelCategory] c
	INNER JOIN [dbo].[LocalSystem] s ON s.LocalSystemId = c.UserLevelCategoryLocalSystemId AND s.LocalSystemName IS NOT NULL