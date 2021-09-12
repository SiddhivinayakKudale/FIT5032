
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/10/2021 23:49:15
-- Generated from EDMX file: C:\Users\sagar\source\repos\EmployeeManagement2\EmployeeManagement2\Models\EmpProManagement.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DbForEmployees];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [EmployeeName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [MobileNO] nvarchar(max)  NOT NULL,
    [Salary] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectId] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [ProjectDetails] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeeProject'
CREATE TABLE [dbo].[EmployeeProject] (
    [Employees_EmployeeId] int  NOT NULL,
    [Projects_ProjectId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmployeeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [ProjectId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectId] ASC);
GO

-- Creating primary key on [Employees_EmployeeId], [Projects_ProjectId] in table 'EmployeeProject'
ALTER TABLE [dbo].[EmployeeProject]
ADD CONSTRAINT [PK_EmployeeProject]
    PRIMARY KEY CLUSTERED ([Employees_EmployeeId], [Projects_ProjectId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Employees_EmployeeId] in table 'EmployeeProject'
ALTER TABLE [dbo].[EmployeeProject]
ADD CONSTRAINT [FK_EmployeeProject_Employee]
    FOREIGN KEY ([Employees_EmployeeId])
    REFERENCES [dbo].[Employees]
        ([EmployeeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_ProjectId] in table 'EmployeeProject'
ALTER TABLE [dbo].[EmployeeProject]
ADD CONSTRAINT [FK_EmployeeProject_Project]
    FOREIGN KEY ([Projects_ProjectId])
    REFERENCES [dbo].[Projects]
        ([ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProject_Project'
CREATE INDEX [IX_FK_EmployeeProject_Project]
ON [dbo].[EmployeeProject]
    ([Projects_ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------