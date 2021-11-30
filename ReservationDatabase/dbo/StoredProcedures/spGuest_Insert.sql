CREATE PROCEDURE [dbo].[spGuest_Insert]
	@Name nvarchar(50),
	@Address nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(15),
	@AccountNumber nchar(15)
AS
BEGIN
	INSERT INTO [dbo].[Guest] ([Name], [Address], Email, Phone, AccountNumber)
	VALUES (@Name, @Address, @Email, @Phone, @AccountNumber)
END
