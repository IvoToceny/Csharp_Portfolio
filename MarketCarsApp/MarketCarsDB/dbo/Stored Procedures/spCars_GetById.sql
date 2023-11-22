CREATE PROCEDURE [dbo].[spCars_GetById]
	@Id INT
AS
BEGIN
	set nocount on;

	select [Id], [OwnerId], [ForSale], [Name], [Manufacturer], [Bodywork], [Color],
		[EngineType], [HorsePower], [Mileage], [CarState], [Price]
	from dbo.Cars
	where Id = @Id;
END
