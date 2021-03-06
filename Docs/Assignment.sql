USE master
IF EXISTS(SELECT * FROM sys.databases WHERE NAME = 'Assignment')
BEGIN
	ALTER DATABASE Assignment SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE Assignment
END
GO
CREATE DATABASE [Assignment]
GO
USE [Assignment]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserProfileId] [int] IDENTITY(1,1) NOT NULL,
	[UserProfileStatus] [int] NULL,
	[UserProfileAccount] [nvarchar](30) NULL,
	[UserProfileDomainName] [nvarchar](20) NULL,
	[UserProfileName] [nvarchar](50) NULL,
	[UserProfileMailAddress] [nvarchar](50) NULL,
	[UserProfileUserLevelToUserAdmin] [nvarchar](1) NULL,
	[UserProfileOperatorId] [int] NULL,
	[UserProfileTimeStamp] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON
INSERT [dbo].[UserProfile] ([UserProfileId], [UserProfileStatus], [UserProfileAccount], [UserProfileDomainName], [UserProfileName], [UserProfileMailAddress], [UserProfileUserLevelToUserAdmin], [UserProfileOperatorId], [UserProfileTimeStamp]) VALUES (1, 0, N'uname01', N'eu', N'eu\uname01', N'uname01@company.co.uk', N'Y', 1, CAST(0x0000A621011B75BF AS DateTime))
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
/****** Object:  Table [dbo].[UserLevelCategory]    Script Date: 06/20/2016 14:26:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLevelCategory](
	[UserLevelCategoryId] [int] NOT NULL,
	[UserLevelCategoryName] [nvarchar](50) NULL,
	[UserLevelCategoryLocalSystemId] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (1, NULL, 1)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (2, N'Emergency', 1)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (3, N'Front Office Dept 1', 1)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (4, N'Middle Office', 1)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (5, N'Back Office', 1)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (6, N'Back Office Manager', 1)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (7, NULL, 2)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (8, N'Front Office', 2)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (9, N'System Administrator', 2)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (10, N'Emergency', 2)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (11, N'Back Office Manager 1', 2)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (12, N'Back Office Maneger 2', 2)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (13, NULL, 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (14, N'User Administrator', 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (15, N'Back Office Administrator', 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (16, N'Middle Office Staff', 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (17, N'Middle Office Senior Manager', 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (18, N'Middle Office Administrator', 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (19, N'System Programmer', 3)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (20, NULL, 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (21, N'Front Office MM', 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (22, N'Front Office FX', 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (23, N'Front Office Other Dealers', 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (24, N'Back Office Dept MM Processing', 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (25, N'Back Office Dept FX Processing', 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (26, N'Back Office Manager', 4)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (27, NULL, 5)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (28, N'Emergency', 5)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (29, N'Audit Department', 5)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (30, N'HR Department', 5)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (31, N'System Administrator', 5)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (32, NULL, 6)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (33, N'Back Office New Product', 6)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (34, N'Back Office MM', 6)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (35, N'Back Office Manager', 6)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (36, NULL, 7)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (37, N'System Help Desk', 7)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (38, N'System Client Server Team', 7)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (39, N'System Administrator', 7)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (40, N'System Security Team Staff', 7)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (41, NULL, 8)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (42, N'Front Office 1', 8)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (43, N'Front Office 2', 8)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (44, N'Back Office Manager', 8)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (45, N'Middle Office Manager', 8)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (46, N'Middle Office Staff', 8)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (47, NULL, 9)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (48, N'Credit Control Department', 9)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (49, N'Static Data Department', 9)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (50, N'Financial Control Dept.', 9)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (51, N'Legal Dept.', 9)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (52, N'Back Office 1', 9)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (53, NULL, 10)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (54, N'System Admin.', 10)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (55, N'Emergency', 10)
INSERT [dbo].[UserLevelCategory] ([UserLevelCategoryId], [UserLevelCategoryName], [UserLevelCategoryLocalSystemId]) VALUES (56, N'Help Desk', 10)
/****** Object:  Table [dbo].[UserAccess]    Script Date: 06/20/2016 14:26:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccess](
	[UserAccessId] [int] IDENTITY(1,1) NOT NULL,
	[UserAccessStatus] [int] NULL,
	[UserAccessUserProfileId] [int] NULL,
	[UserAccessLocalSystemId] [int] NULL,
	[UserAccessUserLevelCategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserAccessId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserAccess] ON
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (1, 0, 1, 1, 5)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (2, 0, 1, 2, 11)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (3, 0, 1, 3, 14)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (4, 0, 1, 4, 23)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (5, 0, 1, 5, 34)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (6, 0, 1, 6, 34)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (7, 0, 1, 7, 38)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (8, 0, 1, 8, 43)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (9, 0, 1, 9, 49)
INSERT [dbo].[UserAccess] ([UserAccessId], [UserAccessStatus], [UserAccessUserProfileId], [UserAccessLocalSystemId], [UserAccessUserLevelCategoryId]) VALUES (10, 0, 1, 10, 55)
SET IDENTITY_INSERT [dbo].[UserAccess] OFF
/****** Object:  Table [dbo].[LocalSystemBranch]    Script Date: 06/20/2016 14:26:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalSystemBranch](
	[LocalSystemBranchId] [int] IDENTITY(1,1) NOT NULL,
	[LocalSystemBranchStatus] [int] NULL,
	[LocalSystemBranchUserProfileId] [int] NULL,
	[LocalSystemBranchLocalSystemId] [int] NULL,
	[LocalSystemBranchCode] [nvarchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[LocalSystemBranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LocalSystemBranch] ON
INSERT [dbo].[LocalSystemBranch] ([LocalSystemBranchId], [LocalSystemBranchStatus], [LocalSystemBranchUserProfileId], [LocalSystemBranchLocalSystemId], [LocalSystemBranchCode]) VALUES (1, 0, 1, 1, N'LN')
INSERT [dbo].[LocalSystemBranch] ([LocalSystemBranchId], [LocalSystemBranchStatus], [LocalSystemBranchUserProfileId], [LocalSystemBranchLocalSystemId], [LocalSystemBranchCode]) VALUES (2, 0, 1, 2, N'BR')
INSERT [dbo].[LocalSystemBranch] ([LocalSystemBranchId], [LocalSystemBranchStatus], [LocalSystemBranchUserProfileId], [LocalSystemBranchLocalSystemId], [LocalSystemBranchCode]) VALUES (3, 0, 1, 3, N'PR')
INSERT [dbo].[LocalSystemBranch] ([LocalSystemBranchId], [LocalSystemBranchStatus], [LocalSystemBranchUserProfileId], [LocalSystemBranchLocalSystemId], [LocalSystemBranchCode]) VALUES (4, 0, 1, 3, N'DF')
SET IDENTITY_INSERT [dbo].[LocalSystemBranch] OFF
/****** Object:  Table [dbo].[LocalSystem]    Script Date: 06/20/2016 14:26:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalSystem](
	[LocalSystemId] [int] NULL,
	[LocalSystemName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (0, NULL)
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (1, N'System A')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (2, N'System B')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (3, N'System C')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (4, N'System D')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (5, N'System E')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (6, N'System F')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (7, N'System G')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (8, N'System H')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (9, N'System I')
INSERT [dbo].[LocalSystem] ([LocalSystemId], [LocalSystemName]) VALUES (10, N'System L')
/****** Object:  Table [dbo].[Branch]    Script Date: 06/20/2016 14:26:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchCode] [nvarchar](2) NULL,
	[BranchName] [nvarchar](20) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Branch] ([BranchCode], [BranchName]) VALUES (NULL, NULL)
INSERT [dbo].[Branch] ([BranchCode], [BranchName]) VALUES (N'LN', N'London')
INSERT [dbo].[Branch] ([BranchCode], [BranchName]) VALUES (N'BR', N'Brussels')
INSERT [dbo].[Branch] ([BranchCode], [BranchName]) VALUES (N'PR', N'Paris')
INSERT [dbo].[Branch] ([BranchCode], [BranchName]) VALUES (N'DF', N'Dusseldorf')
