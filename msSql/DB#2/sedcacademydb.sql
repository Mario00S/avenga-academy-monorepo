--Homework
--Create a database called SEDCACADEMYDB.

--Create the following tables:

--Student
--Teacher
--Grade
--Course
--AchievementType
--GradeDetails

use [master] 
go

drop database if exists [SEDCACADEMYDB]
go

create database [SEDCACADEMYDB]
go

use [SEDCACADEMYDB]
go

drop table if exists [dbo].[Student]
drop table if exists [dbo].[Teacher]
drop table if exists [dbo].[Grade]
drop table if exists [dbo].[Course]
drop table if exists [dbo].[AchievementType]
drop table if exists [dbo].[GradeDetails]

create table Student(
[ID] int IDENTITY(1,1) not null,
[FirstName] nvarchar(100) null,
[LastName] nvarchar(100) null,
[DateOfBirth] date null,
[EnroledDate] date null,
[Gender] char (1) null,
[NationalIDNumber] nvarchar(20) null,
[StudentCardNumber] nvarchar(20) null,
constraint PK_Student primary key (ID)
--constraint CK_Student_Gender CHECK (Gender IN ('M', 'F'))
)


create table Teacher(
[ID] int IDENTITY(1,1) not null,
[FirstName] nvarchar(100) null,
[LastName] nvarchar(100) null,
[DateOfBirth] date null,
[NationalIDNumber] nvarchar(20) null,
[HiredDate] date null,
[AcademicRank] nvarchar(50) null,
constraint PK_Teacher primary key (ID)
)

create table Grade(
[ID] int IDENTITY(1,1) not null,
[StudentID] int null,
[CourseID] int null,
[TeacherID] int null,
[Grade] tinyInt null,
[Comment] nvarchar(300) null,
[CreatedDate] date null,
constraint PK_Grade primary key (ID)
)

create table GradeDetails(
[ID] int IDENTITY(1,1) not null,
[GradeID] int null,
[AchievementTypeID] int null,
[AchievementPoints] tinyInt null,
[AchievementMaxPoints] tinyInt null,
[AchievementDate] date null,
constraint PK_GradeDetails primary key (ID)
)

create table Course(
[ID] int IDENTITY(1,1) not null,
[Name] nvarchar(100) null,
[Credit] tinyInt null,
[AcademicYear] tinyInt null,
[Semester] tinyInt null,
constraint PK_Course primary key (ID)
)

CREATE TABLE AchievementType (
[ID] int IDENTITY(1,1) not null,
[Name] nvarchar(100) null,
[Description] nvarchar(300) null,
[ParticipationRate] decimal (5,2),
constraint PK_AchievementType primary key (ID)
--constraint CHK_AchievementType_ParticipationRate
--    check ([ParticipationRate] between 0 and 100)
);


ALTER TABLE GRADE 
ADD
	constraint FK_Grade_Student	foreign key (StudentID)	references Student(ID),
	constraint FK_Grade_Course foreign key (CourseID) references Course(ID),
	constraint FK_Grade_Teacher foreign key (TeacherID) references Teacher(ID)

ALTER TABLE STUDENT
ADD
	constraint UQ_Student_NationalIDNumber unique (NationalIDNumber),
	constraint UQ_Student_StudentCardNumber unique (StudentCardNumber);

ALTER TABLE GRADEDETAILS
ADD
	constraint FK_GradeDetails_Grade foreign key (GradeID) references Grade(ID),
	constraint FK_GradeDetails_AchievementType foreign key (AchievementTypeID) references AchievementType(ID),
	constraint CHK_AchievementPoints check (AchievementPoints <= AchievementMaxPoints);

ALTER TABLE STUDENT
ADD
	constraint CK_Student_Gender CHECK (Gender IN ('M', 'F'))

ALTER TABLE AchievementType
ADD
constraint CHK_AchievementType_ParticipationRate
    check ([ParticipationRate] between 0 and 100)