--Crear base de datos
CREATE DATABASE CRMDB
GO

--Utilizar la base de datos
USE CRMDB
GO 

--Crear la tabla Customers
CREATE TABLE Customers
(
	Id INT IDENTITY (1,1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(225)
)
go