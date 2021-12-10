CREATE PROCEDURE [dbo].[spAssociation_Update]
	@Id int,
	@Name nvarchar(50),
	@Address nvarchar(50) = NULL,
	@Email nvarchar(50) = NULL,
	@Phone nvarchar(15) = NULL,
	@InformationForGuests nvarchar(256) = NULL
AS
BEGIN
	UPDATE [dbo].[Association]
	SET [Name] = ISNULL(@Name, [Name]),
		[Address] = ISNULL(@Address, [Address]),
		[Email] = ISNULL(@Email, [Email]),
		[Phone] = ISNULL(@Phone, [Phone]),
		[InformationForGuests] = ISNULL(@InformationForGuests, [InformationForGuests])
	WHERE Id = @Id
END