CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Cost] MONEY NOT NULL,
	[Dates] DATE NOT NULL,
	[GroupId] INT NOT NULL FOREIGN KEY (GroupId) REFERENCES Groups(Id)
)
