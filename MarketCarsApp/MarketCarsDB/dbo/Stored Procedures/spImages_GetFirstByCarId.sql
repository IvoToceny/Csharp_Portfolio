CREATE PROCEDURE [dbo].[spImages_GetFirstByCarId]
	@CarId INT NOT NULL,
	@IsHeadPhoto BIT NOT NULL
AS
BEGIN
	set nocount on;

	SELECT [Id], [CarId], [Path] from dbo.Images where CarId = @CarId AND IsHeadPhoto = @IsHeadPhoto;
END
