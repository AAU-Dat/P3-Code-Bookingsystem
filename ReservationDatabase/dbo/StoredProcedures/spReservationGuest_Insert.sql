CREATE PROCEDURE [dbo].[spReservationGuest_Insert]
	@Name nvarchar(50),
	@Address nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(15),
	@AccountNumber nchar(15),
	@StartDate date,
	@EndDate date
AS
BEGIN
	INSERT INTO [dbo].[Guest] ([Name], [Address], Email, Phone, AccountNumber)
	VALUES (@Name, @Address, @Email, @Phone, @AccountNumber)
	INSERT INTO [dbo].[Reservation] (StartDate, EndDate, GuestId)
	VALUES (@StartDate, @EndDate, SCOPE_IDENTITY())
END
