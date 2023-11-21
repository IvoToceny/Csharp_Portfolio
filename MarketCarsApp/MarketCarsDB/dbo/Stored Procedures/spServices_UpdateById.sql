CREATE PROCEDURE [dbo].[spServices_UpdateStateById]
	@Id INT NOT NULL,
	@OrderDate DATETIME2 NOT NULL,
	@ServiceDay DATETIME2 NOT NULL,
	@ServiceTime NVARCHAR(50) NOT NULL, 
	@ServiceFinishEstimate DATETIME2 NOT NULL, 
	@ServiceDescription NVARCHAR(400) NULL,
	@StateOfOrder NVARCHAR(50) NOT NULL
AS
BEGIN
	set nocount on;

	update dbo.[Services] set [OrderDate] = @OrderDate, [ServiceDay] = @ServiceDay,
		[ServiceTime] = @ServiceTime, [ServiceFinishEstimate] = @ServiceFinishEstimate,
		[ServiceDescription] = @ServiceDescription, [StateOfOrder] = @StateOfOrder
	where Id = @Id
END