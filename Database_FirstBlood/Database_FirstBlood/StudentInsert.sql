CREATE TRIGGER [StudentInsert]
	ON [dbo].[Students]
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON

		INSERT INTO GiveCash
		       (StudentId,Cost,DataGive)
           SELECT 
		       inserted.Id,1000.99,'2021-6-8'
			   FROM inserted
	
	END
