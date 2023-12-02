CREATE PROCEDURE [dbo].[spUsers_Create]
	@UserName NVARCHAR(50),
	@PassWord NVARCHAR(50),
	@Name NVARCHAR(50),
	@City NVARCHAR(50),
	@Email NVARCHAR(50),
	@PhoneNumber NVARCHAR(50),
	@Role NVARCHAR(50),
    @Id INT output
	
AS
BEGIN
    set nocount on;

    insert into dbo.[Users] (UserName, [PassWord], [Name], [City], Email, PhoneNumber,
    [Role])
	
    values(@UserName, @PassWord, @Name, @City, @Email, @PhoneNumber,
    @Role);

    set @Id = SCOPE_IDENTITY();

	select [Id], [UserName], [PassWord], [Name], [City], [Email], [PhoneNumber], [Role]
	from dbo.Users
	where Id = @Id;
END
