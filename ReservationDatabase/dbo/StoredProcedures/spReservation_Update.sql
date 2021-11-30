CREATE PROCEDURE [dbo].[spReservation_Update]
	@Id int,
	@StartDate date = NULL,
	@EndDate date = NULL,
	@Approved date = NULL,
	@DepositPaid date = NULL,
	@RentPaid date = NULL,
	@DepositRefunded date = NULL,
	@Cancelled date = NULL
AS
BEGIN
	UPDATE [dbo].[Reservation]
	SET StartDate=ISNULL(@StartDate, StartDate),
		EndDate=ISNULL(@EndDate, EndDate),
		Approved=ISNULL(@Approved, Approved),
		DepositPaid=ISNULL(@DepositPaid, DepositPaid),
		RentPaid=ISNULL(@RentPaid, RentPaid),
		DepositRefunded=ISNULL(@DepositRefunded, DepositRefunded),
		Cancelled=ISNULL(@Cancelled, Cancelled)
	WHERE Id = @Id
END
