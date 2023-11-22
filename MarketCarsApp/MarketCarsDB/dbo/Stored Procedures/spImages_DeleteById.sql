CREATE PROCEDURE [dbo].[spImages_DeleteById]
	@Id INT
AS
BEGIN
	set nocount on;

	DELETE from dbo.Images where Id = @Id;
END
