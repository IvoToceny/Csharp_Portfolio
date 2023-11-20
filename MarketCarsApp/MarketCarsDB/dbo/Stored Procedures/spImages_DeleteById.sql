CREATE PROCEDURE [dbo].[spImages_DeleteByPath]
	@Id INT NOT NULL
AS
BEGIN
	set nocount on;

	DELETE from dbo.Images where Id = @Id;
END
