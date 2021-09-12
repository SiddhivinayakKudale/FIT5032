
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/11/2021 00:51:27
-- Generated from EDMX file: C:\Users\sagar\source\repos\DbFirstv3\DbFirstv3\Models\EmpPro.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatabaseForEP];
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

-- Creating table 'EmployeeProjects'
CREATE TABLE [dbo].[EmployeeProjects] (
    [EmployeeEmployeeId] int  NOT NULL,
    [ProjectProjectId] int  NOT NULL
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

-- Creating primary key on [EmployeeEmployeeId], [ProjectProjectId] in table 'EmployeeProjects'
ALTER TABLE [dbo].[EmployeeProjects]
ADD CONSTRAINT [PK_EmployeeProjects]
    PRIMARY KEY CLUSTERED ([EmployeeEmployeeId], [ProjectProjectId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeEmployeeId] in table 'EmployeeProjects'
ALTER TABLE [dbo].[EmployeeProjects]
ADD CONSTRAINT [FK_EmployeeEmployeeProject]
    FOREIGN KEY ([EmployeeEmployeeId])
    REFERENCES [dbo].[Employees]
        ([EmployeeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjectProjectId] in table 'EmployeeProjects'
ALTER TABLE [dbo].[EmployeeProjects]
ADD CONSTRAINT [FK_ProjectEmployeeProject]
    FOREIGN KEY ([ProjectProjectId])
    REFERENCES [dbo].[Projects]
        ([ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectEmployeeProject'
CREATE INDEX [IX_FK_ProjectEmployeeProject]
ON [dbo].[EmployeeProjects]
    ([ProjectProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------