create database UserNameDB
go

use UserNameDB
go

create table DataUser
(
	UserName nvarchar(30) not null,
	FullName nvarchar (60) not null,
	Email nvarchar(50) not null,
	Pasword nvarchar(20) not null,
	PhoneNumber int,
	constraint DataUser_PK primary key(Username)
)