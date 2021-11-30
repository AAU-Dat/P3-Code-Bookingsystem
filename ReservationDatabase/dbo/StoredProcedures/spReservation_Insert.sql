CREATE PROCEDURE [dbo].[spReservation_Insert]
	@StartDate date,
	@EndDate date,
	@GuestId int
AS
BEGIN
	INSERT INTO [dbo].[Reservation] (StartDate, EndDate, GuestId)
	VALUES (@StartDate, @EndDate, @GuestId)
END
