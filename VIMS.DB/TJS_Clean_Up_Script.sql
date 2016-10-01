--Clean Up Script
IF OBJECT_ID (N'VolunteerClockInOutInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerClockInOutInfo
  PRINT 'VolunteerClockInOutInfo dropped successfully'
END

IF OBJECT_ID (N'VolunteerProfilePhotoInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerProfilePhotoInfo
  PRINT 'VolunteerProfilePhotoInfo dropped successfully'
END

IF OBJECT_ID (N'VolunteerProfileInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerProfileInfo
  PRINT 'VolunteerProfileInfo dropped successfully'
END

IF OBJECT_ID (N'VolunteerInfo', N'U') IS NOT NULL 
BEGIN
  DROP TABLE VolunteerInfo
  PRINT 'VolunteerInfo dropped successfully'
END

IF OBJECT_ID (N'Organization', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Organization
  PRINT 'Organization dropped successfully'
END

IF OBJECT_ID (N'Location', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Location
  PRINT 'Location dropped successfully'
END

IF OBJECT_ID (N'State', N'U') IS NOT NULL 
BEGIN
  DROP TABLE State
  PRINT 'State dropped successfully'
END

IF OBJECT_ID (N'Country', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Country
  PRINT 'Country dropped successfully'
END

IF OBJECT_ID (N'Employee', N'U') IS NOT NULL 
BEGIN
  DROP TABLE Employee
  PRINT 'Employee table dropped successfully'
END