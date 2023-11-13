CREATE TABLE [dbo].[Services]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] INT,
	CONSTRAINT FK_Service_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
	[OrderDate] DATETIME2,
	[ServiceDay] DATETIME2,
	[ServiceTime] NVARCHAR(50), 
	[ServiceFinishEstimate] DATETIME2, 
	[ServiceDescription] NVARCHAR(400) NULL,
	[CarId] INT,
	CONSTRAINT FK_Service_CarId FOREIGN KEY (CarId) REFERENCES Cars(Id),
	[StateOfOrder] NVARCHAR(50),
)
