CREATE PROCEDURE [dbo].[spCars_Create]
	@OwnerId INT,
	@ForSale BIT,
	@Name NVARCHAR(100),
	@Manufacturer NVARCHAR(50),
	@Bodywork NVARCHAR(20),
	@Color NVARCHAR(20),
	@EngineType NVARCHAR(50),
	@HorsePower NVARCHAR(20),
	@Mileage INT,
	@CarState NVARCHAR(20),
	@Price MONEY,
    @Id INT output
	
AS
BEGIN
    set nocount on;

    insert into dbo.[Cars] (OwnerId, ForSale, [Name], Manufacturer, Bodywork, Color, EngineType, HorsePower,
		Mileage, CarState, Price)
	
    values(@OwnerId, @ForSale, @Name, @Manufacturer, @Bodywork, @Color, @EngineType, @HorsePower,
		@Mileage, @CarState, @Price);

    set @Id = SCOPE_IDENTITY();
END
