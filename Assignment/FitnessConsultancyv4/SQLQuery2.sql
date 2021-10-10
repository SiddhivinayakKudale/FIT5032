
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/25/2021 17:15:37
-- Generated from EDMX file: C:\Users\DELL\OneDrive - Monash University\Documents\GitHub\FIT5032\Assignment\FitnessConsultancyv4\FitnessConsultancyv4\Models\FitnessConsultancy.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-FitnessConsultancyv4-20210924090953];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetUserUserEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvents] DROP CONSTRAINT [FK_AspNetUserUserEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_EventUserEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserEvents] DROP CONSTRAINT [FK_EventUserEvent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[UserEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserEvents];
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

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [EventDesc] nvarchar(max)  NOT NULL,
    [Latitude] decimal(18,0)  NOT NULL,
    [Longitude] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'UserEvents'
CREATE TABLE [dbo].[UserEvents] (
    [UserEventId] int IDENTITY(1,1) NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL,
    [EventEventId] int  NOT NULL
);
GO

-- Creating table 'Calendars'
CREATE TABLE [dbo].[Calendars] (
    [EventID] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Start] datetime  NOT NULL,
    [End] datetime  NULL,
    [ThemeColor] nvarchar(max)  NOT NULL,
    [IsFullDay] nvarchar(max)  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL
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

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [UserEventId] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [PK_UserEvents]
    PRIMARY KEY CLUSTERED ([UserEventId] ASC);
GO

-- Creating primary key on [EventID] in table 'Calendars'
ALTER TABLE [dbo].[Calendars]
ADD CONSTRAINT [PK_Calendars]
    PRIMARY KEY CLUSTERED ([EventID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AspNetUserId] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [FK_AspNetUserUserEvent]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserUserEvent'
CREATE INDEX [IX_FK_AspNetUserUserEvent]
ON [dbo].[UserEvents]
    ([AspNetUserId]);
GO

-- Creating foreign key on [EventEventId] in table 'UserEvents'
ALTER TABLE [dbo].[UserEvents]
ADD CONSTRAINT [FK_EventUserEvent]
    FOREIGN KEY ([EventEventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventUserEvent'
CREATE INDEX [IX_FK_EventUserEvent]
ON [dbo].[UserEvents]
    ([EventEventId]);
GO

-- Creating foreign key on [AspNetUserId] in table 'Calendars'
ALTER TABLE [dbo].[Calendars]
ADD CONSTRAINT [FK_AspNetUserCalendar]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserCalendar'
CREATE INDEX [IX_FK_AspNetUserCalendar]
ON [dbo].[Calendars]
    ([AspNetUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------