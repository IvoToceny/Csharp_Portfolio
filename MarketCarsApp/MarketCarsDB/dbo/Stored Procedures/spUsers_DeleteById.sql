CREATE PROCEDURE [dbo].[spUsers_DeleteById]
	@Id INT
AS
BEGIN
    set nocount on;

    DELETE from dbo.Users where Id = @Id;
END
