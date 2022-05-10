CREATE TRIGGER [CostOfAducation]
	ON [dbo].[GiveCash] 
	INSTEAD OF INSERT
	AS 
    BEGIN
	    SET NOCOUNT ON

		INSERT INTO TakeCash(StudentId,Cost,DataGive,Comment) 
		(SELECT StudentId,Cost,DataGive,N'На похавать ' FROM inserted)
		
	END