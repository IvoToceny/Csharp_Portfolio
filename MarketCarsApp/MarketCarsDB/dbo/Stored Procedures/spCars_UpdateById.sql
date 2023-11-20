CREATE PROCEDURE [dbo].[spCars_UpdateById]
	@Id INT NOT NULL,
	@Name NVARCHAR(100) NOT NULL,
	@Manufacturer NVARCHAR(50) NOT NULL,
	@Bodywork NVARCHAR(20) NOT NULL,
	@Color NVARCHAR(20) NOT NULL,
	@EngineType NVARCHAR(50) NULL,
	@HorsePower NVARCHAR(20) NULL,
	@Mileage INT NOT NULL,
	@CarState NVARCHAR(20) NULL,
	@Price MONEY NULL
AS
BEGIN
	set nocount on;

	update dbo.Cars set [Name] = @Name, [Manufacturer] = @Manufacturer,
		[Bodywork] = @Bodywork, [Color] = @Color, [EngineType] = @EngineType,
		[HorsePower] = @HorsePower, [Mileage] = @Mileage,
		[CarState] = @CarState, [Price] = @Price
	where Id = @Id
END
