CREATE DATABASE BD_CLIENTES;
GO

USE BD_CLIENTES;
GO

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Correo NVARCHAR(100)
);
GO

INSERT INTO Clientes (Nombre, Correo) VALUES ('Sebastian Fuentes', 'sebasfuentes@example.com');
