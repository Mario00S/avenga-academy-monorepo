--Homework
--Declare scalar variable FirstName = 'Antonio'
--Find all Students with that FirstName
--Create table variable with StudentId, StudentName, DateOfBirth
--Fill with Female students
--Create temp table with LastName and EnrolledDate
--Fill with Male students starting with 'A'
--Find students with LastName length = 7
--Find teachers with FirstName length < 5 and same first 3 letters in First/Last name


Use [AvengaAcademyDB]
GO
--Declare scalar variable FirstName = 'Antonio'
declare @FirstName nvarchar(100);
set @FirstName = 'Antonio';

--Find all Students with that FirstName
select * from dbo.Student 
where FirstName = @FirstName

--Create table variable with StudentId, StudentName, DateOfBirth
declare @StudentTable table (
	StudentId int,
	StudentName nvarchar(100),
	DateOfBirth date
)


--Fill with Female students
insert into @StudentTable (StudentId, StudentName, DateOfBirth)
select ID, FirstName + ' ' + LastName as StudentName, DateOfBirth
from Student
where Gender = 'f'

--Create temp table with LastName and EnrolledDate
declare @TempTable table (
	LastName nvarchar(100),
	EnrolledDate date
)

--Fill with Male students starting with 'A'
insert into @TempTable (LastName, EnrolledDate)
select LastName, EnrolledDate
from Student
where Gender = 'm' and FirstName like 'A%'

--needed to join the table to make sure the data is correct by comparing the first name from the students table
SELECT s.FirstName, t.LastName, t.EnrolledDate
FROM @TempTable t
JOIN Student s
    ON s.LastName = t.LastName
   AND s.EnrolledDate = t.EnrolledDate
WHERE s.Gender = 'm'
  AND s.FirstName LIKE 'A%';

--Find students with LastName length = 7
select LastName
from Student
where len(LastName) = 7 

--Find teachers with FirstName length < 5 and same first 3 letters in First/Last name
select FirstName, lastName
from dbo.Teacher
where len(FirstName) < 5
  AND LEFT(FirstName, 3) = LEFT(LastName, 3);