
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2018 21:23:34
-- Generated from EDMX file: c:\users\37155\documents\visual studio 2015\Projects\BancoDeDados\BancoDeDados\ModelFutebol.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Futebol];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TimeJogador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JogadorSet] DROP CONSTRAINT [FK_TimeJogador];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TimeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimeSet];
GO
IF OBJECT_ID(N'[dbo].[JogadorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JogadorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TimeSet'
CREATE TABLE [dbo].[TimeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Fundacao] datetime  NOT NULL
);
GO

-- Creating table 'JogadorSet'
CREATE TABLE [dbo].[JogadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimeId] int  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [NumeroDaCamisa] int  NOT NULL,
    [DataNascimento] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TimeSet'
ALTER TABLE [dbo].[TimeSet]
ADD CONSTRAINT [PK_TimeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JogadorSet'
ALTER TABLE [dbo].[JogadorSet]
ADD CONSTRAINT [PK_JogadorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TimeId] in table 'JogadorSet'
ALTER TABLE [dbo].[JogadorSet]
ADD CONSTRAINT [FK_TimeJogador]
    FOREIGN KEY ([TimeId])
    REFERENCES [dbo].[TimeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TimeJogador'
CREATE INDEX [IX_FK_TimeJogador]
ON [dbo].[JogadorSet]
    ([TimeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------