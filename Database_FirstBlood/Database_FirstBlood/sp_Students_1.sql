CREATE PROCEDURE [dbo].[sp_Students]
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@cost money,
	@dates date,
	@groupId int,
	@Id int out
AS
	INSERT INTO Students(FirstName,LastName,Cost,Dates,GroupId)VALUES
	(@firstname,@lastname,@cost,@dates,@groupId)

	SET @Id = SCOPE_IDENTITY()



--[Id] INT NOT NULL PRIMARY KEY IDENTITY,
--	[FirstName] NVARCHAR(50) NOT NULL,
--	[LastName] NVARCHAR(50) NOT NULL,
--	[Cost] MONEY NOT NULL,
--	[Dates] DATE NOT NULL,
--	[GroupId] INT NOT NULL FOREIGN KEY (GroupId) REFERENCES Groups(Id)