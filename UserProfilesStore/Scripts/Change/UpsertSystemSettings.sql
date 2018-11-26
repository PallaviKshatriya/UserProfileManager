USE [Assignment]
GO

SELECT * FROM [Assignment].[dbo].[LocalSystemBranch];
SELECT * FROM [Assignment].[dbo].[UserAccess];

DECLARE @userAccessUserProfileId INT
DECLARE @userAccessLocalSystemId INT
DECLARE @userAccessStatus INT
DECLARE @userAccessUserLevelCategoryId INT
DECLARE @userAccessId INT
DECLARE @branchStatusLN INT
DECLARE @branchStatusBR INT
DECLARE @branchStatusPR INT
DECLARE @branchStatusDF INT
DECLARE @branchCodeLN nvarchar(2)
DECLARE @branchCodeBR nvarchar(2)
DECLARE @branchCodePR nvarchar(2)
DECLARE @branchCodeDF nvarchar(2)

SET @userAccessUserProfileId = 1
SET @userAccessLocalSystemId = 5
SET @userAccessStatus = 0
SET @userAccessUserLevelCategoryId = 28
SET @userAccessId = 5
SET @branchStatusLN = -1
SET @branchStatusBR = 0
SET @branchStatusPR = -1
SET @branchStatusDF = 0
SET @branchCodeLN = 'LN'
SET @branchCodeBR = 'BR'
SET @branchCodePR = 'PR'
SET @branchCodeDF = 'DF'

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
				,@userAccessUserLevelCategoryId);

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
				,@branchCodeLN);

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
				,@branchCodeBR);

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
				,@branchCodePR);

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
				,@branchCodeDF);

SELECT * FROM [Assignment].[dbo].[LocalSystemBranch];
SELECT * FROM [Assignment].[dbo].[UserAccess];