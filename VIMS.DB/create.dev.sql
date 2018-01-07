USE [VIMS_DEV]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[Employee]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AspNetUsers_Id] [nvarchar](128) NULL,
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
/****** Object:  Table [dbo].[Group]    Script Date: 12/31/2017 8:20:02 AM ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[OrganizationId] [bigint] NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[StateId] [bigint] NULL,
	[CountryId] [bigint] NULL,
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
/****** Object:  Table [dbo].[NoShows]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoShows](
	[Id] [bigint] NULL,
	[VolunteerId] [bigint] NULL,
	[Date] [datetime] NULL,
	[Active] [bit] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDt] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
	[UpdatedDt] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[State]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Active] [bit] NULL,
	[CountryId] [bigint] NULL,
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
/****** Object:  Table [dbo].[Volunteer]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DefaultVolunteerProfileInfoId] [bigint] NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[StateId] [bigint] NULL,
	[CountryId] [bigint] NULL,
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
/****** Object:  Table [dbo].[VolunteerPhoto]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerPhoto](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[Path] [varchar](500) NULL,
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
/****** Object:  Table [dbo].[VolunteerProfile]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerProfile](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[OrganizationId] [bigint] NULL,
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
/****** Object:  Table [dbo].[VolunteerTimeClock]    Script Date: 12/31/2017 8:20:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerTimeClock](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationId] [bigint] NULL,
	[VolunteerId] [bigint] NULL,
	[VolunteerProfileId] [bigint] NULL,
	[ClockIn] [datetime] NULL,
	[ClockOut] [datetime] NULL,
	[ClockInPhoto] [varchar](500) NULL,
	[ClockOutPhoto] [varchar](500) NULL,
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
ALTER TABLE [dbo].[Country]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[VolunteerPhoto]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[VolunteerPhoto]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[Volunteer] ([Id])
GO
ALTER TABLE [dbo].[VolunteerProfile]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[VolunteerProfile]  WITH CHECK ADD FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
GO
ALTER TABLE [dbo].[VolunteerProfile]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[Volunteer] ([Id])
GO
ALTER TABLE [dbo].[VolunteerTimeClock]  WITH CHECK ADD FOREIGN KEY([VolunteerProfileId])
REFERENCES [dbo].[VolunteerProfile] ([Id])
GO
ALTER TABLE [dbo].[VolunteerTimeClock]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[Volunteer] ([Id])
GO

/* seed data */
INSERT INTO Employee VALUES(1,'Admin','Admin','AdminUser','Test@123',1,1,0,GETDATE(),null,null)
DECLARE @ORG_ID INT
SET @ORG_ID = @@IDENTITY
 		   
INSERT INTO Location ([Name], OrganizationId, CreatedDt) VALUES('Plano',@ORG_ID,GETDATE())
INSERT INTO Location ([Name], OrganizationId, CreatedDt) VALUES('Frisco',@ORG_ID,GETDATE())
INSERT INTO Location ([Name], OrganizationId, CreatedDt) VALUES('Haltom City',@ORG_ID,GETDATE())

INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('United States' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Uraguay' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Canada' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Mexico' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Russia' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('France' ,1 ,1 ,GETDATE())
INSERT INTO [dbo].[Country] ([Name] ,[Active] ,[CreatedBy] ,[CreatedDt]) VALUES('Nepal' ,1 ,1 ,GETDATE())
GO