CREATE PROCEDURE [dbo].[spReservationGuest_Insert]
	@Name nvarchar(50),
	@Address nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(15),
	@AccountNumber nchar(15),
	@StartDate date,
	@EndDate date,
	@Information nvarchar(256)
AS
BEGIN
	INSERT INTO [dbo].[Guest] ([Name], [Address], Email, Phone, AccountNumber)
	VALUES (@Name, @Address, @Email, @Phone, @AccountNumber)
	INSERT INTO [dbo].[Reservation] (StartDate, EndDate, Information, GuestId)
	VALUES (@StartDate, @EndDate, @Information, SCOPE_IDENTITY())
END
