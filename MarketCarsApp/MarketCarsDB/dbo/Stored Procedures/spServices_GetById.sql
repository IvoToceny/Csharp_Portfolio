CREATE PROCEDURE [dbo].[spServices_GetById]
	@Id INT NOT NULL
AS
BEGIN
	set nocount on;

	SELECT [Id], [UserId], [OrderDate], [ServiceDay], [ServiceTime], [ServiceFinishEstimate], 
	[ServiceDescription], [CarId], [StateOfOrder] 
	from dbo.[Services] 
	where Id = @Id;
END
