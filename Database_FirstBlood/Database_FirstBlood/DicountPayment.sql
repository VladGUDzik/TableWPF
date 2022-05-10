CREATE FUNCTION [dbo].[DicountPayment](@studentid int,@cost money,@date date)
RETURNS int
AS
BEGIN

  DECLARE @discount int

  IF CAST(GetDate() AS DATE) <= @date 
  BEGIN
     IF @cost>=200 AND @cost<=500
	 BEGIN 
        SET @discount=5
	 END 
	 IF @cost>=501 AND @cost<=100
	 BEGIN 
        SET @discount=7
	 END 
	 ELSE
	 BEGIN 
        SET @discount=10
	 END
  END

  RETURN @discount
END





    --[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	--[StudentId] INT NOT NULL FOREIGN KEY (StudentId) REFERENCES Students(Id),
	--[To] MONEY NOT NULL,
	--[From] MONEY NOT NULL,
	--[Dicsount] INT NOT NULL,
	--[Cost]MONEY NOT NULL FOREIGN KEY (Cost) REFERENCES TakeCash(Cost)