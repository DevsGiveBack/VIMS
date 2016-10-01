
IF OBJECT_ID (N'Employee', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Employee
  PRINT 'Employee table dropped successfully'
END

CREATE TABLE Employee(
	EmployeeId BIGINT IDENTITY(1,1) NOT NULL, 
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	UserName VARCHAR(50) NOT NULL,
	[Password] VARCHAR(400) NOT NULL,
	IsAdmin BIT NOT NULL,
	ActiveInd BIT NOT NULL,
	CreatedBy VARCHAR(50) NOT NULL,
	CreatedDt DATETIME NOT NULL,
	UpdatedBy VARCHAR(50) NULL,
	UpdatedDt DATETIME NULL,
	PRIMARY KEY(EmployeeId),
	CONSTRAINT uc_UserName UNIQUE (UserName)
)

PRINT 'Employee table has been created successfully'


IF OBJECT_ID (N'Country', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Country
  PRINT 'Country dropped successfully'
END

CREATE TABLE Country(
	CountryId SMALLINT IDENTITY(1,1) NOT NULL, 
	CountryName VARCHAR(100),	
	ActiveInd BIT,	
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),
	CreatedDt DATETIME,
	PRIMARY KEY(CountryId)
	)

PRINT 'Country table has been created successfully'



IF OBJECT_ID (N'State', N'U') IS NOT NULL 
BEGIN
  DROP TABLE State
  PRINT 'State dropped successfully'
END

CREATE TABLE State(
	StateId SMALLINT IDENTITY(1,1) NOT NULL, 
	StateName VARCHAR(100),
	CountryId SMALLINT FOREIGN KEY REFERENCES Country(CountryId),
	ActiveInd BIT,	
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),
	CreatedDt DATETIME,
	PRIMARY KEY(StateId)
	)

PRINT 'State has been created successfully'




IF OBJECT_ID (N'Location', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Location
  PRINT 'Location dropped successfully'
END

CREATE TABLE Location(
	LocationId INT IDENTITY(1,1) NOT NULL, 
	LocationName VARCHAR(100),
	Address1 VARCHAR(50),
	Address2 VARCHAR(50),
	StateId SMALLINT FOREIGN KEY REFERENCES State(StateId),
	CountryId SMALLINT FOREIGN KEY REFERENCES Country(CountryId),
	ZipCode VARCHAR(10),
	Notes VARCHAR(250),
	ActiveInd BIT,
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),
	CreatedDt DATETIME,
	PRIMARY KEY(LocationId)
	)

PRINT 'Location has been created successfully'


IF OBJECT_ID (N'Organization', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Organization
  PRINT 'Organization dropped successfully'
END

CREATE TABLE Organization(
	OrganizationId INT IDENTITY(1,1) NOT NULL, 
	OrganizationName VARCHAR(100),	
	ActiveInd BIT,
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),
	CreatedDt DATETIME,
	UpdatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),
	UpdatedDt DATETIME
	PRIMARY KEY(OrganizationId)
	)

PRINT 'Organization has been created successfully.'





IF OBJECT_ID (N'VolunteerInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerInfo
  PRINT 'VolunteerInfo dropped successfully'
END

CREATE TABLE VolunteerInfo(
	VolunteerId BIGINT IDENTITY(1,1) NOT NULL, 
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address1 VARCHAR(50),
	Address2 VARCHAR(50),
	City VARCHAR(50),
	StateId SMALLINT NULL references State(StateId),
	ZipCode VARCHAR(10),
	PhoneNumber VARCHAR(12),
	PhoneNumberType SMALLINT,
	Email VARCHAR(75),
	DOB DATETIME,
	Emrgncy_Cntct_Name VARCHAR(100),
	Emrgncy_Cntct_Phn VARCHAR(12),	
	CreatedBy VARCHAR(50) NOT NULL,
	CreatedDt DATETIME NOT NULL,
	UpdatedBy VARCHAR(50) NULL,
	UpdatedDt DATETIME NULL,
	PRIMARY KEY(VolunteerId)
)

PRINT 'VolunteerInfo has been created successfully'


IF OBJECT_ID (N'VolunteerProfileInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerProfileInfo
  PRINT 'VolunteerProfileInfo dropped successfully'
END

CREATE TABLE VolunteerProfileInfo(
	VolunteerProfileId BIGINT IDENTITY(1,1) NOT NULL, 
	VolunteerId BIGINT FOREIGN KEY REFERENCES VolunteerInfo(VolunteerId),
	OrganizationId INT NULL FOREIGN KEY REFERENCES Organization(OrganizationId),
	CaseNumber VARCHAR(50) NOT NULL,	
	Volunteer_Hours_Needed SMALLINT,
	Skill VARCHAR(50) NULL,
	MedicalInfo VARCHAR(200),
	Felony_Cnvctn BIT NOT NULL,
	Sexual_Abuse_Related BIT NOT NULL,
	Recv_Email BIT NOT NULL,
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),
	CreatedDt DATETIME,
	UpdatedBy VARCHAR(50) NULL,
	UpdatedDt DATETIME NULL,
	PRIMARY KEY(VolunteerProfileId)
	)
	
PRINT 'VolunteerProfileInfo has been created successfully'


IF OBJECT_ID (N'VolunteerProfilePhotoInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerProfilePhotoInfo
  PRINT 'VolunteerProfilePhotoInfo dropped successfully'
END

CREATE TABLE VolunteerProfilePhotoInfo(
	VolunteerProfilePhotoId BIGINT IDENTITY(1,1) NOT NULL, 
	VolunteerId BIGINT FOREIGN KEY REFERENCES VolunteerInfo(VolunteerId),
	VolunteerProfilePhotoPath SMALLINT,  --FOREIGN KEY
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EMPLOYEEID),	
	CreatedDt DATETIME
	PRIMARY KEY(VolunteerProfilePhotoId)
	)

PRINT 'VolunteerProfilePhotoInfo has been created successfully'


IF OBJECT_ID (N'VolunteerClockInOutInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerClockInOutInfo
  PRINT 'VolunteerClockInOutInfo dropped successfully'
END

CREATE TABLE VolunteerClockInOutInfo(
	VolunteerClockInOutId BIGINT IDENTITY(1,1) NOT NULL, 
	VolunteerId BIGINT FOREIGN KEY REFERENCES VolunteerInfo(VolunteerId),
	VolunteerProfileId BIGINT FOREIGN KEY REFERENCES VolunteerProfileInfo(VolunteerProfileId),  --FOREIGN KEY
	ClockInDateTime DATETIME NULL,
	ClockOutDateTime DATETIME NULL,
	ClockInOutLocationId INT FOREIGN KEY REFERENCES Location(LocationId),
	CreatedBy BIGINT FOREIGN KEY REFERENCES Employee(EmployeeId),	
	CreatedDt DATETIME
	PRIMARY KEY(VolunteerClockInOutId)
	)

PRINT 'VolunteerProfilePhotoInfo has been created successfully'





