CREATE TABLE [dbo].[DiscountTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[StudentId] INT NOT NULL FOREIGN KEY (StudentId) REFERENCES Students(Id),
	[To] MONEY NOT NULL,
	[From] MONEY NOT NULL,
	[Dicsount] INT NOT NULL,
	[Cost]MONEY NOT NULL
)
