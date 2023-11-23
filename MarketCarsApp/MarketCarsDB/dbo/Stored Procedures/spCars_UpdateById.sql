CREATE PROCEDURE [dbo].[spCars_UpdateById]
	@Id INT,
	@ForSale BIT,
	@Name NVARCHAR(100),
	@Manufacturer NVARCHAR(50),
	@Bodywork NVARCHAR(20),
	@Color NVARCHAR(20),
	@EngineType NVARCHAR(50),
	@HorsePower NVARCHAR(20),
	@Mileage NVARCHAR(50),
	@CarState NVARCHAR(20),
	@Price NVARCHAR(20)
AS
BEGIN
	set nocount on;

	update dbo.Cars set [ForSale] = @ForSale, [Name] = @Name, [Manufacturer] = @Manufacturer,
		[Bodywork] = @Bodywork, [Color] = @Color, [EngineType] = @EngineType,
		[HorsePower] = @HorsePower, [Mileage] = @Mileage,
		[CarState] = @CarState, [Price] = @Price
	where Id = @Id;

	select [Id], [OwnerId], [ForSale], [Name], [Manufacturer], [Bodywork], [Color],
		[EngineType], [HorsePower], [Mileage], [CarState], [Price]
	from dbo.Cars
	where Id = @Id;
END
