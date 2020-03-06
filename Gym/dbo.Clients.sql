CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [DateStart] DATE NOT NULL, 
    [Weight] FLOAT NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Gender] NVARCHAR(20) NOT NULL, 
    [IdTrener] INT NULL FOREIGN KEY REFERENCES Coachs(Id) 
)
