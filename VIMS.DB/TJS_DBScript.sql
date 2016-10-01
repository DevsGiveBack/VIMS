CREATE TABLE `tjs`.`tblemployee` (
  EmployeeId BigInt auto_increment
  FirstName varchar(50) not null,
  LastName varchar(50) not null,
  UserName varchar(50) not null,
  Emp_Password varchar(400) not null,
  IsAdmin bit not null,
  CreateBy varchar(100) not null,
  CreatedDt datetime not null,
  UpdatedBy varchar(100) null,
  UpdatedDt  datetime null,
  Primary Key(EmployeeId)
);

CREATE TABLE `tjs`.`tblvolunteerinfo` (
  VolunteerId bigint not null auto_increment,
  UserName varchar(100) not null unique key,
  FirstName varchar(50) not null,
  LastName varchar(50) not null,
  Address1 varchar(50) not null,
  Address2 varchar(50) not null,
  City varchar(50) null,
  State varchar(50) null,
  ZipCode varchar(10) null,
  PhoneNumber varchar(15) null,
  PhoneNumberType smallint null,
  Email varchar(100) null,
  DOB datetime not null,
  EmrgncyCntctName varchar(110) not null,
  EmrgncyCntctPhone varchar(15) null,
  CreatedBy bigint not null,
  CreatedDt datetime not null,
  UpdatedBy bigint null,
  UpdatedDt datetime null,
  primary key(VolunteerId)
);