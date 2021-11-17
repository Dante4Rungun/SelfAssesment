/*
Created		15.02.2021
Modified		15.02.2021
Project		
Model		
Company		
Author		
Version		
Database		MS SQL 7 
*/


Create table [SecondaryEducation] (
	[IAExpertID] Integer NOT NULL UNIQUE,
	[AreaID] Integer NOT NULL,
	[Surname] Char(20) NULL,
	[Name] Char(20) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(150) NULL,
	[QualificationÑategory] Char(50) NULL,
	[PedagogicalExperience] Integer NULL,
	[TeachingSubject] Char(50) NULL,
	[Certification] Datetime NULL,
	[WorkPlace] Char(100) NULL,
	[WorkPosition] Char(50) NULL,
	[EducationManagmentExperience] Char(10) NULL,
	[ManagmentPositionExperience] Char(10) NULL,
	[Region] Char(50) NULL,
	[District] Char(50) NULL,
	[EmailAdress] Char(40) NULL,
	[Telephone] Char(15) NULL,
	[IAStudyYear] Char(10) NULL,
Primary Key  ([IAExpertID])
) 
go

Create table [ExpertAreaType] (
	[AreaID] Integer NOT NULL UNIQUE,
	[AreaName] Char(70) NOT NULL,
Primary Key  ([AreaID])
) 
go

Create table [HighEducationExperts] (
	[HExpertID] Char(25) NOT NULL UNIQUE,
	[AreaID] Integer NOT NULL,
	[Surname] Char(25) NULL,
	[Name] Char(25) NULL,
	[SecondName] Char(25) NULL,
	[EmailAdress] Char(40) NULL,
	[Telephone] Char(15) NULL,
	[Degree] Char(100) NULL,
	[AcademicStatus] Char(100) NULL,
	[QualificationÑategory] Char(100) NULL,
	[WorkPlace] Char(100) NULL,
	[WorkPosition] Char(100) NULL,
	[ActivityAreasZVO] Char(1000) NULL,
Primary Key  ([HExpertID])
) 
go

Create table [PreSchoolEducation] (
	[IAExpertID] Integer NOT NULL UNIQUE,
	[AreaID] Integer NOT NULL,
	[Surname] Char(20) NULL,
	[Name] Char(20) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(150) NULL,
	[QualificationÑategory] Char(50) NULL,
	[PedagogicalExperience] Integer NULL,
	[TeachingSubject] Char(50) NULL,
	[Certification] Datetime NULL,
	[WorkPlace] Char(100) NULL,
	[WorkPosition] Char(50) NULL,
	[EducationManagmentExperience] Char(10) NULL,
	[ManagmentPositionExperience] Char(10) NULL,
	[Region] Char(50) NULL,
	[District] Char(50) NULL,
	[EmailAdress] Char(40) NULL,
	[Telephone] Char(15) NULL,
	[IAStudyYear] Char(10) NULL,
Primary Key  ([IAExpertID])
) 
go

Create table [ProfessionalEducation] (
	[IAExpertID] Integer NOT NULL UNIQUE,
	[AreaID] Integer NOT NULL,
	[Surname] Char(20) NULL,
	[Name] Char(20) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(150) NULL,
	[QualificationÑategory] Char(50) NULL,
	[PedagogicalExperience] Integer NULL,
	[TeachingSubject] Char(50) NULL,
	[Certification] Datetime NULL,
	[WorkPlace] Char(100) NULL,
	[WorkPosition] Char(50) NULL,
	[EducationManagmentExperience] Char(10) NULL,
	[ManagmentPositionExperience] Char(10) NULL,
	[Region] Char(50) NULL,
	[District] Char(50) NULL,
	[EmailAdress] Char(40) NULL,
	[Telephone] Char(15) NULL,
	[IAStudyYear] Char(10) NULL,
Primary Key  ([IAExpertID])
) 
go

Create table [ProfessionalHighEducationExperts] (
	[HExpertID] Char(25) NOT NULL UNIQUE,
	[AreaID] Integer NOT NULL,
	[Surname] Char(25) NULL,
	[Name] Char(25) NULL,
	[SecondName] Char(25) NULL,
	[EmailAdress] Char(40) NULL,
	[Telephone] Char(15) NULL,
	[Degree] Char(100) NULL,
	[AcademicStatus] Char(100) NULL,
	[QualificationÑategory] Char(100) NULL,
	[WorkPlace] Char(100) NULL,
	[WorkPosition] Char(100) NULL,
	[ActivityAreasZVO] Char(1000) NULL,
Primary Key  ([HExpertID])
) 
go

Create table [ParticipationsSE] (
	[ParticipationID] Integer NOT NULL UNIQUE,
	[IAExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
Primary Key  ([ParticipationID])
) 
go

Create table [EstimationSE] (
	[markID] Integer NOT NULL UNIQUE,
	[IAExpertID] Integer NOT NULL,
	[MarkValue] Integer NULL,
Primary Key  ([markID])
) 
go

Create table [EstimationPSE] (
	[markID] Integer NOT NULL UNIQUE,
	[IAExpertID] Integer NOT NULL,
	[MarkValue] Integer NULL,
Primary Key  ([markID])
) 
go

Create table [ParticipationsPSE] (
	[ParticipationID] Integer NOT NULL UNIQUE,
	[IAExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
Primary Key  ([ParticipationID])
) 
go

Create table [ParticipationsPE] (
	[ParticipationID] Integer NOT NULL UNIQUE,
	[IAExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
Primary Key  ([ParticipationID])
) 
go

Create table [ParticipationsPHE] (
	[ParticipationID] Integer NOT NULL UNIQUE,
	[HExpertID] Char(25) NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
Primary Key  ([ParticipationID])
) 
go

Create table [EstimationPE] (
	[markID] Integer NOT NULL UNIQUE,
	[IAExpertID] Integer NOT NULL,
	[MarkValue] Integer NULL,
Primary Key  ([markID])
) 
go

Create table [EstimationPHE] (
	[markID] Integer NOT NULL UNIQUE,
	[HExpertID] Char(25) NOT NULL,
	[MarkValue] Integer NULL,
Primary Key  ([markID])
) 
go

Create table [EstimationHE] (
	[markID] Integer NOT NULL UNIQUE,
	[HExpertID] Char(25) NOT NULL,
	[MarkValue] Integer NULL,
Primary Key  ([markID])
) 
go

Create table [ParticipationsHE] (
	[ParticipationID] Integer NOT NULL UNIQUE,
	[HExpertID] Char(25) NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
Primary Key  ([ParticipationID])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


