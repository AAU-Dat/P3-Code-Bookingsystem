CREATE PROCEDURE [dbo].[spReservation_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Reservation]
	WHERE Id = @Id
END
