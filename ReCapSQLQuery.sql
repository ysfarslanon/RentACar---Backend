CREATE DATABASE RentACar;
  
CREATE TABLE Cars(
	Id int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice int,
	Description nvarchar(255),
	);

CREATE TABLE Brands(
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(25),
	);

CREATE TABLE Colors(
	Id int PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(25),
	);

CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(30) NULL, 
	LastName nvarchar(30) NULL, 
	Email nvarchar(50) NULL, 
	Password nvarchar(50) NULL, 
	);

CREATE TABLE Customers(
	Id INT NOT NULL PRIMARY KEY, 
	UserId INT FOREIGN KEY REFERENCES Users(Id) ,
	CompanyName nvarchar(30) NULL, 	
	);

CREATE TABLE Rentals(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id),
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
	RentDate DATETIME NOT NULL,
	ReturnDate DATETIME NULL,
	);

CREATE TABLE CarImages(
	Id int PRIMARY KEY IDENTITY(1,1),
	CarId int foreign key references Cars(Id),
	ImagePath varchar,
	ImageDate datetime,
	);

INSERT INTO Cars VALUES   --Id primary key old. için gireye gerek yok--
	(1,1,1996,500,'Opel 1996 Astra Beyaz'),
	(1,2,2017,800,'Opel 2017 Astra Siyah'),
	(2,1,2012,1500,'Volvo 2012 S60 Beyaz'),
	(2,2,2020,5000,'Volvo 2020 S90 Siyah'),
	(3,3,2007,5000,'Mercedes 2007 Vito Gri');

INSERT INTO Brands VALUES
	('Opel'),
	('Volvo'),
	('Mercedes');

INSERT INTO Colors VALUES
	('Beyaz'),
	('Siyah'),
	('Gri');

INSERT INTO Users VALUES 
	('Yusuf','ARSLAN','arslan_esra@gmail.com','pass00'),
	('Esra','ARSLAN','arslan_esra@gmail.com','pass00'),
	('Mehmet','ARSLAN','arslan_mehmet@hotmail.com','pass00'),
	('Gönül','ARSLAN','arslanon_gonul@gmail.com','pass00'),
	('Süleyman','ARSLAN','arslan_suleyman@outlook.com','pass00'),
	('Rasim','ARSLAN','arslan_rasim@outlook.com','pass00'),
	('Kader','ARSLAN','arslan_kader@outlook.com','pass00');
	
	
INSERT INTO Customers VALUES
	(1,1,'A10'),
	(2,2,'EsNa'),
	(3,3,'MArs'),
	(4,4,'G85');
