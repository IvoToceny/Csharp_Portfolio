CREATE PROCEDURE [dbo].[spUsers_UpdateById]
	@Id INT,
	@UserName NVARCHAR(50),
	@PassWord NVARCHAR(50),
	@Name NVARCHAR(50),
	@Address NVARCHAR(50),
	@Email NVARCHAR(50),
	@PhoneNumber NVARCHAR(50)
AS
BEGIN
	set nocount on;

	update dbo.Users set [UserName] = @UserName, [PassWord] = @PassWord, 
	[Name] = @Name, [Address] = @Address,
	[Email] = @Email, [PhoneNumber] = @PhoneNumber
	where Id = @Id
END
