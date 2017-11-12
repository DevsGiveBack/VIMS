USE [VIMS]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [smallint] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NULL,
	[ActiveInd] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](400) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[ActiveInd] [bit] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDt] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
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
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](100) NULL,
	[OrganizationId] [int] NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[StateId] [smallint] NULL,
	[CountryId] [smallint] NULL,
	[ZipCode] [varchar](10) NULL,
	[Notes] [varchar](250) NULL,
	[ActiveInd] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationName] [varchar](100) NULL,
	[ActiveInd] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[State]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [smallint] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](100) NULL,
	[CountryId] [smallint] NULL,
	[ActiveInd] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerClockInOutInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerClockInOutInfo](
	[VolunteerClockInOutId] [bigint] IDENTITY(1,1) NOT NULL,
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
PRIMARY KEY CLUSTERED 
(
	[VolunteerClockInOutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerInfo](
	[VolunteerId] [bigint] IDENTITY(1,1) NOT NULL,
	[DefaultVolunteerProfileInfoId] [int] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateId] [smallint] NULL,
	[ZipCode] [varchar](10) NULL,
	[PhoneNumber] [varchar](12) NULL,
	[PhoneNumberType] [smallint] NULL,
	[Email] [varchar](75) NULL,
	[DOB] [datetime] NULL,
	[Emrgncy_Cntct_Name] [varchar](100) NULL,
	[Emrgncy_Cntct_Phn] [varchar](12) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[CreatedDt] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VolunteerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerProfileInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerProfileInfo](
	[VolunteerProfileId] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[OrganizationId] [int] NULL,
	[CaseNumber] [varchar](50) NOT NULL,
	[Volunteer_Hours_Needed] [smallint] NULL,
	[Skill] [varchar](50) NULL,
	[WorkInfo] [varchar](400) NULL,
	[Felony_Cnvctn] [bit] NOT NULL,
	[Sexual_Abuse_Related] [bit] NOT NULL,
	[Recv_Email] [bit] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
	[UpdatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VolunteerProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VolunteerProfilePhotoInfo]    Script Date: 3/28/2017 4:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerProfilePhotoInfo](
	[VolunteerProfilePhotoId] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[VolunteerProfilePhotoPath] [varchar](500) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VolunteerProfilePhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO