CREATE PROCEDURE [dbo].[spCars_Create]
	@OwnerId INT NOT NULL,
	@ForSale BIT NOT NULL,
	@Name NVARCHAR(100) NOT NULL,
	@Manufacturer NVARCHAR(50) NOT NULL,
	@Bodywork NVARCHAR(20) NOT NULL,
	@Color NVARCHAR(20) NOT NULL,
	@EngineType NVARCHAR(50) NULL,
	@HorsePower NVARCHAR(20) NULL,
	@Mileage INT NOT NULL,
	@CarState NVARCHAR(20) NULL,
	@Price MONEY NULL,
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
