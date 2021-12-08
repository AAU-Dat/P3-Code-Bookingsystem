CREATE PROCEDURE [dbo].[spReservation_Insert]
	@StartDate date,
	@EndDate date,
	@GuestId int,
	@Information nvarchar
AS
BEGIN
	INSERT INTO [dbo].[Reservation] (StartDate, EndDate, GuestId, Information)
	VALUES (@StartDate, @EndDate, @GuestId, @Information)
END
