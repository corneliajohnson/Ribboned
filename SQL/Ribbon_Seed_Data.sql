USE [Ribboned]
GO
SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile]
  ([Id], [UserName], [Email], [ImageUrl], [FirebaseUserId])
VALUES 
  (1, 'cornelia', 'cornelia@gmail.com', null, null),
  (2, 'maggie', 'maggie@gmail.com', null, null);
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Category] ON
INSERT INTO [Category] 
([Id], [Name])
VALUES (1, 'Film & Animation'),
(2, 'Autos & Vehicles'),
(3, 'Music'),
(4, 'Pet & Animals'),
(5, 'Sports'),
(6, 'Travel & Events'),
(7, 'Gaming'),
(8, 'People & Blogs'),
(9, 'Entertainment'),
(10, 'News & Politics'),
(11, 'Howto & Style'),
(12, 'Education'),
(13, 'Science & Technology'),
(14, 'Nonprofits & Activism'),
(15, 'Dance'),
(16, 'Finance'),
(17, 'Other');
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
([Id], [Title], [Decription],[CategoryId],[SourceId],[UserProfileId],[URL],[DateCreated],[DurationSeconds])
VALUES (1, 'Web Development In 2021', 'Decription', 1, 2, 1, 'https://youtu.be/MLIKTBvgAGY', '2020-03-15', 500),
(2, '$37K to $125K+ by teaching myself to code and becoming a software engineer', 'Decription', 1, 2, 1, 'https://youtu.be/NyCyknm_n8M', '2020-03-15', 500);
SET IDENTITY_INSERT [Ribbon] OFF