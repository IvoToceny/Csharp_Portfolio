﻿CREATE TABLE [dbo].[Services]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UserId] INT NOT NULL,
	CONSTRAINT FK_Service_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
	[OrderDate] DATETIME2 NOT NULL,
	[ServiceDay] DATETIME2 NOT NULL,
	[ServiceTime] NVARCHAR(50) NOT NULL, 
	[ServiceFinishEstimate] DATETIME2 NOT NULL, 
	[ServiceDescription] NVARCHAR(400) NULL,
	[CarId] INT NOT NULL,
	CONSTRAINT FK_Service_CarId FOREIGN KEY (CarId) REFERENCES Cars(Id),
	[StateOfOrder] NVARCHAR(50) NOT NULL
)
