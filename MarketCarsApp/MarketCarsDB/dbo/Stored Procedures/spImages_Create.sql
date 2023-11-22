CREATE PROCEDURE [dbo].[spImages_Create]
	@CarId INT,
	@Path NVARCHAR(100),
    @IsHeadPhoto BIT,
    @Id INT output
	
AS
BEGIN
    set nocount on;

    insert into dbo.[Images] ([CarId], [Path], [IsHeadPhoto])
	
    values(@CarId, @Path, @IsHeadPhoto);

    set @Id = SCOPE_IDENTITY();
END
