SELECT * FROM dbo.Groups
WHERE Title=N'29ПР31' ;

SELECT * FROM dbo.Students;

SELECT * FROM dbo.Students 
WHERE Id =1 ;

SELECT * FROM dbo.Mark

SELECT * FROM dbo.Rates

SELECT * FROM dbo.Zachetka

SELECT Id, 1+CRYPT_GEN_RANDOM(1)%12
FROM dbo.Students LEFT JOIN (SELECT 1 as c UNION ALL SELECT 2)t ON 1=1

SELECT * 
FROM dbo.Students
LEFT JOIN Groups ON Groups.Id =Students.GroupId;

SELECT Groups.Title,COUNT(Students.Id) as StudentsCount
FROM dbo.Students 
LEFT JOIN Groups ON Groups.Id = Students.GroupId
GROUP BY Groups.Title,Groups.Id

SELECT * FROM GiveCash

SELECT *FROM TakeCash
SELECT *FROM DiscountTable


