If not exists(SELECT 1 FROM EMPLOYEE WHERE UserName='Admin')
 begin
 INSERT INTO Employee VALUES('Admin','Admin','AdminUser','Test@123',1,1,'Admin',GETDATE(),null,null)
 
 print 'Admin is added successfully.'
 end
 
 select * from Employee

 if not exists(SELECT 1 FROM Location)
 BEGIN
  INSERT INTO Location VALUES('Plano',null,null,null,null,null,null,1,1,GETDATE())
  INSERT INTO Location VALUES('Frisco',null,null,null,null,null,null,1,1,GETDATE())
  INSERT INTO Location VALUES('Haltom City',null,null,null,null,null,null,1,1,GETDATE())
 END
 
 if not exists(SELECT 1 FROM VolunteerInfo)
 begin
 INSERT INTO VolunteerInfo (FirstName,
LastName,UserName,CreatedBy,CreatedDt)
SELECT 'Test','User','TestUser',1,GETDATE()
 end
 