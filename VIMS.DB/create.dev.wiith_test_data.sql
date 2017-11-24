USE [VIMS_DEV]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NOT NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](400) NOT NULL,
	[Admin] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](100) NOT NULL,
	[OrganizationId] [int] NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[StateId] [smallint] NULL,
	[CountryId] [smallint] NULL,
	[ZipCode] [varchar](10) NULL,
	[Notes] [varchar](250) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationName] [varchar](100) NOT NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](100) NOT NULL,
	[CountryId] [smallint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerClockInOutInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerClockInOutInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[VolunteerProfileId] [bigint] NULL,
	[LocationId] [int] NULL,
	[ClockInDateTime] [datetime] NULL,
	[ClockOutDateTime] [datetime] NULL,
	[ClockInProfilePhotoPath] [varchar](500) NULL,
	[ClockOutProfilePhotoPath] [varchar](500) NULL,
	[ClockInOutLocationId] [int] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DefaultVolunteerProfileInfoId] [int] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateId] [smallint] NULL,
	[CountryId] [smallint] NULL,
	[ZipCode] [varchar](10) NULL,
	[PhoneNumber] [varchar](12) NULL,
	[PhoneNumberType] [smallint] NULL,
	[Email] [varchar](75) NULL,
	[DOB] [datetime] NULL,
	[Emrgncy_Cntct_Name] [varchar](100) NULL,
	[Emrgncy_Cntct_Phn] [varchar](12) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerProfileInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerProfileInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[OrganizationId] [int] NULL,
	[CaseNumber] [varchar](50) NULL,
	[Volunteer_Hours_Needed] [smallint] NULL,
	[Skill] [varchar](50) NULL,
	[WorkInfo] [varchar](400) NULL,
	[Felony_Cnvctn] [bit] NULL,
	[Sexual_Abuse_Related] [bit] NULL,
	[Recv_Email] [bit] NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerProfilePhotoInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerProfilePhotoInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[VolunteerProfilePhotoPath] [varchar](500) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [bigint] NOT NULL,
	[NumberVolunteers] [smallint] NULL,
	[Hours] [int] NULL,
	[Date] [bigint] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/* seed data */
INSERT INTO Employee VALUES('Admin','Admin','AdminUser','Test@123',1,1,0,GETDATE(),null,null)

INSERT INTO [dbo].[Organization]
           ([OrganizationName]
           ,[Active]
           ,[CreatedBy]
           ,[CreatedDt]
           ,[UpdatedBy]
           ,[UpdatedDt])
     VALUES
           (
		   'TestOrganization'
           ,1
           ,NULL
           ,GETDATE()
           ,NULL
           ,GETDATE())

DECLARE @ORG_ID INT
SET @ORG_ID = @@IDENTITY
 		   
INSERT INTO Location (LocationName, OrganizationId, CreatedDt) VALUES('Plano',@ORG_ID,GETDATE())
INSERT INTO Location (LocationName, OrganizationId, CreatedDt) VALUES('Frisco',@ORG_ID,GETDATE())
INSERT INTO Location (LocationName, OrganizationId, CreatedDt) VALUES('Haltom City',@ORG_ID,GETDATE())

INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('United States' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Uraguay' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Canada' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Mexico' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Russia' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('France' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Nepal' ,1 ,1 ,GETDATE())

GO