CREATE PROCEDURE [dbo].[spAssociation_Get]
	@Id int
AS
BEGIN
	SELECT *
	FROM [dbo].[Association]
	WHERE Id = @Id
END