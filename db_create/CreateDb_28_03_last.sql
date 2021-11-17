/*
Created		18.03.2021
Modified		28.03.2021
Project		
Model		
Company		
Author		
Version		
Database		MS SQL 7 
*/


Create table [User] (
	[userMail] Char(100) NOT NULL UNIQUE,
	[QcID] Integer NOT NULL,
	[PIB] Char(150) NOT NULL,
	[CurrrentQuestion] Integer NULL,
Primary Key  ([userMail])
) 
go

Create table [Question] (
	[questionID] Integer NOT NULL UNIQUE,
	[Description] Char(800) NOT NULL UNIQUE,
	[Answer1] Char(200) NULL,
	[Answer2] Char(200) NULL,
	[Answer3] Char(200) NULL,
	[Answer4] Char(200) NULL,
	[Answer5] Char(200) NULL,
Primary Key  ([questionID])
) 
go

Create table [Answers] (
	[answerID] Integer NOT NULL UNIQUE,
	[Value] Integer NULL,
Primary Key  ([answerID])
) 
go

Create table [QualificationCategory] (
	[QcID] Integer NOT NULL UNIQUE,
	[Name] Char(50) NULL,
Primary Key  ([QcID])
) 
go

Create table [AnswersHistory] (
	[userMail] Char(100) NOT NULL,
	[questionID] Integer NOT NULL,
	[answerID] Integer NOT NULL
) 
go

Create table [Ñompetence] (
	[cmID] Integer NOT NULL UNIQUE,
	[Name] Char(50) NOT NULL,
	[CompetenceType] Char(3) NOT NULL,
Primary Key  ([cmID])
) 
go

Create table [CompetenceList] (
	[questionID] Integer NOT NULL,
	[cmID] Integer NOT NULL
) 
go

Create table [QuestionCategoryList] (
	[QcID] Integer NOT NULL,
	[questionID] Integer NOT NULL
) 
go

Create table [QuestionParams] (
	[Competence] Char(10) NULL,
	[Category] Char(10) NULL,
	[questionID] Integer NOT NULL
) 
go


Alter table [AnswersHistory] add  foreign key([userMail]) references [User] ([userMail]) 
go
Alter table [AnswersHistory] add  foreign key([questionID]) references [Question] ([questionID]) 
go
Alter table [QuestionCategoryList] add  foreign key([questionID]) references [Question] ([questionID]) 
go
Alter table [QuestionParams] add  foreign key([questionID]) references [Question] ([questionID]) 
go
Alter table [CompetenceList] add  foreign key([questionID]) references [Question] ([questionID]) 
go
Alter table [AnswersHistory] add  foreign key([answerID]) references [Answers] ([answerID]) 
go
Alter table [User] add  foreign key([QcID]) references [QualificationCategory] ([QcID]) 
go
Alter table [QuestionCategoryList] add  foreign key([QcID]) references [QualificationCategory] ([QcID]) 
go
Alter table [CompetenceList] add  foreign key([cmID]) references [Ñompetence] ([cmID]) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */


