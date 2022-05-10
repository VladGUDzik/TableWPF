/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]	
   	          
--------------------------------------------------------------------------------------
*/

INSERT INTO dbo.Groups(Title)VALUES
 (N'29ПР31'), --1
 (N'29ГР32'), --2
 ('29PPS12'), --3
 ('29GPS21') --4
   
 INSERT INTO dbo.Students(FirstName,LastName,Cost,Dates,GroupId) VALUES
 ('Lack','Jones',109.6,'2007-12-30',2),
 ('Harry','Miller',19.69,'2006-8-10',1),
 ('Grace','Evance',109.06,'2009-9-30',3),
 ('Joshua','Johnson',789.86,'2003-12-12',3),
 ('Emily','Taylor',109.6,'2005-2-6',1),
 ('Charlie','Thomas',189.6,'2007-12-30',4),
 ('Oliver','Moore',98.6,'2004-10-20',4)

 INSERT INTO dbo.Rates(StudentId,Val)

 SELECT Id, 1+CRYPT_GEN_RANDOM(1)%12
 FROM dbo.Students LEFT JOIN (SELECT 1 as c UNION ALL SELECT 2 UNION ALL SELECT 3)t ON 1=1

 SELECT Id, 1+CRYPT_GEN_RANDOM(1)%12
 FROM dbo.Students LEFT JOIN (SELECT 1 as c UNION ALL SELECT 2 UNION ALL SELECT 3)t ON 1=1
 
 INSERT INTO dbo.Mark(Marks,StudentId)VALUES
 (12,1),
 (10,1),
 (4,2),
 (10,3)

SELECT [Groups].Title, COUNT(Students.Id),
AVG(CAST(Mark.Marks AS decimal)) AS Value
FROM dbo.[Groups]
LEFT JOIN Students ON Students.GroupId = [Groups].Id
LEFT JOIN Mark ON Mark.StudentId = Students.Id
GROUP BY [Groups].Title


