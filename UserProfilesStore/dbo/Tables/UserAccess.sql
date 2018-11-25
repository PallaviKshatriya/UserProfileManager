CREATE TABLE [dbo].[UserAccess] (
    [UserAccessId]                  INT IDENTITY (1, 1) NOT NULL,
    [UserAccessStatus]              INT NULL,
    [UserAccessUserProfileId]       INT NULL,
    [UserAccessLocalSystemId]       INT NULL,
    [UserAccessUserLevelCategoryId] INT NULL,
    PRIMARY KEY CLUSTERED ([UserAccessId] ASC)
);

