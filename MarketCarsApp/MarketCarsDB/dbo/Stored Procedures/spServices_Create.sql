CREATE PROCEDURE [dbo].[spServices_Create]
	@UserId NVARCHAR(100),
	@OrderDate DATETIME2,
	@ServiceDay DATETIME2,
	@ServiceTime NVARCHAR(50), 
	@ServiceFinishEstimate DATETIME2, 
	@ServiceDescription NVARCHAR(400),
	@CarId INT,
	@StateOfOrder NVARCHAR(50),
	@Id INT output
AS
BEGIN
	set nocount on;

	INSERT into dbo.[Services]([UserId], [OrderDate], [ServiceDay], [ServiceTime], [ServiceFinishEstimate], 
	[ServiceDescription], [CarId], [StateOfOrder])
	values(@UserId, @OrderDate, @ServiceDay, @ServiceTime, @ServiceFinishEstimate, 
	@ServiceDescription, @CarId, @StateOfOrder);

	set @Id = SCOPE_IDENTITY();
END
