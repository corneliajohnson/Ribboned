USE [Ribboned]
GO
SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile]
  ([Id], [UserName], [Email], [ImageUrl], [FirebaseUserId])
VALUES 
  (1, 'default', 'default@gmail.com', null, 'Q75GIfb9wsZNbWUawJUXKuxz3dfh'),
  (2, 'cornelia', 'cornelia@gmail.com', null, 'Q75GIr0mwsZNbWUawJUXKuxz3aK2'),
  (3, 'maggie', 'maggie@gmail.com', null, 'B63utnxScVcvmSVmXJge0dGicoT2'),
  (4, 'whitney', 'whitney@gmail.com', null, 'GEaiQvPXV7SoEFC7kXFNW9a0F7Q2');
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Category] ON
INSERT INTO [Category] 
([Id], [Name], [UserProfileId])
VALUES (1, 'Other', 1)
SET IDENTITY_INSERT [Category] OFF

SET IDENTITY_INSERT [Source] ON
INSERT INTO [Source]
([Id], [Type])
VALUES (1, 'Other'),
(2, 'YouTube'),
(3, 'Local');
SET  IDENTITY_INSERT [Source] OFF

SET IDENTITY_INSERT [Snag] ON
INSERT INTO [Snag]
([Id], [RibbonId], [DateCreated], [Note], [Seconds])
VALUES (1, 1,'2020-06-12', 'Note One', 30),
(2,1, '2020-06-13', 'Note Two', 45),
(3,2, '2020-06-14', 'Note Free', 65);
SET IDENTITY_INSERT [Snag] OFF

SET IDENTITY_INSERT [Ribbon] ON
INSERT INTO [Ribbon]
([Id], [Title], [Decription],[SourceId],[UserProfileId],[URL],[DateCreated])
VALUES (1, 'Web Development In 2021', 'Decription', 1, 2, 'https://youtu.be/MLIKTBvgAGY', '2020-03-15'),
(2, '$37K to $125K+ by teaching myself to code and becoming a software engineer', 'Decription', 1, 2, 'https://youtu.be/NyCyknm_n8M', '2020-03-15');
SET IDENTITY_INSERT [Ribbon] OFF