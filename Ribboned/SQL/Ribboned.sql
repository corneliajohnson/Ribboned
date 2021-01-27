  USE [master]

IF db_id('Ribboned') IS NULL
  CREATE DATABASE [Ribboned]
GO

USE [Ribboned]
GO


DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [Ribbon];
DROP TABLE IF EXISTS [Snag];
DROP TABLE IF EXISTS [Source];
DROP TABLE IF EXISTS [UserProfile];

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserName] nvarchar(50) NOT NULL,
  [Email] nvarchar(100) NOT NULL,
  [ImageUrl] nvarchar(255),
  [FirebaseUserId] nvarchar(28) NOT NULL,

  CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId),
  CONSTRAINT UQ_Email UNIQUE(Email)
)

CREATE TABLE [Source] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Type] nvarchar(50) NOT NULL
)

CREATE TABLE [Category] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [Name] nvarchar(50) NOT NULL,

  CONSTRAINT [FK_Category_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)


CREATE TABLE [Ribbon] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Title] nvarchar(100) NOT NULL,
  [Decription] nvarchar(255),
  [SourceId] integer NOT NULL,
  [URL] nvarchar(255) NOT NULL,
  [DateCreated] datetime NOT NULL,
  [CategoryId] integer NOT NULL,

 CONSTRAINT [FK_Ribbon_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]),
 CONSTRAINT [FK_Ribbon_Source] FOREIGN KEY ([SourceId]) REFERENCES [Source] ([Id]),
)

CREATE TABLE [Snag] (
  [Id] integer PRIMARY KEY IDENTITY,
  [RibbonId] integer NOT NULL,
  [DateCreated] datetime NOT NULL,
  [Note] nvarchar(500) NOT NULL,
  [Seconds] integer NOT NULL,

  CONSTRAINT [FK_Snag_Ribbon] FOREIGN KEY ([RibbonId]) REFERENCES [Ribbon] ([Id])
)
GO
