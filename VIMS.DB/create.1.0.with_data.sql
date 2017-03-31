USE [VIMS]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/30/2017 10:57:32 AM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 3/30/2017 10:57:33 AM ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 3/30/2017 10:57:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](100) NULL,
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
/****** Object:  Table [dbo].[Organization]    Script Date: 3/30/2017 10:57:33 AM ******/
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
/****** Object:  Table [dbo].[State]    Script Date: 3/30/2017 10:57:33 AM ******/
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
/****** Object:  Table [dbo].[VolunteerClockInOutInfo]    Script Date: 3/30/2017 10:57:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerClockInOutInfo](
	[VolunteerClockInOutId] [bigint] IDENTITY(1,1) NOT NULL,
	[VolunteerId] [bigint] NULL,
	[VolunteerProfileId] [bigint] NULL,
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
/****** Object:  Table [dbo].[VolunteerInfo]    Script Date: 3/30/2017 10:57:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VolunteerInfo](
	[VolunteerId] [bigint] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[VolunteerProfileInfo]    Script Date: 3/30/2017 10:57:33 AM ******/
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
/****** Object:  Table [dbo].[VolunteerProfilePhotoInfo]    Script Date: 3/30/2017 10:57:33 AM ******/
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
ALTER TABLE [dbo].[Country]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[VolunteerClockInOutInfo]  WITH CHECK ADD FOREIGN KEY([VolunteerProfileId])
REFERENCES [dbo].[VolunteerProfileInfo] ([VolunteerProfileId])
GO
ALTER TABLE [dbo].[VolunteerClockInOutInfo]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[VolunteerInfo] ([VolunteerId])
GO
ALTER TABLE [dbo].[VolunteerInfo]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[VolunteerProfileInfo]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[VolunteerProfileInfo]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[VolunteerProfileInfo]  WITH CHECK ADD FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO
ALTER TABLE [dbo].[VolunteerProfileInfo]  WITH CHECK ADD FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO
ALTER TABLE [dbo].[VolunteerProfileInfo]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[VolunteerInfo] ([VolunteerId])
GO
ALTER TABLE [dbo].[VolunteerProfileInfo]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[VolunteerInfo] ([VolunteerId])
GO
ALTER TABLE [dbo].[VolunteerProfilePhotoInfo]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[VolunteerProfilePhotoInfo]  WITH CHECK ADD FOREIGN KEY([VolunteerId])
REFERENCES [dbo].[VolunteerInfo] ([VolunteerId])
GO

/* seed data */
INSERT INTO Employee VALUES('Admin','Admin','AdminUser','Test@123',1,1,'Admin',GETDATE(),null,null)
INSERT INTO Location VALUES('Plano',null,null,null,null,null,null,1,1,GETDATE())
INSERT INTO Location VALUES('Frisco',null,null,null,null,null,null,1,1,GETDATE())
INSERT INTO Location VALUES('Haltom City',null,null,null,null,null,null,1,1,GETDATE())
INSERT INTO [dbo].[Country] ([CountryName] ,[ActiveInd] ,[CreatedBy] ,[CreatedDt]) VALUES('United States' ,1 ,1 ,'03/29/2017')

INSERT INTO State([StateName],[ActiveInd],[CreatedBy],[CreatedDt]) VALUES('Alabama','1','1','03/01/2017'),('Alaska','1','1','03/01/2017'),('Arizona','1','1','03/01/2017'),('Arkansas','1','1','03/01/2017'),('California','1','1','03/01/2017'),('Colorado','1','1','03/01/2017'),('Connecticut','1','1','03/01/2017'),('Delaware','1','1','03/01/2017'),('District of Columbia','1','1','03/01/2017'),('Florida','1','1','03/01/2017'),('Georgia','1','1','03/01/2017'),('Hawaii','1','1','03/01/2017'),('Idaho','1','1','03/01/2017'),('Illinois','1','1','03/01/2017'),('Indiana','1','1','03/01/2017'),('Iowa','1','1','03/01/2017'),('Kansas','1','1','03/01/2017'),('Kentucky','1','1','03/01/2017'),('Louisiana','1','1','03/01/2017'),('Maine','1','1','03/01/2017'),('Maryland','1','1','03/01/2017'),('Massachusetts','1','1','03/01/2017'),('Michigan','1','1','03/01/2017'),('Minnesota','1','1','03/01/2017'),('Mississippi','1','1','03/01/2017'),('Missouri','1','1','03/01/2017'),('Montana','1','1','03/01/2017'),('Nebraska','1','1','03/01/2017'),('Nevada','1','1','03/01/2017'),('New Hampshire','1','1','03/01/2017'),('New Jersey','1','1','03/01/2017'),('New Mexico','1','1','03/01/2017'),('New York','1','1','03/01/2017'),('North Carolina','1','1','03/01/2017'),('North Dakota','1','1','03/01/2017'),('Ohio','1','1','03/01/2017'),('Oklahoma','1','1','03/01/2017'),('Oregon','1','1','03/01/2017'),('Pennsylvania','1','1','03/01/2017'),('Rhode Island','1','1','03/01/2017'),('South Carolina','1','1','03/01/2017'),('South Dakota','1','1','03/01/2017'),('Tennessee','1','1','03/01/2017'),('Texas','1','1','03/01/2017'),('Utah','1','1','03/01/2017'),('Vermont','1','1','03/01/2017'),('Virginia','1','1','03/01/2017'),('Washington','1','1','03/01/2017'),('West Virginia','1','1','03/01/2017'),('Wisconsin','1','1','03/01/2017');

INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Cleo','Cash','cleo.cash','7323',1,0,'Patrick Valentine','04/18/2014',''),('Berk','Serrano','berk.serrano','2222',1,0,'Simone Wood','06/08/2012',''),('Asher','Moran','asher.moran','9912',1,1,'Donna Kelley','11/29/2011',''),('Katelyn','Hardin','katelyn.hardin','7668',0,1,'Amber Mcgee','11/02/2007',''),('Florence','Mclaughlin','florence.mclaughlin','4830',1,1,'Hakeem Kirk','11/22/2015',''),('Andrew','Martinez','andrew.martinez','0452',1,1,'Zephr Roach','03/03/2011',''),('Neville','Velasquez','neville.velasquez','7711',1,0,'Aurelia Barr','04/16/2004',''),('September','Mejia','september.mejia','6681',0,1,'Genevieve Crawford','10/08/2014',''),('Bert','Silva','bert.silva','2248',1,0,'Jonah Tate','12/19/2008',''),('Fulton','Morgan','fulton.morgan','0485',1,0,'Xerxes Camacho','02/11/2012','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Cadman','Fitzpatrick','cadman.fitzpatrick','3930',0,1,'Ava Beasley','04/04/2014',''),('David','Cameron','david.cameron','6214',1,0,'Kimberly Burch','11/08/2000',''),('Malachi','Humphrey','malachi.humphrey','5336',1,0,'Kane Chapman','03/23/2003',''),('Buffy','Gutierrez','buffy.gutierrez','0027',0,1,'Stacey Waters','02/19/2003',''),('Chase','Nunez','chase.nunez','5355',0,0,'Delilah Prince','09/09/2003',''),('Todd','Burt','todd.burt','7328',1,1,'Mufutau Richard','10/07/2009',''),('Travis','Hull','travis.hull','5317',1,1,'Kyra Benson','12/11/2014',''),('Hedley','James','hedley.james','6338',1,1,'Jorden Osborne','05/10/2001',''),('Denise','Bentley','denise.bentley','3785',0,0,'Asher Hart','10/06/2009',''),('Jaden','Daugherty','jaden.daugherty','5748',0,1,'Amela Mcbride','04/27/2005','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Xanthus','Cooper','xanthus.cooper','8809',1,0,'Bertha Mcleod','08/09/2005',''),('Delilah','Harvey','delilah.harvey','3624',1,0,'Dennis Frye','01/21/2011',''),('Theodore','Mcguire','theodore.mcguire','1743',1,1,'Channing Hines','06/02/2006',''),('Xantha','Bender','xantha.bender','5538',1,1,'Anjolie Glenn','12/06/2014',''),('Selma','Summers','selma.summers','4411',1,0,'Jaime Kane','07/02/2015',''),('Kiayada','Mcgee','kiayada.mcgee','8416',1,1,'Maxwell Kennedy','12/25/2008',''),('Fleur','Sharpe','fleur.sharpe','2721',1,0,'Tad Mann','12/25/2009',''),('Tate','Ayala','tate.ayala','0617',1,0,'Heather Ford','01/16/2001',''),('Basia','Rodriguez','basia.rodriguez','1280',0,0,'David Barr','07/12/2014',''),('Kieran','Torres','kieran.torres','2627',0,0,'Maggie Small','12/03/2009','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Edan','Hickman','edan.hickman','6838',0,0,'Carla Dotson','12/28/2003',''),('Signe','Quinn','signe.quinn','4745',1,1,'Hayden Knight','07/05/2012',''),('Minerva','Velez','minerva.velez','0011',1,1,'Octavia Nicholson','09/15/2005',''),('Madison','Carson','madison.carson','9411',0,1,'Mercedes Mckinney','02/19/2013',''),('Leonard','Mcdonald','leonard.mcdonald','9642',0,0,'Zachery Wallace','08/08/2013',''),('Hu','Sargent','hu.sargent','4326',0,0,'Savannah Vang','06/26/2001',''),('Kennan','Woodward','kennan.woodward','5647',0,0,'Kato Woods','09/25/2004',''),('Dustin','Vaughan','dustin.vaughan','6865',0,1,'Elizabeth Kelley','06/07/2001',''),('Rhonda','Weaver','rhonda.weaver','8514',1,1,'Madeline Cobb','04/29/2014',''),('Leila','Knight','leila.knight','9235',0,0,'Ira Melendez','06/15/2005','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Dane','Hester','dane.hester','7719',0,1,'Vaughan York','07/12/2006',''),('Damon','Lopez','damon.lopez','1843',1,0,'Iris Hansen','06/25/2013',''),('Samuel','Kemp','samuel.kemp','6415',1,0,'Caryn Reese','07/01/2004',''),('Dieter','Alexander','dieter.alexander','1743',1,0,'Dennis Black','01/18/2013',''),('Ross','Curtis','ross.curtis','3300',0,1,'Kaden Boone','09/26/2000',''),('Audrey','Stanton','audrey.stanton','3857',1,1,'Pascale Bright','09/06/2013',''),('Diana','Sheppard','diana.sheppard','6394',1,1,'Deirdre Schmidt','10/20/2003',''),('Delilah','Burke','delilah.burke','6058',0,1,'Maryam Rocha','10/03/2003',''),('Linus','Wilson','linus.wilson','6802',1,1,'Cara Anderson','04/27/2012',''),('Kessie','Morris','kessie.morris','3113',0,1,'Howard Boyer','11/11/2007','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Hiram','Foster','hiram.foster','4670',0,0,'Carson Pacheco','12/05/2005',''),('Marsden','Schmidt','marsden.schmidt','4034',1,0,'Acton Ware','08/03/2014',''),('Meredith','Horton','meredith.horton','1865',0,1,'Ezekiel Saunders','02/12/2012',''),('Jordan','Fry','jordan.fry','2776',0,0,'TaShya Spears','12/28/2005',''),('Kamal','Valenzuela','kamal.valenzuela','0565',1,0,'Quyn Hardin','12/04/2012',''),('Merritt','Madden','merritt.madden','2488',0,0,'Hu Zimmerman','12/26/2012',''),('Deacon','Vargas','deacon.vargas','4246',0,0,'Jocelyn Hansen','09/10/2008',''),('Ezra','Raymond','ezra.raymond','5792',1,0,'Whoopi Lester','11/11/2013',''),('Shafira','Hatfield','shafira.hatfield','2291',1,0,'Yuri Mcleod','10/19/2015',''),('Octavia','Mcleod','octavia.mcleod','7260',0,0,'Angela James','07/28/2006','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Amy','Love','amy.love','1065',1,0,'Austin Walls','03/19/2015',''),('Alana','Dudley','alana.dudley','3528',0,0,'Colby Cochran','09/18/2012',''),('Uma','Randall','uma.randall','7708',0,0,'Xanthus Pollard','08/31/2007',''),('Karleigh','Rivera','karleigh.rivera','2132',1,1,'Ayanna Silva','05/05/2002',''),('Iris','Witt','iris.witt','6760',1,1,'Chastity Cortez','12/07/2006',''),('Jenna','Patton','jenna.patton','9222',0,1,'Maris Mercado','04/05/2002',''),('Wylie','Kemp','wylie.kemp','9030',0,1,'Jared Middleton','03/26/2003',''),('Audrey','Cummings','audrey.cummings','7161',0,0,'Chaim Romero','10/09/2014',''),('Caldwell','Juarez','caldwell.juarez','7162',0,0,'Austin Everett','09/14/2008',''),('Velma','Mccall','velma.mccall','9015',1,1,'Sonya Ayers','06/14/2007','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Clarke','Ellis','clarke.ellis','9161',0,1,'Fay Pace','09/05/2003',''),('Prescott','Carney','prescott.carney','3233',0,0,'Beck Dominguez','10/27/2007',''),('Jada','Petersen','jada.petersen','5001',0,0,'Sandra York','10/22/2009',''),('Marcia','Hunter','marcia.hunter','1248',1,1,'Sade Chambers','11/22/2006',''),('Salvador','Pearson','salvador.pearson','8459',1,0,'Ulric Roman','10/03/2006',''),('Elijah','Howe','elijah.howe','4689',1,1,'William Black','04/13/2004',''),('Autumn','Garza','autumn.garza','9705',0,0,'Salvador Hodges','09/08/2003',''),('Galvin','Mendoza','galvin.mendoza','6838',0,0,'Lucas Santana','04/28/2015',''),('Nell','Blanchard','nell.blanchard','5575',1,1,'Drew Downs','05/10/2015',''),('Jena','Pratt','jena.pratt','5233',1,0,'Mara Herrera','09/18/2000','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Edward','Baxter','edward.baxter','2714',1,0,'Richard Humphrey','11/09/2012',''),('Olga','Mcclure','olga.mcclure','9112',1,1,'Jared Griffin','02/10/2011',''),('Perry','Soto','perry.soto','0171',0,1,'Benedict Bartlett','03/09/2014',''),('Griffith','Freeman','griffith.freeman','1053',0,1,'Elaine Black','12/05/2005',''),('Dorothy','Harmon','dorothy.harmon','6926',0,1,'Hall Mercer','04/09/2010',''),('Cade','Carey','cade.carey','4947',1,1,'Driscoll Walters','01/18/2006',''),('Lucas','Vaughn','lucas.vaughn','3208',1,0,'Leonard Huber','08/27/2000',''),('Macon','Parrish','macon.parrish','6695',0,1,'Shannon Berry','07/03/2011',''),('Owen','Cherry','owen.cherry','1683',0,1,'Nelle Casey','05/24/2011',''),('Griffith','Medina','griffith.medina','0852',0,1,'Miriam Hammond','11/02/2003','');
INSERT INTO Employee([FirstName],[LastName],[UserName],[Password],[IsAdmin],[ActiveInd],[CreatedBy],[CreatedDt],[UpdatedDt]) VALUES('Helen','Hobbs','helen.hobbs','7031',0,0,'Ariel Bright','07/21/2013',''),('Zenia','Rollins','zenia.rollins','6324',1,1,'Mona Tate','12/24/2008',''),('Bruno','Mcneil','bruno.mcneil','1102',1,0,'Ferris Copeland','06/05/2002',''),('Wyatt','Serrano','wyatt.serrano','0111',1,0,'Stacy Leon','03/08/2011',''),('Halee','Sullivan','halee.sullivan','5567',1,0,'Blair Herman','11/10/2004',''),('Lance','Clemons','lance.clemons','3908',0,1,'Nayda Cole','12/12/2009',''),('Colette','Bridges','colette.bridges','0619',0,1,'Anne Savage','10/08/2007',''),('Remedios','Bullock','remedios.bullock','2341',0,0,'Angela Wells','02/12/2006',''),('Adria','Gould','adria.gould','1343',1,0,'Nash Schwartz','02/21/2015',''),('Jack','Curry','jack.curry','7701',0,0,'Minerva Harper','12/04/2004','');

INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Clayton','Mclean','clayton.mclean','06/06/2017','Hunter Jennings','9777 Facilisis, Rd.','9777 Facilisis, Rd.','Dordrecht','O5 7IC','936-939-2791',5,'luctus.felis.purus@metusVivamus.edu','09/13/2006','Marny Mathews','003-415-2514','06/06/2017','Hunter Jennings'),('Quyn','Booth','quyn.booth','11/06/2016','Stuart Tran','539-2616 Sem St.','539-2616 Sem St.','Grand Island','95078','189-846-5314',5,'arcu@nunc.net','05/31/1965','Sigourney Joseph','209-091-8384','11/06/2016','Stuart Tran'),('Hedley','Burke','hedley.burke','09/14/2016','Todd Gregory','783-6514 Cursus Ave','783-6514 Cursus Ave','Ch‰tillon','44313','425-471-7700',3,'pede.et.risus@interdumlibero.edu','01/10/1975','Isaiah Dillon','926-545-5553','09/14/2016','Todd Gregory'),('Cain','Sanford','cain.sanford','01/28/2018','MacKenzie Raymond','P.O. Box 570, 9356 Ornare, Rd.','P.O. Box 570, 9356 Ornare, Rd.','Rapagnano','84512','273-813-9597',3,'placerat@feugiattelluslorem.ca','09/29/2009','Shana Gilmore','518-799-8883','01/28/2018','MacKenzie Raymond'),('Jordan','Riddle','jordan.riddle','02/09/2017','Emerson Park','884-4185 Id Rd.','884-4185 Id Rd.','Yellowknife','205328','173-541-1501',2,'Donec.est@In.com','07/31/1979','Anthony Durham','433-809-3493','02/09/2017','Emerson Park'),('Chiquita','Arnold','chiquita.arnold','06/28/2017','Marshall Larsen','Ap #356-8226 Nisl. Street','Ap #356-8226 Nisl. Street','Germersheim','50042','758-273-4749',4,'Integer.mollis.Integer@tortor.com','05/30/2001','Jescie Cotton','397-892-9771','06/28/2017','Marshall Larsen'),('Dai','Rutledge','dai.rutledge','09/21/2017','Colin Wagner','5956 Metus Rd.','5956 Metus Rd.','Nicoya','65632','750-134-0986',4,'malesuada.fringilla.est@egestasAliquamfringilla.com','07/31/1978','Lester Jenkins','697-253-3308','09/21/2017','Colin Wagner'),('Isaac','Sullivan','isaac.sullivan','01/07/2018','Ashton Richmond','Ap #659-9353 Non, Avenue','Ap #659-9353 Non, Avenue','Goiânia','18-083','739-448-5432',1,'Sed@Curabiturvel.org','10/03/2017','Berk Singleton','375-871-3710','01/07/2018','Ashton Richmond'),('Chandler','Barlow','chandler.barlow','08/28/2017','Sydney Petty','Ap #141-4021 Duis Av.','Ap #141-4021 Duis Av.','Jodhpur','57486','969-558-3252',3,'Integer@duiFusce.com','04/02/1992','Neville Navarro','967-936-8973','08/28/2017','Sydney Petty'),('Joshua','Gross','joshua.gross','08/09/2016','Nola Mullen','P.O. Box 527, 1211 Morbi Rd.','P.O. Box 527, 1211 Morbi Rd.','Huesca','354321','221-500-4261',5,'nulla.vulputate.dui@magnaDuis.edu','11/07/1974','Sopoline Stark','611-683-3277','08/09/2016','Nola Mullen');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Roanna','Sears','roanna.sears','05/08/2017','Fleur Gilbert','280-4697 Morbi Rd.','280-4697 Morbi Rd.','Prince George','10606','766-671-9738',5,'justo.faucibus.lectus@Curabitur.org','02/23/2015','Quemby Gallagher','721-723-6350','05/08/2017','Fleur Gilbert'),('Nehru','Delgado','nehru.delgado','04/22/2016','Justina Woods','P.O. Box 662, 9926 Enim. Rd.','P.O. Box 662, 9926 Enim. Rd.','Llangollen','63147','128-044-2003',1,'elementum@Donec.co.uk','12/10/2010','Fay Boyle','863-370-5527','04/22/2016','Justina Woods'),('Clio','Winters','clio.winters','11/09/2016','Winter Palmer','8017 Senectus Av.','8017 Senectus Av.','Renfrew','36440','724-739-1408',1,'eget.metus@Donec.org','12/31/1986','Charles Miranda','662-448-9301','11/09/2016','Winter Palmer'),('Debra','Wise','debra.wise','12/06/2016','Macey Guerrero','437-2729 Libero Ave','437-2729 Libero Ave','Missoula','65481','810-980-6111',4,'et.magnis.dis@sagittisplaceratCras.co.uk','02/25/1973','Nero Sherman','440-990-9050','12/06/2016','Macey Guerrero'),('Hunter','Graves','hunter.graves','09/27/2016','Nehru Sandoval','Ap #579-5130 Risus. Av.','Ap #579-5130 Risus. Av.','Hamburg','41776-893','051-680-2221',1,'vitae.odio@auctor.co.uk','04/10/1976','India Hopkins','988-360-0314','09/27/2016','Nehru Sandoval'),('Arthur','Shields','arthur.shields','02/28/2018','Cameron Oneil','Ap #326-109 Non, St.','Ap #326-109 Non, St.','Zwickau','458155','144-390-5740',3,'eleifend.Cras@inmolestie.com','06/28/1965','Henry Soto','560-836-3713','02/28/2018','Cameron Oneil'),('Ivory','Aguirre','ivory.aguirre','06/20/2016','Brady Bartlett','P.O. Box 737, 7518 Nisi Av.','P.O. Box 737, 7518 Nisi Av.','Wiesbaden','25712','964-373-9773',5,'mollis.nec.cursus@Phasellusat.com','04/04/1965','Conan Snider','547-795-7604','06/20/2016','Brady Bartlett'),('Jayme','Giles','jayme.giles','04/12/2017','Medge Dejesus','9281 Placerat Rd.','9281 Placerat Rd.','Breton','67020','615-921-7093',2,'Cum.sociis.natoque@erat.co.uk','01/17/2006','Phyllis Stein','866-954-9781','04/12/2017','Medge Dejesus'),('Charlotte','White','charlotte.white','10/29/2017','Jarrod Chen','6888 Consequat Road','6888 Consequat Road','Staßfurt','502534','306-560-3401',2,'eu@dictum.org','10/09/1984','Tara Ramos','975-676-7294','10/29/2017','Jarrod Chen'),('Oren','Jordan','oren.jordan','11/06/2017','Ivor Gordon','8930 Consectetuer Street','8930 Consectetuer Street','San Pancrazio Salentino','5434','145-227-6086',3,'lobortis@penatibus.edu','11/29/1969','Doris Frye','662-716-2785','11/06/2017','Ivor Gordon');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Conan','Fitzgerald','conan.fitzgerald','05/03/2017','Constance Parsons','Ap #465-9482 Cursus. Ave','Ap #465-9482 Cursus. Ave','Futaleufú','91067-439','789-937-9479',2,'ut@vitae.com','03/07/2000','Elijah Villarreal','679-680-6064','05/03/2017','Constance Parsons'),('Connor','Burnett','connor.burnett','03/15/2017','Zena Hancock','P.O. Box 733, 8114 Vivamus Street','P.O. Box 733, 8114 Vivamus Street','Châtellerault','8166','821-540-3502',1,'tincidunt@rutrumnon.com','06/18/1972','Nadine Collins','494-244-3940','03/15/2017','Zena Hancock'),('Petra','Buchanan','petra.buchanan','12/09/2016','Darryl Ramirez','Ap #778-4332 Posuere Avenue','Ap #778-4332 Posuere Avenue','Caplan','KD2 9AW','937-863-9200',1,'Praesent@mattisCras.net','01/31/1973','Simone Crane','082-713-1316','12/09/2016','Darryl Ramirez'),('Ivor','Bean','ivor.bean','03/12/2017','Virginia Pennington','327-6955 Donec Road','327-6955 Donec Road','Balvano','885626','197-376-6336',2,'nec@pellentesqueSed.co.uk','02/01/1982','Teagan Aguirre','318-045-9176','03/12/2017','Virginia Pennington'),('Alec','Pate','alec.pate','11/13/2016','Isaiah Hendrix','Ap #621-2868 Augue, Av.','Ap #621-2868 Augue, Av.','Eghezee','8447LR','443-334-6017',5,'magna.malesuada.vel@nibhlacinia.com','10/29/1997','Forrest Brown','679-609-0450','11/13/2016','Isaiah Hendrix'),('Isaiah','Goodman','isaiah.goodman','09/15/2016','Nadine Garrett','283-6067 Sed Av.','283-6067 Sed Av.','Melle','8213','824-499-6634',3,'Nulla.aliquet.Proin@placeratvelitQuisque.net','09/01/1985','Kibo Dunlap','756-065-2681','09/15/2016','Nadine Garrett'),('Caleb','Black','caleb.black','06/04/2017','Jacob Abbott','P.O. Box 312, 5020 Sociis Road','P.O. Box 312, 5020 Sociis Road','Mandasor','489688','333-657-0058',4,'Cras@Inornaresagittis.com','05/25/2010','Kay Wiggins','534-020-6705','06/04/2017','Jacob Abbott'),('Kiona','Navarro','kiona.navarro','05/01/2017','Rosalyn Gomez','P.O. Box 450, 6953 Hendrerit St.','P.O. Box 450, 6953 Hendrerit St.','Akola','K7H 2W5','176-890-2286',1,'Nam.ac@nunc.edu','01/16/2015','Dieter Dorsey','419-685-3118','05/01/2017','Rosalyn Gomez'),('Anjolie','Morgan','anjolie.morgan','09/06/2017','Francis Castaneda','P.O. Box 112, 3534 Odio. Ave','P.O. Box 112, 3534 Odio. Ave','Ceuta','07707','360-584-8330',2,'sem@tellus.co.uk','03/30/1965','Sylvia Pearson','037-747-3215','09/06/2017','Francis Castaneda'),('Rose','Dickerson','rose.dickerson','08/25/2016','Baxter Roberson','Ap #268-7227 Arcu. Ave','Ap #268-7227 Arcu. Ave','Quillón','3972','179-899-3119',1,'Quisque.tincidunt.pede@turpis.ca','08/11/1994','Whoopi Lowe','517-017-7667','08/25/2016','Baxter Roberson');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Quail','Craig','quail.craig','02/16/2018','Imani Reese','Ap #938-4593 Lorem Road','Ap #938-4593 Lorem Road','Auckland','60225','623-788-7209',1,'erat@nequetellusimperdiet.net','01/14/1978','Vance Hayes','271-311-9750','02/16/2018','Imani Reese'),('Kermit','Barnes','kermit.barnes','03/02/2018','Lane Lindsay','Ap #522-4348 Tincidunt, Rd.','Ap #522-4348 Tincidunt, Rd.','Hamburg','725776','513-280-0738',4,'purus@NulladignissimMaecenas.edu','09/27/1982','Shannon Greer','444-931-0437','03/02/2018','Lane Lindsay'),('Akeem','Kidd','akeem.kidd','08/26/2017','Octavia Grant','Ap #740-9640 Placerat, Avenue','Ap #740-9640 Placerat, Avenue','Pontarlier','90958','666-983-3208',3,'pede.malesuada@idnunc.ca','05/09/1972','Mason Gillespie','357-211-9287','08/26/2017','Octavia Grant'),('Harriet','Cunningham','harriet.cunningham','07/23/2016','Ulla Hoffman','629-9229 Integer Avenue','629-9229 Integer Avenue','Ottawa-Carleton','775568','374-400-9113',2,'nec@laciniaorci.ca','03/02/2013','Camden Rowe','452-125-9151','07/23/2016','Ulla Hoffman'),('Jorden','Hubbard','jorden.hubbard','07/04/2017','Kaitlin Robertson','442-6663 Sed St.','442-6663 Sed St.','Picton','07888','136-066-6791',2,'luctus.et.ultrices@risus.edu','07/03/2005','Patience Bryan','590-423-9424','07/04/2017','Kaitlin Robertson'),('Christen','Barry','christen.barry','03/07/2018','Halee Acevedo','418 Magna. St.','418 Magna. St.','Chastre-Villeroux-Blanmont','78079','110-808-7662',4,'arcu.Morbi.sit@Nullam.edu','02/08/2013','Kane Bartlett','071-061-5476','03/07/2018','Halee Acevedo'),('Joy','Camacho','joy.camacho','06/08/2016','Amela Bonner','P.O. Box 770, 5730 Sed St.','P.O. Box 770, 5730 Sed St.','Vlimmeren','08606-576','059-346-8290',4,'ullamcorper.viverra@Class.org','02/22/2006','Sawyer Sampson','405-656-5667','06/08/2016','Amela Bonner'),('Kaseem','Charles','kaseem.charles','06/24/2016','Maggie Jackson','608-5430 Lectus. St.','608-5430 Lectus. St.','Ceyhan','97358','342-261-0783',1,'et.eros@Proin.com','06/06/2002','Derek Dillon','103-117-1744','06/24/2016','Maggie Jackson'),('Keefe','Herring','keefe.herring','12/22/2017','Wade Harper','932-7569 Amet Av.','932-7569 Amet Av.','Cochin','3564','392-107-3030',4,'Curabitur.egestas@posuerecubilia.ca','02/13/2014','Miranda Buckner','633-119-7043','12/22/2017','Wade Harper'),('Nayda','Luna','nayda.luna','03/11/2018','Dennis Graham','Ap #698-1829 Molestie Rd.','Ap #698-1829 Molestie Rd.','Muno','932776','817-006-4095',5,'erat@sedturpis.co.uk','10/21/1973','Ima Trevino','190-765-6924','03/11/2018','Dennis Graham');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Cain','Savage','cain.savage','07/18/2017','Iona Mcdowell','Ap #209-6419 Duis Rd.','Ap #209-6419 Duis Rd.','Napier','1414GV','753-059-4764',4,'consectetuer@mauris.ca','09/15/1981','Murphy Mcintosh','708-094-2955','07/18/2017','Iona Mcdowell'),('Lewis','Hopkins','lewis.hopkins','04/11/2016','Callum Clay','P.O. Box 493, 4579 Sed St.','P.O. Box 493, 4579 Sed St.','Houtave','6522','177-070-9559',2,'eu.neque@nislarcuiaculis.org','11/16/1979','Trevor Schneider','879-034-3497','04/11/2016','Callum Clay'),('Vivien','Michael','vivien.michael','07/15/2016','Sophia Turner','6642 Interdum. Ave','6642 Interdum. Ave','Patiala','T8X 6S2','062-948-5758',4,'natoque.penatibus.et@Quisque.com','03/06/1987','Illiana Bruce','607-198-9211','07/15/2016','Sophia Turner'),('Norman','Peck','norman.peck','03/11/2018','Harper Kane','178-7801 Fames Road','178-7801 Fames Road','Hollogne-sur-Geer','84190','583-170-3783',2,'dis.parturient.montes@morbi.co.uk','02/24/1983','Hope Conrad','411-484-9807','03/11/2018','Harper Kane'),('Leonard','Berger','leonard.berger','05/31/2017','Jesse Mcclure','P.O. Box 791, 4168 Vulputate Street','P.O. Box 791, 4168 Vulputate Street','Chandler','93835','420-364-5466',3,'Nam@metusIn.ca','11/02/1985','Igor Collins','851-055-0230','05/31/2017','Jesse Mcclure'),('Latifah','Stephenson','latifah.stephenson','07/25/2017','Dolan Howell','P.O. Box 657, 182 Ac Avenue','P.O. Box 657, 182 Ac Avenue','Perquenco','74995','862-294-3310',2,'dictum.Phasellus.in@Craslorem.org','11/14/2017','Carissa Yates','017-814-2169','07/25/2017','Dolan Howell'),('Dennis','Forbes','dennis.forbes','12/06/2016','Zenia Lewis','6748 Mattis. St.','6748 Mattis. St.','Jhelum','9497ZB','826-985-4755',4,'blandit.congue.In@gravida.edu','08/05/1980','Willow Gordon','672-647-0864','12/06/2016','Zenia Lewis'),('Unity','Baldwin','unity.baldwin','05/09/2016','Maite Barton','904-3710 Phasellus Avenue','904-3710 Phasellus Avenue','Vihari','45176','345-779-7012',1,'Sed.id.risus@nequeInornare.ca','02/29/2008','Odysseus Golden','936-731-3749','05/09/2016','Maite Barton'),('Clare','Graham','clare.graham','03/08/2017','Rogan Le','Ap #694-364 Tempor Road','Ap #694-364 Tempor Road','Bridgeport','1680','024-001-9174',5,'ornare@et.com','11/18/1975','Lynn Barr','907-061-5177','03/08/2017','Rogan Le'),('Wendy','Ferguson','wendy.ferguson','05/01/2016','Steel Wheeler','Ap #778-9077 Sed, Avenue','Ap #778-9077 Sed, Avenue','Montbéliard','34505','395-675-4867',5,'enim.condimentum@utodio.org','10/22/1983','Priscilla Cash','675-724-7964','05/01/2016','Steel Wheeler');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('James','Wade','james.wade','05/22/2017','Quyn Day','P.O. Box 184, 4589 Neque. Rd.','P.O. Box 184, 4589 Neque. Rd.','Millet','39285','712-155-3333',4,'sollicitudin.adipiscing@euturpisNulla.net','05/28/1974','Cara Oconnor','965-407-1531','05/22/2017','Quyn Day'),('Amanda','Watts','amanda.watts','11/06/2017','Burton Griffith','Ap #443-4626 Mus. Ave','Ap #443-4626 Mus. Ave','Villa Santo Stefano','01834','338-522-7647',3,'adipiscing@lectuspede.net','07/22/2005','Adam Lloyd','193-073-7366','11/06/2017','Burton Griffith'),('Audra','Hancock','audra.hancock','01/03/2018','Cain Wilder','9457 Faucibus Avenue','9457 Faucibus Avenue','Płock','4067','108-815-5981',2,'est.congue.a@diam.ca','03/20/2004','Ruth Marshall','902-663-5295','01/03/2018','Cain Wilder'),('Breanna','Workman','breanna.workman','08/14/2017','Walter Sparks','P.O. Box 604, 2070 Lorem Street','P.O. Box 604, 2070 Lorem Street','Offenburg','29978','679-883-7891',3,'cubilia.Curae@interdum.edu','03/08/1996','Ulric Scott','588-781-1667','08/14/2017','Walter Sparks'),('Jamalia','Morgan','jamalia.morgan','03/06/2017','Zachary Burnett','457-4831 Amet Rd.','457-4831 Amet Rd.','Appleby','32515-396','942-147-5771',1,'nisi@sitamet.co.uk','09/04/2012','Rashad Bolton','371-996-5052','03/06/2017','Zachary Burnett'),('Eric','Sloan','eric.sloan','05/20/2017','Caesar Cherry','Ap #749-2264 Et, Av.','Ap #749-2264 Et, Av.','Gojra','0295DF','108-672-2951',2,'blandit@ac.org','08/19/1999','Emmanuel Salinas','857-710-3502','05/20/2017','Caesar Cherry'),('Vance','Melendez','vance.melendez','07/27/2017','Karleigh Pollard','Ap #715-1232 Vitae Avenue','Ap #715-1232 Vitae Avenue','San Giovanni Lipioni','55776','915-775-2416',3,'velit@vitaeodio.ca','10/26/1965','Regan Velez','188-347-0742','07/27/2017','Karleigh Pollard'),('Jelani','Acosta','jelani.acosta','03/03/2017','Lucius Conley','1198 Eu Rd.','1198 Eu Rd.','Greater Sudbury','91737-098','456-363-5398',2,'Donec.at@faucibus.ca','05/07/1976','Chanda Roman','808-367-9676','03/03/2017','Lucius Conley'),('Nyssa','Molina','nyssa.molina','05/06/2016','Kelly Guerrero','Ap #308-287 Ante Street','Ap #308-287 Ante Street','Fayetteville','02362','153-964-0385',5,'metus.Vivamus.euismod@rhoncusProinnisl.com','12/24/1996','Ralph Chambers','177-578-2895','05/06/2016','Kelly Guerrero'),('Oprah','Waters','oprah.waters','04/27/2017','Dieter Brock','Ap #861-3695 Vitae Avenue','Ap #861-3695 Vitae Avenue','Calvi Risorta','0774LW','226-164-5060',1,'molestie.tellus@Inlorem.com','11/21/2015','Lenore Allison','286-718-3237','04/27/2017','Dieter Brock');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Felix','Frank','felix.frank','10/22/2017','Uriah Conley','Ap #407-7716 Nullam Road','Ap #407-7716 Nullam Road','Lustin','40128','748-709-3992',3,'luctus.et@Nullam.org','11/14/1965','Hakeem Underwood','433-236-3452','10/22/2017','Uriah Conley'),('Elizabeth','Mooney','elizabeth.mooney','05/26/2017','Aurelia Rojas','1365 Et Road','1365 Et Road','Şereflikoçhisar','97275-498','860-515-1916',5,'metus@adipiscinglacusUt.ca','03/09/1980','MacKenzie Brewer','015-344-3591','05/26/2017','Aurelia Rojas'),('Mariko','Bush','mariko.bush','10/20/2016','Athena Lara','6642 Neque. Ave','6642 Neque. Ave','Bossut-Gottechain','39423-701','465-790-3557',3,'sem.Pellentesque@et.ca','08/19/2016','Rashad Ramirez','918-625-5934','10/20/2016','Athena Lara'),('Clark','Owens','clark.owens','08/26/2016','Ira Dale','1779 Justo. Rd.','1779 Justo. Rd.','Nuraminis','OY9 8BY','806-227-4161',1,'tristique@semperNamtempor.com','06/20/1986','Kasper Church','077-086-9575','08/26/2016','Ira Dale'),('Mufutau','Carson','mufutau.carson','09/04/2016','Troy Phillips','171-9331 Pede Road','171-9331 Pede Road','Oteppe','70467','907-849-0091',4,'enim.Suspendisse.aliquet@eu.org','01/25/1967','Sandra Jarvis','548-503-7718','09/04/2016','Troy Phillips'),('Colette','Wooten','colette.wooten','03/06/2017','Cameran Gallagher','Ap #435-2154 Eros. St.','Ap #435-2154 Eros. St.','Yumbel','31670-241','133-366-2402',4,'Aenean.eget.metus@Nuncac.ca','11/28/1966','Tobias Workman','378-254-2498','03/06/2017','Cameran Gallagher'),('Imani','Browning','imani.browning','08/25/2016','Kirsten Kaufman','P.O. Box 970, 2394 Volutpat. St.','P.O. Box 970, 2394 Volutpat. St.','Kent','428708','691-446-4321',4,'Aliquam.nisl.Nulla@vestibulumMauris.ca','08/05/2010','Ryder Ware','682-577-4444','08/25/2016','Kirsten Kaufman'),('Kristen','Porter','kristen.porter','04/17/2017','Clio Tate','P.O. Box 195, 3949 Nec St.','P.O. Box 195, 3949 Nec St.','Vollezele','2577','525-085-8843',4,'magna.Praesent@risus.net','09/16/2004','Christen Santana','196-410-6656','04/17/2017','Clio Tate'),('Kiayada','Barber','kiayada.barber','02/12/2017','Ryder Vinson','5623 Suspendisse Street','5623 Suspendisse Street','Weert','695314','067-414-0742',4,'vitae@elitCurabitur.co.uk','10/10/2011','TaShya Gordon','711-589-4534','02/12/2017','Ryder Vinson'),('Clarke','Case','clarke.case','12/20/2017','Erica Clemons','1116 Scelerisque Street','1116 Scelerisque Street','Levallois-Perret','48030','393-322-9238',4,'nonummy@vitae.org','05/04/2008','Amena Mcdonald','947-469-4243','12/20/2017','Erica Clemons');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Harding','Herrera','harding.herrera','03/30/2016','Olivia Velez','P.O. Box 223, 2604 Vestibulum Rd.','P.O. Box 223, 2604 Vestibulum Rd.','Kanpur','56043','962-024-1669',3,'tellus.faucibus.leo@malesuadafamesac.edu','11/16/1967','Caryn Kramer','759-638-6482','03/30/2016','Olivia Velez'),('Brynn','Warren','brynn.warren','04/28/2016','Shelby Tanner','587-4837 Odio Street','587-4837 Odio Street','Notre-Dame-de-la-Salette','59830','674-485-2549',2,'nunc.id@elementumsemvitae.org','06/12/1977','Summer Aguirre','684-809-8755','04/28/2016','Shelby Tanner'),('Mari','Mays','mari.mays','03/14/2018','Burton Marshall','286-9275 Lorem Avenue','286-9275 Lorem Avenue','Mulchén','5079MU','530-254-9611',5,'sit@sed.com','07/23/2011','Tyler Maddox','171-206-4791','03/14/2018','Burton Marshall'),('Lois','Barnes','lois.barnes','09/02/2016','Dora Pugh','474-7961 Donec Road','474-7961 Donec Road','Windsor','738045','509-337-5175',3,'Curae@lobortisquispede.edu','01/17/1997','Walker Odonnell','534-585-9525','09/02/2016','Dora Pugh'),('Edan','Avila','edan.avila','05/05/2017','Avye Harris','5951 Diam. St.','5951 Diam. St.','Jabbeke','777611','313-032-5223',5,'Donec.nibh@aaliquetvel.com','07/06/2009','Cameron Gibson','734-047-2833','05/05/2017','Avye Harris'),('Ocean','Ellis','ocean.ellis','09/15/2017','Reuben Alvarez','191-7150 Sagittis Ave','191-7150 Sagittis Ave','Township of Minden Hills','50218','386-580-2968',5,'cursus.et@egetlaoreet.com','09/28/1965','Malik Hubbard','175-732-0113','09/15/2017','Reuben Alvarez'),('Kaseem','Santana','kaseem.santana','10/23/2017','Cara Hayes','P.O. Box 974, 7137 Semper Av.','P.O. Box 974, 7137 Semper Av.','Cerchio','4325','852-168-0253',2,'sed@acmetusvitae.net','07/15/2014','Jemima Carr','410-538-2336','10/23/2017','Cara Hayes'),('Aidan','Hood','aidan.hood','10/22/2017','Abra Delgado','746-1459 Libero. Ave','746-1459 Libero. Ave','Cariboo Regional District','0967ZA','637-168-9107',5,'malesuada.fames@etlaciniavitae.ca','12/14/2005','Ulla Warner','033-425-4744','10/22/2017','Abra Delgado'),('Stephen','Osborne','stephen.osborne','07/06/2017','Maite Burton','9105 Fusce Avenue','9105 Fusce Avenue','Rio Marina','490895','435-251-2174',3,'Vestibulum.ut.eros@consequat.ca','03/23/1974','Maisie Dale','035-216-2120','07/06/2017','Maite Burton'),('Rebekah','Workman','rebekah.workman','06/02/2017','Winter Valencia','Ap #247-4598 Dolor. Rd.','Ap #247-4598 Dolor. Rd.','Carcassonne','891687','157-068-2533',5,'ac.metus@Aliquameratvolutpat.co.uk','01/19/2016','Colin Richards','331-269-8096','06/02/2017','Winter Valencia');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Laith','Boone','laith.boone','05/26/2017','Rachel Diaz','P.O. Box 908, 9602 Imperdiet Ave','P.O. Box 908, 9602 Imperdiet Ave','Leganés','6167','475-883-2911',4,'lectus.quis@arcuacorci.net','08/18/1983','Rae Wooten','092-103-2509','05/26/2017','Rachel Diaz'),('Signe','Acevedo','signe.acevedo','10/26/2016','Karleigh Franks','9425 In Ave','9425 In Ave','Cisano Bergamasco','0164','321-620-0478',5,'pede@dapibusgravidaAliquam.edu','03/23/1972','Ocean Mcgowan','806-619-7879','10/26/2016','Karleigh Franks'),('Faith','Delaney','faith.delaney','02/01/2017','Adele Hoffman','321 Vestibulum Avenue','321 Vestibulum Avenue','Quispamsis','53851','248-732-3633',2,'porttitor@vehiculaPellentesque.net','06/11/2009','Riley Arnold','869-036-6610','02/01/2017','Adele Hoffman'),('Laith','Simpson','laith.simpson','08/17/2017','Acton Coffey','206-3749 Suspendisse St.','206-3749 Suspendisse St.','Nemoli','632349','258-117-6244',1,'morbi@tinciduntadipiscing.edu','06/05/2007','Hayes Sharp','897-315-8015','08/17/2017','Acton Coffey'),('Juliet','Ballard','juliet.ballard','04/19/2017','Ciaran Rowland','Ap #550-8526 Condimentum St.','Ap #550-8526 Condimentum St.','Altavilla Irpina','03310','580-007-6972',3,'dolor.Fusce.feugiat@Cumsociis.net','11/23/1987','Fletcher Shaffer','664-277-9267','04/19/2017','Ciaran Rowland'),('Guy','Pierce','guy.pierce','04/17/2016','Isadora Burks','1765 Quisque St.','1765 Quisque St.','Hornsea','3971','857-283-5129',5,'aliquet@intempuseu.edu','09/21/2005','Ian Martin','342-922-0684','04/17/2016','Isadora Burks'),('Wallace','Butler','wallace.butler','04/30/2017','Jane Merrill','Ap #935-2223 Parturient Avenue','Ap #935-2223 Parturient Avenue','Joncret','531926','908-155-3876',4,'metus.sit@eleifend.net','10/13/1975','Kevyn Mccormick','405-381-5249','04/30/2017','Jane Merrill'),('Denise','Larsen','denise.larsen','09/09/2016','Hall Gilmore','2811 Elit. Rd.','2811 Elit. Rd.','Wekweti','3361','744-735-3478',2,'Nulla.eu.neque@facilisisvitaeorci.co.uk','01/11/1991','Ryan Moreno','460-565-2275','09/09/2016','Hall Gilmore'),('Sydney','Parker','sydney.parker','06/12/2017','Jin Griffin','P.O. Box 519, 4376 Sapien. Ave','P.O. Box 519, 4376 Sapien. Ave','Vlezenbeek','4023','735-088-7415',4,'commodo@ornare.co.uk','04/19/1997','Fritz Hebert','062-575-9701','06/12/2017','Jin Griffin'),('Beatrice','Morgan','beatrice.morgan','04/30/2016','Abdul Stone','278-5007 Et St.','278-5007 Et St.','Siliguri','11712','564-152-2832',4,'libero@nuncnulla.org','01/03/1981','Kelly Fields','981-807-5848','04/30/2016','Abdul Stone');
INSERT INTO VolunteerInfo([FirstName],[LastName],[UserName],[CreatedDt],[CreatedBy],[Address1],[Address2],[City],[ZipCode],[PhoneNumber],[PhoneNumberType],[Email],[DOB],[Emrgncy_Cntct_Name],[Emrgncy_Cntct_Phn],[UpdatedDt],[UpdatedBy]) VALUES('Carla','Stout','carla.stout','04/10/2016','Dorothy Pope','Ap #855-3794 Imperdiet, Road','Ap #855-3794 Imperdiet, Road','Curicó','74188','325-685-2200',4,'Mauris.molestie.pharetra@Donec.org','02/26/1988','Dora Villarreal','067-474-6900','04/10/2016','Dorothy Pope'),('Zephr','Cooke','zephr.cooke','06/13/2016','Kaden Schneider','177-1210 Odio Rd.','177-1210 Odio Rd.','Hody','5517','198-079-5807',1,'Suspendisse@fermentum.edu','10/12/2008','Shad Benton','459-912-5829','06/13/2016','Kaden Schneider'),('Yasir','Hampton','yasir.hampton','05/16/2016','Ciara Cross','Ap #354-3092 Ut Ave','Ap #354-3092 Ut Ave','Neu-Isenburg','73742-208','997-714-4326',2,'Aenean.massa.Integer@litoratorquent.edu','08/26/2006','Jonah Dorsey','589-066-9988','05/16/2016','Ciara Cross'),('Joshua','Gonzales','joshua.gonzales','10/14/2017','Tara Lawson','Ap #456-3243 Mollis. St.','Ap #456-3243 Mollis. St.','Saint-Rhémy-en-Bosses','63-112','720-824-7485',5,'sit.amet.dapibus@rutrum.com','11/18/1983','Jerome Atkinson','025-093-5030','10/14/2017','Tara Lawson'),('Cole','Soto','cole.soto','06/18/2016','Donna Walls','3347 Suspendisse Av.','3347 Suspendisse Av.','Flin Flon','7681','727-480-8137',2,'Aenean.euismod@at.ca','11/13/2000','Kyla Rodriguez','497-293-4342','06/18/2016','Donna Walls'),('Sigourney','Nguyen','sigourney.nguyen','06/15/2016','Jael Trujillo','2925 Mauris Rd.','2925 Mauris Rd.','Leugnies','MM2D 0AM','262-937-5152',4,'montes.nascetur@tortor.org','12/15/2003','Marny House','880-929-2705','06/15/2016','Jael Trujillo'),('Ishmael','Carroll','ishmael.carroll','04/05/2017','Dai Kerr','P.O. Box 977, 6179 Lacus. Street','P.O. Box 977, 6179 Lacus. Street','Chambord','81950','724-234-4930',1,'Curabitur.ut@ante.edu','03/19/1969','Hilary Mcneil','505-507-1684','04/05/2017','Dai Kerr'),('Juliet','Yates','juliet.yates','03/15/2018','Venus Daniel','Ap #537-7281 Est, Av.','Ap #537-7281 Est, Av.','Golspie','8198','715-421-9946',2,'consequat@enim.co.uk','03/04/2003','Kyle Macias','663-204-0822','03/15/2018','Venus Daniel'),('Abraham','Williamson','abraham.williamson','08/26/2016','Brooke Pugh','738-5170 Velit. Road','738-5170 Velit. Road','Rzeszów','91118','761-711-2674',1,'quam.dignissim.pharetra@elitpellentesque.edu','06/11/1969','Stella Coffey','181-506-2210','08/26/2016','Brooke Pugh'),('Yoshi','Hood','yoshi.hood','10/07/2016','Clinton Roberson','203-2307 Donec Rd.','203-2307 Donec Rd.','Heule','K4C 6B3','768-643-0155',1,'Curae.Donec@eutellusPhasellus.co.uk','07/28/1998','Tyrone Suarez','013-751-7633','10/07/2016','Clinton Roberson');

INSERT INTO [dbo].[VolunteerProfileInfo]
           ([VolunteerId]
           ,[CaseNumber]
           ,[Volunteer_Hours_Needed]
           ,[Skill]
           ,[WorkInfo]
           ,[Felony_Cnvctn]
           ,[Sexual_Abuse_Related]
           ,[Recv_Email]
           ,[CreatedDt]
           ,[UpdatedBy]
           ,[UpdatedDt])
     VALUES
           (@@IDENTITY
           ,'ABC123'
           ,200
           ,'None'
           ,'Unemployed'
           ,0
           ,0
           ,1
           ,GETDATE() 
           ,'Bob Dylan'
           ,GETDATE())
