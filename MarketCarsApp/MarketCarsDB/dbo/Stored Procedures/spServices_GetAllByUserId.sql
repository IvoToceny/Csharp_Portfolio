﻿CREATE PROCEDURE [dbo].[spServices_GetAllByUserId]
	@UserId INT NOT NULL
AS
BEGIN
	set nocount on;

	SELECT * from dbo.[Services] where UserId = @UserId;
END