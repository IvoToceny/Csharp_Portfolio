CREATE PROCEDURE [dbo].[spServices_Create]
	@OrderDate DATETIME2,
	@ServiceDay DATETIME2,
	@ServiceTime NVARCHAR(50), 
	@ServiceFinishEstimate DATETIME2, 
	@ServiceDescription NVARCHAR(400) NULL,
	@CarId INT,
	@StateOfOrder NVARCHAR(50),
	@Id INT output
AS
BEGIN
	set nocount on;

	INSERT into dbo.[Services]([OrderDate], [ServiceDay], [ServiceTime], [ServiceFinishEstimate], 
	[ServiceDescription], [CarId], [StateOfOrder])
	values(@OrderDate, @ServiceDay, @ServiceTime, @ServiceFinishEstimate, 
	@ServiceDescription, @CarId, @StateOfOrder);

	set @Id = SCOPE_IDENTITY();
END
