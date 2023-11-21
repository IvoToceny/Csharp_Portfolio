CREATE PROCEDURE [dbo].[spUsers_UpdateById]
	@Id INT NOT NULL,
	@UserName NVARCHAR(50) NOT NULL,
	@PassWord NVARCHAR(50) NOT NULL,
	@Name NVARCHAR(50) NOT NULL,
	@Address NVARCHAR(50) NULL,
	@Email NVARCHAR(50) NOT NULL,
	@PhoneNumber NVARCHAR(50) NULL
AS
BEGIN
	set nocount on;

	update dbo.Users set [UserName] = @UserName, [PassWord] = @PassWord, 
	[Name] = @Name, [Address] = @Address,
	[Email] = @Email, [PhoneNumber] = @PhoneNumber
	where Id = @Id
END
