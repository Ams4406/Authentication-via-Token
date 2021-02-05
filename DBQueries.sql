CREATE DATABASE TokenAuthDB
Go

USE [TokenAuthDB]

CREATE TABLE Employee
(
ID INT IDENTITY(101,1) PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Role VARCHAR(100) NOT NULL,
RegistrationDate DATE,
Email VARCHAR(100) NOT NULL,
Password VARCHAR(100) NOT NULL
)
Go

INSERT INTO Employee(Name,Role,RegistrationDate,Email,Password) VALUES('Abhinav Sharma','User','2020-04-23','abhi@gmail.com','1234');
INSERT INTO Employee(Name,Role,RegistrationDate,Email,Password) VALUES('Aditya Ranga','Admin','2020-07-03','ranga@gmail.com','5678');
INSERT INTO Employee(Name,Role,RegistrationDate,Email,Password) VALUES('Aman Solanki','User','2021-01-07','ams@gmail.com','4406');
INSERT INTO Employee(Name,Role,RegistrationDate,Email,Password) VALUES('Aniket Mathur','Admin','2019-09-12','mathur@gmail.com','1857');
Go