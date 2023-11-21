CREATE PROCEDURE [dbo].[spUsers_GetUserById]
	@Id INT NOT NULL
AS
BEGIN
	set nocount on;

	select [Id], [UserName], [PassWord], [Name], [Address], [Email], [PhoneNumber], [Role]
	from dbo.Users
	where Id = @Id;
END
