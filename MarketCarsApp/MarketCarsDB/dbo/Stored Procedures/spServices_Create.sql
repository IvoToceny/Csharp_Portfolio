CREATE PROCEDURE [dbo].[spServices_Create]
	@UserId INT NOT NULL,
	@OrderDate DATETIME2 NOT NULL,
	@ServiceDay DATETIME2 NOT NULL,
	@ServiceTime NVARCHAR(50) NOT NULL, 
	@ServiceFinishEstimate DATETIME2 NOT NULL, 
	@ServiceDescription NVARCHAR(400) NULL,
	@CarId INT NOT NULL,
	@StateOfOrder NVARCHAR(50) NOT NULL,
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
