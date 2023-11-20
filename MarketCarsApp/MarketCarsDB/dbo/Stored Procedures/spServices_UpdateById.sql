CREATE PROCEDURE [dbo].[spServices_UpdateStateById]
	@Id INT NOT NULL,
	@OrderDate DATETIME2,
	@ServiceDay DATETIME2,
	@ServiceTime NVARCHAR(50), 
	@ServiceFinishEstimate DATETIME2, 
	@ServiceDescription NVARCHAR(400) NULL,
	@StateOfOrder NVARCHAR(50)
AS
BEGIN
	set nocount on;

	update dbo.[Services] set [OrderDate] = @OrderDate, [ServiceDay] = @ServiceDay,
		[ServiceTime] = @ServiceTime, [ServiceFinishEstimate] = @ServiceFinishEstimate,
		[ServiceDescription] = @ServiceDescription, [StateOfOrder] = @StateOfOrder
	where Id = @Id
END