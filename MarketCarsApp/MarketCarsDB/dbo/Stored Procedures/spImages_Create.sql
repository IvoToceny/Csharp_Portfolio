CREATE PROCEDURE [dbo].[spImages_Create]
	@CarId INT NOT NULL,
	@Path NVARCHAR(100) NOT NULL,
    @IsHeadPhoto BIT NOT NULL,
    @Id INT output
	
AS
BEGIN
    set nocount on;

    insert into dbo.[Images] ([CarId], [Path], [IsHeadPhoto])
	
    values(@CarId, @Path, @IsHeadPhoto);

    set @Id = SCOPE_IDENTITY();
END
