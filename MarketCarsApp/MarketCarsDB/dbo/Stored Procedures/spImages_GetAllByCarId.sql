CREATE PROCEDURE [dbo].[spImages_GetAllByCarId]
	@CarId INT NOT NULL
AS
BEGIN
	set nocount on;

	SELECT [Id], [CarId], [Path], [IsHeadPhoto] from dbo.Images where CarId = @CarId;
END
