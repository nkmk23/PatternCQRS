
--Crear base de datos
CREATE DATABASE Company;

--Crear tabla
CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    CompanyId INT NOT NULL,
    CreatedOn DATETIME DEFAULT GETDATE(),
    DeletedOn DATETIME NULL,
    Email NVARCHAR(150) NOT NULL,
    Fax NVARCHAR(150) NULL,
    Name NVARCHAR(60) NOT NULL,
    LastLogin DATETIME NULL,
    Password NVARCHAR(255) NOT NULL, 
    PortalId INT NOT NULL,
    RoleId INT NOT NULL,
    StatusId INT NOT NULL,
    Telephone NVARCHAR(15) NULL, 
    UpdatedOn DATETIME NULL,
    Username NVARCHAR(60) NOT NULL
);

--Consultar tabla
SELECT TOP (1000) [CustomerId]
      ,[CompanyId]
      ,[CreatedOn]
      ,[DeletedOn]
      ,[Email]
      ,[Fax]
      ,[Name]
      ,[LastLogin]
      ,[Password]
      ,[PortalId]
      ,[RoleId]
      ,[StatusId]
      ,[Telephone]
      ,[UpdatedOn]
      ,[Username]
  FROM [Company].[dbo].[Customers]

--Borrar datos de la tabla 
DELETE
  FROM [Company].[dbo].[Customers]