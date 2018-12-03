CREATE DATABASE Hive
GO
/*******************************************/
USE [Hive]
GO
ALTER TABLE [hive].[OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Product_PRODUCT_ID]
GO
ALTER TABLE [hive].[OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Order_ORDER_ID]
GO
ALTER TABLE [hive].[Order] DROP CONSTRAINT [FK_Order_AspNetUsers_USER_ID]
GO
ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
/****** Object:  Table [hive].[Product]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [hive].[Product]
GO
/****** Object:  Table [hive].[OrderDetails]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [hive].[OrderDetails]
GO
/****** Object:  Table [hive].[Order]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [hive].[Order]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetUserTokens]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[AspNetRoleClaims]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Schema [hive]    Script Date: 12/3/2018 9:55:53 AM ******/
DROP SCHEMA [hive]
GO
/****** Object:  Schema [hive]    Script Date: 12/3/2018 9:55:53 AM ******/
CREATE SCHEMA [hive]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/3/2018 9:55:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/3/2018 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/3/2018 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/3/2018 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/3/2018 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/3/2018 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/3/2018 9:55:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[USER_ID] [nvarchar](450) NOT NULL,
	[FIRST_NAME] [nvarchar](200) NOT NULL,
	[LAST_NAME] [nvarchar](200) NOT NULL,
	[ADDRESS] [nvarchar](200) NULL,
	[CITY] [nvarchar](200) NULL,
	[COUNTRY] [nvarchar](200) NULL,
	[CREATED_DATE] [datetime2](7) NOT NULL,
	[CREATED_BY] [nvarchar](50) NOT NULL,
	[MODIFIED_DATE] [datetime2](7) NOT NULL,
	[MODIFIED_BY] [nvarchar](50) NOT NULL,
	[IS_DELETED] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/3/2018 9:55:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [hive].[Order]    Script Date: 12/3/2018 9:55:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hive].[Order](
	[CREATED_DATE] [datetime2](7) NOT NULL,
	[CREATED_BY] [nvarchar](50) NOT NULL,
	[MODIFIED_DATE] [datetime2](7) NOT NULL,
	[MODIFIED_BY] [nvarchar](50) NOT NULL,
	[IS_DELETED] [bit] NOT NULL,
	[RTS] [timestamp] NOT NULL,
	[ORDER_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_ID] [nvarchar](450) NULL,
	[REQUIRED_DATE] [datetime2](7) NOT NULL,
	[SHIP_ADDRESS] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ORDER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [hive].[OrderDetails]    Script Date: 12/3/2018 9:55:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hive].[OrderDetails](
	[CREATED_DATE] [datetime2](7) NOT NULL,
	[CREATED_BY] [nvarchar](50) NOT NULL,
	[MODIFIED_DATE] [datetime2](7) NOT NULL,
	[MODIFIED_BY] [nvarchar](50) NOT NULL,
	[IS_DELETED] [bit] NOT NULL,
	[RTS] [timestamp] NOT NULL,
	[ORDER_DETAILS_ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDER_ID] [int] NOT NULL,
	[PRODUCT_ID] [int] NOT NULL,
	[UNIT_PRICE] [decimal](7, 2) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[DISCOUNT] [decimal](2, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[ORDER_DETAILS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [hive].[Product]    Script Date: 12/3/2018 9:55:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [hive].[Product](
	[CREATED_DATE] [datetime2](7) NOT NULL,
	[CREATED_BY] [nvarchar](50) NOT NULL,
	[MODIFIED_DATE] [datetime2](7) NOT NULL,
	[MODIFIED_BY] [nvarchar](50) NOT NULL,
	[IS_DELETED] [bit] NOT NULL,
	[RTS] [timestamp] NOT NULL,
	[PRODUCT_ID] [int] IDENTITY(1,1) NOT NULL,
	[PRODUCT_NAME] [nvarchar](200) NOT NULL,
	[UNIT_PRICE] [float] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181203041909_InitialCreate', N'2.1.4-rtm-31024')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'50beb3d7-d980-49e9-8c9d-a4cde46cfd91', N'Admin', N'ADMIN', N'1b6a73f1-178a-4981-825a-b838bf100344')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'140f171c-c04f-45fb-80ac-894a6385285f', N'50beb3d7-d980-49e9-8c9d-a4cde46cfd91')
INSERT [dbo].[AspNetUsers] ([UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [USER_ID], [FIRST_NAME], [LAST_NAME], [ADDRESS], [CITY], [COUNTRY], [CREATED_DATE], [CREATED_BY], [MODIFIED_DATE], [MODIFIED_BY], [IS_DELETED]) VALUES (N'admin', N'ADMIN', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEBq58XudrCF4+GAiAF1/VdR+B54lGZayIGiENi9MYMNB1qFO8jhbbM+4COUopNxPEQ==', N'X5Q7P6F6T5R6FIEXL4CKVAGDBJQJT4Y5', N'43933591-cead-4a5c-99a7-1a0a907f94d6', NULL, 0, 0, NULL, 1, 0, N'140f171c-c04f-45fb-80ac-894a6385285f', N'Admin', N'Admin', NULL, NULL, NULL, CAST(N'2018-12-03T09:53:37.3404557' AS DateTime2), N'josephr', CAST(N'2018-12-03T09:53:37.3404573' AS DateTime2), N'josephr', 0)
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([USER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([USER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([USER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([USER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [hive].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_AspNetUsers_USER_ID] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[AspNetUsers] ([USER_ID])
GO
ALTER TABLE [hive].[Order] CHECK CONSTRAINT [FK_Order_AspNetUsers_USER_ID]
GO
ALTER TABLE [hive].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order_ORDER_ID] FOREIGN KEY([ORDER_ID])
REFERENCES [hive].[Order] ([ORDER_ID])
ON DELETE CASCADE
GO
ALTER TABLE [hive].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order_ORDER_ID]
GO
ALTER TABLE [hive].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product_PRODUCT_ID] FOREIGN KEY([PRODUCT_ID])
REFERENCES [hive].[Product] ([PRODUCT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [hive].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product_PRODUCT_ID]
GO
