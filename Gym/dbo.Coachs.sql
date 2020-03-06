CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Salary] MONEY NOT NULL, 
    [DateStartWork] DATE NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Foto] NVARCHAR(50) NOT NULL
)
