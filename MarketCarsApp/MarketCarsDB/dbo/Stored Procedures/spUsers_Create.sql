CREATE PROCEDURE [dbo].[spUsers_Create]
	@UserName NVARCHAR(50) NOT NULL,
	@PassWord NVARCHAR(50) NOT NULL,
	@Name NVARCHAR(50) NOT NULL,
	@Address NVARCHAR(50) NULL,
	@Email NVARCHAR(50) NOT NULL,
	@PhoneNumber NVARCHAR(50) NULL,
	@Role NVARCHAR(50) NOT NULL,
    @Id INT output
	
AS
BEGIN
    set nocount on;

    insert into dbo.[Users] (UserName, [PassWord], [Name], [Address], Email, PhoneNumber,
    [Role])
	
    values(@UserName, @PassWord, @Name, @Address, @Email, @PhoneNumber,
    @Role);

    set @Id = SCOPE_IDENTITY();
END
