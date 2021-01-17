USE [master]
GO
IF db_id('Ribboned') IS NULL
  CREATE DATABASE [Ribboned]
GO
USE [ribboned]
GO

DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Ribbon];
DROP TABLE IF EXISTS [Snag];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [Source];


CREATE TABLE [Ribbon] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Title] nvarchar (100) NOT NULL,
  [Decription] nvarchar (255) NOT NULL,
  [CategoryId] integer NOT NULL,
  [SourceId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,
  [URL] nvarchar (555) NOT NULL,
  [DateCreated] datetime NOT NULL,
  [DurationSeconds] integer
)
GO

CREATE TABLE [Snag] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [RibbonId] integer NOT NULL,
  [DateCreated] datetime NOT NULL,
  [Note] nvarchar (1000) NOT NULL,
  [Seconds] integer
)
GO

CREATE TABLE [Category] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Name] nvarchar (55) NOT NULL
)
GO

CREATE TABLE [Source] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [Type] nvarchar (55) NOT NULL
)
GO

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY identity NOT NULL,
  [UserName] nvarchar(255) NOT NULL,
  [Email] nvarchar (255) NOT NULL,
  [ImageUrl] nvarchar (555),
  [FirebaseUserId] nvarchar (100)
)
GO

ALTER TABLE [Ribbon] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
GO

ALTER TABLE [Ribbon] ADD FOREIGN KEY ([SourceId]) REFERENCES [Source] ([Id])
GO

ALTER TABLE [Ribbon] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Snag] ADD FOREIGN KEY ([RibbonId]) REFERENCES [Ribbon] ([Id])
GO


