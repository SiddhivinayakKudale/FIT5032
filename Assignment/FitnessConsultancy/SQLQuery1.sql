
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/11/2021 22:37:38
-- Generated from EDMX file: C:\Users\sagar\Documents\GitHub\FIT5032\Assignment\FitnessConsultancy\FitnessConsultancy\Models\FitnessModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-FitnessConsultancy-20210909094159];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserExercises'
CREATE TABLE [dbo].[AspNetUserExercises] (
    [AspNetUserId] nvarchar(128)  NOT NULL,
    [ExerciseExerciseId] int  NOT NULL
);
GO

-- Creating table 'Exercises'
CREATE TABLE [dbo].[Exercises] (
    [ExerciseId] int IDENTITY(1,1) NOT NULL,
    [ExerciseName] nvarchar(max)  NOT NULL,
    [ExerciseDesc] nvarchar(max)  NOT NULL,
    [ExerciseCategory] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetUserId], [ExerciseExerciseId] in table 'AspNetUserExercises'
ALTER TABLE [dbo].[AspNetUserExercises]
ADD CONSTRAINT [PK_AspNetUserExercises]
    PRIMARY KEY CLUSTERED ([AspNetUserId], [ExerciseExerciseId] ASC);
GO

-- Creating primary key on [ExerciseId] in table 'Exercises'
ALTER TABLE [dbo].[Exercises]
ADD CONSTRAINT [PK_Exercises]
    PRIMARY KEY CLUSTERED ([ExerciseId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AspNetUserId] in table 'AspNetUserExercises'
ALTER TABLE [dbo].[AspNetUserExercises]
ADD CONSTRAINT [FK_AspNetUserAspNetUserExercise]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ExerciseExerciseId] in table 'AspNetUserExercises'
ALTER TABLE [dbo].[AspNetUserExercises]
ADD CONSTRAINT [FK_ExerciseAspNetUserExercise]
    FOREIGN KEY ([ExerciseExerciseId])
    REFERENCES [dbo].[Exercises]
        ([ExerciseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExerciseAspNetUserExercise'
CREATE INDEX [IX_FK_ExerciseAspNetUserExercise]
ON [dbo].[AspNetUserExercises]
    ([ExerciseExerciseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------