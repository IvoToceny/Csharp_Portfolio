CREATE PROCEDURE [dbo].[spCars_DeleteById]
	@Id INT NOT NULL
AS
BEGIN
    set nocount on;

    DELETE from dbo.Cars where Id = @Id;
END
