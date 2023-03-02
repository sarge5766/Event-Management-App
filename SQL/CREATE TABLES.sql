drop table dbo.Users

create table dbo.Users (
	UserId int not null primary key identity (1, 1),
	Username nvarchar(20),
	Password nvarchar(20),
	RoleId int
)

drop table dbo.Roles

create table dbo.Roles (
	RoleId int not null primary key identity(1, 1),
	RoleName nvarchar(20)
)

drop table dbo.Contacts

create table dbo.Contacts (
	ContactId int not null primary key identity(1, 1),
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Email nvarchar(35),
	MobileNumber nvarchar(20),
	[Address] nvarchar(35),
	City nvarchar(25),
	Zipcode nvarchar(10),
	BloodType nvarchar(10),
	ReferredBy int
)

drop table dbo.BloodDonations

create table dbo.BloodDonations(
	DonationId int not null primary key identity(1, 1),
	DonorId int not null,
	Donated bit default(0),
	DonationDate DateTime,
	DonationLocation nvarchar(50)
)

drop table dbo.Events

create table dbo.Events (
	EventId int not null primary key identity(1, 1),
	[Name] nvarchar(50),
	EventDate DateTime,
	IsActive bit default(0)
)

drop table dbo.EventMapper

create table dbo.EventMapper (
	EventId int not null,
	ContactId int not null
)