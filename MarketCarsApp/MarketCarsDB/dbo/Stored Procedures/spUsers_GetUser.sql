CREATE PROCEDURE [dbo].[spUsers_GetUser]
AS
BEGIN
	set nocount on;

	select [Id], [UserName], [PassWord], [Name], [Address], [Email], [PhoneNumber], [Role]
	from dbo.Users;
END
