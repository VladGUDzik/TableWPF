﻿CREATE TABLE [dbo].[Mark]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Marks] INT NOT NULL ,
	[StudentId] INT NOT NULL FOREIGN KEY (StudentId) REFERENCES Students(Id)
)
