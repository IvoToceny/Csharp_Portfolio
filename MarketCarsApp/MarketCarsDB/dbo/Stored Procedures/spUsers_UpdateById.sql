CREATE PROCEDURE [dbo].[spUsers_UpdateById]
	@Id INT,
	@UserName NVARCHAR(50),
	@PassWord NVARCHAR(50),
	@Name NVARCHAR(50),
	@City NVARCHAR(50),
	@Email NVARCHAR(50),
	@PhoneNumber NVARCHAR(50),
	@Role NVARCHAR(50)
AS
BEGIN
	set nocount on;

	update dbo.Users set [UserName] = @UserName, [PassWord] = @PassWord, 
	[Name] = @Name, [City] = @City,
	[Email] = @Email, [PhoneNumber] = @PhoneNumber, [Role] = @Role
	where Id = @Id;

	select [Id], [UserName], [PassWord], [Name], [City], [Email], [PhoneNumber], [Role]
	from dbo.Users
	where Id = @Id;
END
