CREATE TABLE [dbo].[LocalSystemBranch] (
    [LocalSystemBranchId]            INT          IDENTITY (1, 1) NOT NULL,
    [LocalSystemBranchStatus]        INT          NULL,
    [LocalSystemBranchUserProfileId] INT          NULL,
    [LocalSystemBranchLocalSystemId] INT          NULL,
    [LocalSystemBranchCode]          NVARCHAR (2) NULL,
    PRIMARY KEY CLUSTERED ([LocalSystemBranchId] ASC)
);

