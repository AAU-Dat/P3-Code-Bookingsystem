IF NOT EXISTS (SELECT 1 FROM [dbo].[Guest])
BEGIN
    INSERT INTO [dbo].[Guest] ([Name], [Address], [Email], [Phone], [AccountNumber])
    VALUES 
        ('Daniel Petersen', 'Gammelgade 1', 'daniel@mail.com', '12 23 34 45', '0001-0000654321'),
        ('Lars Hansen', 'Nygade 1', 'lars@mail.dk', '88 88 88 88', '8888-0008088888'),
        ('Elias Hajji', 'Lilletorv 1', 'elias@mail.dk', '24 24 35 35', '0002-0000654321'),
        ('Raymond Kacso', 'Storetorv 99', 'raymond@email.ru', '00 00 90 01', '0101-1234567890')
    INSERT INTO [dbo].[Reservation] ([StartDate], [EndDate], [GuestId])
    VALUES
        (DATEADD(day, 5, CURRENT_TIMESTAMP), DATEADD(day, 5, CURRENT_TIMESTAMP), 1),
        (DATEADD(day, 10, CURRENT_TIMESTAMP), DATEADD(day, 10, CURRENT_TIMESTAMP), 2),
        (DATEADD(day, 14, CURRENT_TIMESTAMP), DATEADD(day, 14, CURRENT_TIMESTAMP), 3),
        (DATEADD(day, 30, CURRENT_TIMESTAMP), DATEADD(day, 30, CURRENT_TIMESTAMP), 4)
END