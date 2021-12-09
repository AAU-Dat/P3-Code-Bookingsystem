CREATE PROCEDURE [dbo].[spAssociation_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Association]
	WHERE Id = @Id
END