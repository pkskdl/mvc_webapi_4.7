

GO
create database myapp

GO

USE myapp

go

CREATE TABLE [dbo].[Employee] (
    [EmpId]       INT          NOT NULL IDENTITY,
    [Name]        VARCHAR (75) NULL,
    [Address]     VARCHAR (50) NULL,
    [Gender]      VARCHAR (10) NULL,
    [Company]     VARCHAR (50) NULL,
    [Designation] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([EmpId] ASC)
);

GO