CREATE PROCEDURE [dbo].[spAssociation_Insert]
	@Name nvarchar(50),
	@Address nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(15),
	@InformationForGuests nvarchar(256)
AS
BEGIN
	INSERT INTO [dbo].[Association] ([Name], [Address], [Email], [Phone], [InformationForGuests])
	VALUES (@Name, @Address, @Email, @Phone, @InformationForGuests)
END
