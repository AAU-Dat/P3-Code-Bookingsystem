CREATE PROCEDURE [dbo].[spReservation_Get]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Reservation]
	WHERE Id = @Id
END
