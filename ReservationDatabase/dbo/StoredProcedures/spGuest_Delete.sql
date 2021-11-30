CREATE PROCEDURE [dbo].[spGuest_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Guest]
	WHERE Id = @Id
END
