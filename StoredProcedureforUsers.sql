CREATE PROCEDURE MasterInsertUpdateDelete
(
    @userid         INTEGER,
    @username  VARCHAR(50),
    @useremail  VARCHAR(50),
    @userpassword     VARCHAR(50),    
    @StatementType nvarchar(20) = ''
)
 
AS
BEGIN
IF @StatementType = 'Insert'
BEGIN
insert into Users (userid,username,userpassword,useremail) values( @userid, @username,  @userpassword,  @useremail)   
END
 
IF @StatementType = 'Select'
BEGIN
select * from Users
END 

IF @StatementType='SelectByID'
BEGIN
select * from Users where userid=@userid
END
 
IF @StatementType = 'Update'
BEGIN
UPDATE Users SET
            username =  @username, useremail = @useremail, userpassword = @userpassword
          
      WHERE userid = @userid
END
 
else IF @StatementType = 'Delete'
BEGIN
DELETE FROM Users WHERE userid = @userid
END
end
GO