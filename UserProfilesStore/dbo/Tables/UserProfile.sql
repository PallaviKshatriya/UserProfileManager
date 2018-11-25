CREATE TABLE [dbo].[UserProfile] (
    [UserProfileId]                   INT           IDENTITY (1, 1) NOT NULL,
    [UserProfileStatus]               INT           NULL,
    [UserProfileAccount]              NVARCHAR (30) NULL,
    [UserProfileDomainName]           NVARCHAR (20) NULL,
    [UserProfileName]                 NVARCHAR (50) NULL,
    [UserProfileMailAddress]          NVARCHAR (50) NULL,
    [UserProfileUserLevelToUserAdmin] NVARCHAR (1)  NULL,
    [UserProfileOperatorId]           INT           NULL,
    [UserProfileTimeStamp]            DATETIME      NULL
);

