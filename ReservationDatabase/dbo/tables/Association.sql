CREATE TABLE [dbo].[Association]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(15) NOT NULL, 
    [InformationForGuests] NVARCHAR(256) NOT NULL
    CONSTRAINT [PK_Association] PRIMARY KEY ([Id])
)
