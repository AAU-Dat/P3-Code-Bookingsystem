CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL IDENTITY, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [Approved] DATE NULL, 
    [DepositPaid] DATE NULL, 
    [RentPaid] DATE NULL, 
    [DepositRefunded] DATE NULL, 
    [Cancelled] DATE NULL, 
    [GuestId] INT NOT NULL, 
    CONSTRAINT [PK_Reservation] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY ([GuestId]) REFERENCES [Guest]([Id]), 
)
