﻿CREATE PROCEDURE [dbo].[spCars_GetAllByUserAndCarId]
	@Id INT,
	@OwnerId NVARCHAR(100)
AS
BEGIN
	set nocount on;

	select [Id], [OwnerId], [ForSale], [Name], [Manufacturer], [Bodywork], [Color],
		[EngineType], [HorsePower], [Mileage], [CarState], [Price]
	from dbo.Cars
	where OwnerId = @OwnerId AND Id = @Id;
END
