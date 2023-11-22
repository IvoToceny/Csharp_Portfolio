CREATE PROCEDURE [dbo].[spCars_DeleteById]
	@Id INT
AS
BEGIN
    set nocount on;

    DELETE from dbo.Cars where Id = @Id;
END
