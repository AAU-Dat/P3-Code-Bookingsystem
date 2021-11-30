CREATE TABLE [dbo].[Guest]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(15) NOT NULL, 
    [AccountNumber] NCHAR(15) NOT NULL, 
    CONSTRAINT [PK_Guest] PRIMARY KEY ([Id])
)
