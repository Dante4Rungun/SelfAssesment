Create table [ExpertAreaType] (
	[AreaID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaName] Char(70) NOT NULL,
) 
go

INSERT INTO ExpertAreaType(AreaName) 
VALUES ('Äîøê³ëüíà îñâ³òà')
INSERT INTO ExpertAreaType(AreaName) 
VALUES ('Çàãàëüíà ñåðåäíÿ îñâ³òà')
INSERT INTO ExpertAreaType(AreaName) 
VALUES ('Ïðîôåñ³éíà(ïðîôåñ³éíî-òåõí³÷íà) îñâ³òà')
INSERT INTO ExpertAreaType(AreaName) 
VALUES ('Ôàõîâà ïåðåäâèùà îñâ³òà')
INSERT INTO ExpertAreaType(AreaName) 
VALUES ('Âèùà îñâ³òà')
INSERT INTO ExpertAreaType(AreaName)
VALUES ('Åêñïåðòè, ùî ìîæóòü äîëó÷àòèñÿ äî ñåðòèô³êàö³¿')

Create table [SecondaryEducation] (
	[SEExpertID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaID] Integer DEFAULT 2,
	[Surname] Char(20) NULL,
	[Name] Char(20) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(150) NULL,
	[QualificationÑategory] Char(50) NULL,
	[PedagogicalExperience] Integer NULL,
	[TeachingSubject] Char(50) NULL,
	[Certification] Datetime NULL,
	[WorkPlace] Char(400) NULL,
	[WorkPosition] Char(200) NULL,
	[EducationManagmentExperience] INTEGER NULL,
	[ManagmentPositionExperience] INTEGER NULL,
	[Region] Char(100) NULL,
	[District] Char(100) NULL,
	[EmailAdress] Char(60) NULL,
	[Telephone] Char(15) NULL,
	[IAStudyYear] Char(10) NULL,
) 
go

Create table [HighEducationExperts] (
	[HExpertID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaID] Integer DEFAULT 5,
	[Surname] Char(25) NULL,
	[Name] Char(25) NULL,
	[SecondName] Char(25) NULL,
	[EmailAdress] Char(60) NULL,
	[Telephone] Char(15) NULL,
	[Degree] Char(100) NULL,
	[AcademicStatus] Char(100) NULL,
	[QualificationÑategory] Char(100) NULL,
	[WorkPlace] Char(400) NULL,
	[WorkPosition] Char(200) NULL,
	[ActivityAreasZVO] Char(1000) NULL,
) 
go

Create table [PreSchoolEducation] (
	[PSEExpertID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaID] Integer DEFAULT 1,
	[Surname] Char(20) NULL,
	[Name] Char(20) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(150) NULL,
	[QualificationÑategory] Char(50) NULL,
	[PedagogicalExperience] Integer NULL,
	[TeachingSubject] Char(50) NULL,
	[Certification] Datetime NULL,
	[WorkPlace] Char(400) NULL,
	[WorkPosition] Char(200) NULL,
	[EducationManagmentExperience] INTEGER NULL,
	[ManagmentPositionExperience] INTEGER NULL,
	[Region] Char(100) NULL,
	[District] Char(100) NULL,
	[EmailAdress] Char(60) NULL,
	[Telephone] Char(15) NULL,
	[IAStudyYear] Char(10) NULL,
) 
go

Create table [ProfessionalEducation] (
	[PEExpertID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaID] Integer DEFAULT 3,
	[Surname] Char(20) NULL,
	[Name] Char(20) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(150) NULL,
	[QualificationÑategory] Char(70) NULL,
	[PedagogicalExperience] Integer NULL,
	[TeachingSubject] Char(70) NULL,
	[Certification] Datetime NULL,
	[WorkPlace] Char(400) NULL,
	[WorkPosition] Char(200) NULL,
	[EducationManagmentExperience] INTEGER NULL,
	[ManagmentPositionExperience] INTEGER NULL,
	[Region] Char(100) NULL,
	[District] Char(100) NULL,
	[EmailAdress] Char(60) NULL,
	[Telephone] Char(15) NULL,
	[IAStudyYear] Char(10) NULL,
) 
go

Create table [ProfessionalHighEducationExperts] (
	[PHExpertID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaID] Integer DEFAULT 4,
	[Surname] Char(25) NULL,
	[Name] Char(25) NULL,
	[SecondName] Char(25) NULL,
	[EmailAdress] Char(60) NULL,
	[Telephone] Char(15) NULL,
	[Degree] Char(100) NULL,
	[AcademicStatus] Char(100) NULL,
	[QualificationÑategory] Char(100) NULL,
	[WorkPlace] Char(400) NULL,
	[WorkPosition] Char(200) NULL,
	[ActivityAreasZVO] Char(1000) NULL,
) 
go

Create table [ParticipationsSE] (
	[ParticipationID] Integer IDENTITY(1,1) PRIMARY KEY,
	[SEExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
	[Mark] Integer NULL,
) 
go

Create table [ParticipationsPSE] (
	[ParticipationID] Integer IDENTITY(1,1) PRIMARY KEY,
	[PSEExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
	[Mark] Integer NULL,
) 
go

Create table [ParticipationsPE] (
	[ParticipationID] Integer IDENTITY(1,1) PRIMARY KEY,
	[PEExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
	[Mark] Integer NULL,
) 
go

Create table [ParticipationsPHE] (
	[ParticipationID] Integer IDENTITY(1,1) PRIMARY KEY,
	[PHExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
	[Mark] Integer NULL,
) 
go

Create table [ParticipationsHE] (
	[ParticipationID] Integer IDENTITY(1,1) PRIMARY KEY,
	[HExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
) 
go

Create table [ResearchingPracticalExperienceExperts] (
	[RPExpertID] Integer IDENTITY(1,1) PRIMARY KEY,
	[AreaID] Integer NULL,
	[Name] Char(25) NULL,
	[Surname] Char(25) NULL,
	[SecondName] Char(25) NULL,
	[Education] Char(20) NULL,
	[EducationalEstablishmentName] Char(400) NULL,
	[EducationalEstablishmetLocation] Char(40) NULL,
	[EducationalEstablishmetSettlement] Char(100) NULL,
	[GraduationYear] Integer NULL,
	[DiplomSpecialty] Char(100) NULL,
	[DiplomQualification] Char(100) NULL,
	[QualificationCategory] Char(18) NULL,
	[PedagogicalTitle] Char(70) NULL,
	[PedagogicalExperience] Integer NULL,
	[ElementarySchoolPedagogicalExperience] Integer NULL,
	[WorkPosition] Char(100) NULL,
	[WasTraindAs] Char(21) NULL,
	[OrganizationName] Char(100) NULL,
	[OrgRegion] Char(30) NULL,
	[OrgSettlementType] Char(6) NULL,
	[OrgSettlementName] Char(100) NULL,
	[OrgLeaderPIB] Char(100) NULL,
	[OrgLeaderTelephone] Char(15) NULL,
	[OrgLeaderEmail] Char(10) NULL,
	[IsOrgAccounting] Char(14) NULL,
	[Region] Char(30) NULL,
	[District] Char(50) NULL,
	[UnitedSettlement] Char(100) NULL,
	[SettlementType] Char(6) NULL,
	[SettlementName] Char(100) NULL,
	[ContactNumber1] Char(15) NULL,
	[ContactNumber2] Char(15) NULL,
	[Email1] Char(50) NULL,
	[Email2] Char(50) NULL,
) 
go

Create table [ParticipationsRP] (
	[ParticipationID] Integer IDENTITY(1,1) PRIMARY KEY,
	[RPExpertID] Integer NOT NULL,
	[ParticipationName] Char(100) NULL,
	[Year] Integer NULL,
	[Mark] Integer NULL,
) 
go

Create table [Users] (
	[UserID] Integer IDENTITY(1,1) PRIMARY KEY,
	[Login] Char(50) NOT NULL UNIQUE,
	[Password] Char(100) NOT NULL,
	[District] Char(50) NOT NULL,
	[Status] Char(20) NOT NULL,
	[CreateDate] Datetime NOT NULL,
) 
go

Create table [UsersActivity] (
	[UserID] Integer NOT NULL,
	[Login] Char(50) NOT NULL,
	[ActiveType] Char(20) NOT NULL,
	[Time] Datetime NOT NULL,
	[Description] Char(4000) NULL,
	[Host] char(40) NULL,
	[EnterIP] char(30) NULL
) 
go

Create table [AccessLevel] (
	[UserID] Integer NOT NULL,
	[UserActivityHistory] Integer Default 0 NOT NULL,
	[AddUser] Integer Default 0 NOT NULL,
	[WriteAccess] Integer Default 0 NOT NULL,
	[SendMessage] Integer Default 0 NOT NULL,
	[ExcelDataAdd] Integer Default 0 NOT NULL,
	[CreateDocs] Integer Default 0 NOT NULL
) 
go

Alter table [ParticipationsSE] add  foreign key([SEExpertID]) references [SecondaryEducation] ([SEExpertID]) 
go
Alter table [SecondaryEducation] add  foreign key([AreaID]) references [ExpertAreaType] ([AreaID]) 
go
Alter table [HighEducationExperts] add  foreign key([AreaID]) references [ExpertAreaType] ([AreaID]) 
go
Alter table [PreSchoolEducation] add  foreign key([AreaID]) references [ExpertAreaType] ([AreaID]) 
go
Alter table [ProfessionalEducation] add  foreign key([AreaID]) references [ExpertAreaType] ([AreaID]) 
go
Alter table [ProfessionalHighEducationExperts] add  foreign key([AreaID]) references [ExpertAreaType] ([AreaID]) 
go
Alter table [ResearchingPracticalExperienceExperts] add  foreign key([AreaID]) references [ExpertAreaType] ([AreaID]) 
go
Alter table [ParticipationsHE] add  foreign key([HExpertID]) references [HighEducationExperts] ([HExpertID]) 
go
Alter table [ParticipationsPSE] add  foreign key([PSEExpertID]) references [PreSchoolEducation] ([PSEExpertID]) 
go
Alter table [ParticipationsPE] add  foreign key([PEExpertID]) references [ProfessionalEducation] ([PEExpertID]) 
go
Alter table [ParticipationsPHE] add  foreign key([PHExpertID]) references [ProfessionalHighEducationExperts] ([PHExpertID]) 
go
Alter table [ParticipationsRP] add  foreign key([RPExpertID]) references [ResearchingPracticalExperienceExperts] ([RPExpertID]) 
go
Alter table [AccessLevel] add  foreign key([UserID]) references [Users] ([UserID]) 
go
Alter table [UsersActivity] add  foreign key([UserID]) references [Users] ([UserID]) 
go

Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */


