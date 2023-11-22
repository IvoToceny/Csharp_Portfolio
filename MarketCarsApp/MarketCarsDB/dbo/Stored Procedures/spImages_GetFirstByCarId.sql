CREATE PROCEDURE [dbo].[spImages_GetFirstByCarId]
	@CarId INT,
	@IsHeadPhoto BIT
AS
BEGIN
	set nocount on;

	SELECT [Id], [CarId], [Path] from dbo.Images where CarId = @CarId AND IsHeadPhoto = @IsHeadPhoto;
END
