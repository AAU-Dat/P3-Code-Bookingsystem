CREATE PROCEDURE [dbo].[spGuest_Update]
	@Id int,
	@Address nvarchar(50) = NULL,
	@Email nvarchar(50) = NULL,
	@Phone nvarchar(15) = NULL,
	@AccountNumber nchar(15) = NULL
AS
BEGIN
	UPDATE [dbo].[Guest]
	SET [Address] = ISNULL(@Address, [Address]),
		[Email] = ISNULL(@Email, [Email]),
		[Phone] = ISNULL(@Phone, [Phone]),
		[AccountNumber] = ISNULL(@AccountNumber, [AccountNumber])
	WHERE Id = @Id
END
