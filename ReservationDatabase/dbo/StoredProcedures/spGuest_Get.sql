CREATE PROCEDURE [dbo].[spGuest_Get]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Guest]
	WHERE Id = @Id
END