USE master
go

if exists(select * from sys.databases where name = 'RPA_Csharp')
	drop database RPA_Csharp

create database RPA_Csharp

use RPA_Csharp
go 

CREATE TABLE WatchDirectory(
	Tag VARCHAR(20) PRIMARY KEY,
	DPath VARCHAR(300) UNIQUE NOT NULL
)

CREATE TABLE GitDirectory(
	ID int identity primary key,
	DPath varchar(300) not null,
	LastPull datetime null,
	RegisterDate datetime default GETDATE(),
	ParentDirectory VARCHAR(20) FOREIGN KEY REFERENCES WatchDirectory(Tag)
)

SELECT * FROM WatchDirectory
SELECT * FROM GitDirectory


DELETE FROM GitDirectory
GO
DELETE FROM WatchDirectory