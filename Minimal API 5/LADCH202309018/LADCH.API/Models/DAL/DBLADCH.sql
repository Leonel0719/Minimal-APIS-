﻿CREATE DATABASE DBLADCH
GO

USE DBLADCH
GO

CREATE TABLE Productos (
    Id INT PRIMARY KEY NOT NULL,
    Nombre VARCHAR(255) NOT NULL,
    Descripcion VARCHAR(255),
    Stock INT NOT NULL,
    Precio DECIMAL(10,2)NOT NULL,
    FechaLanzamiento DATE NOT NULL
);
