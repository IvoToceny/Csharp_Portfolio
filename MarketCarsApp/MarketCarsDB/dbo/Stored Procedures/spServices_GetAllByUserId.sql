CREATE PROCEDURE [dbo].[spServices_GetAllByUserId]
	@UserId NVARCHAR(100)
AS
BEGIN
	set nocount on;

	SELECT * from dbo.[Services] where UserId = @UserId;
END
