
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/10/2021 23:35:05
-- Generated from EDMX file: C:\Users\sagar\Documents\GitHub\FIT5032\Assignment\ModelFirstApproach\ModelFirstApproach\Models\SecondModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database2];
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
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EmployeeProject'
CREATE TABLE [dbo].[EmployeeProject] (
    [Employees_Id] int  NOT NULL,
    [Projects_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Employees_Id], [Projects_Id] in table 'EmployeeProject'
ALTER TABLE [dbo].[EmployeeProject]
ADD CONSTRAINT [PK_EmployeeProject]
    PRIMARY KEY CLUSTERED ([Employees_Id], [Projects_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Employees_Id] in table 'EmployeeProject'
ALTER TABLE [dbo].[EmployeeProject]
ADD CONSTRAINT [FK_EmployeeProject_Employee]
    FOREIGN KEY ([Employees_Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Projects_Id] in table 'EmployeeProject'
ALTER TABLE [dbo].[EmployeeProject]
ADD CONSTRAINT [FK_EmployeeProject_Project]
    FOREIGN KEY ([Projects_Id])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProject_Project'
CREATE INDEX [IX_FK_EmployeeProject_Project]
ON [dbo].[EmployeeProject]
    ([Projects_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------