/****** Object:  Table [dbo].[tbChat]    Script Date: 27/04/2023 13:46:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbChat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fromUserId] [int] NOT NULL,
	[toUserId] [int] NOT NULL,
	[message] [nvarchar](255) NULL,
	[accesstime] [datetime] NOT NULL,
 CONSTRAINT [PK_tbChat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbComment]    Script Date: 27/04/2023 13:46:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[CommenterId] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
	[AccessTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tbComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbPost]    Script Date: 27/04/2023 13:46:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[postContent] [nvarchar](255) NULL,
	[postPhoto] [nvarchar](255) NULL,
	[isDeleted] [bit] NOT NULL,
	[accessTime] [datetime] NOT NULL,
 CONSTRAINT [PK_tbPost_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 27/04/2023 13:46:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[isDeleted] [bit] NOT NULL,
	[accesstime] [datetime] NOT NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbChat] ON 

INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (1, 0, 2, N'test', CAST(N'2023-04-20T13:43:41.197' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (2, 1, 2, N'hello', CAST(N'2023-04-20T13:44:15.837' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (3, 1, 2, N'jj', CAST(N'2023-04-20T13:44:39.540' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (4, 0, 1, N'hi', CAST(N'2023-04-20T13:45:19.667' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (5, 2, 1, N'test', CAST(N'2023-04-20T13:45:40.953' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (6, 2, 1, N'hi', CAST(N'2023-04-20T13:46:32.843' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (7, 2, 1, N'hh', CAST(N'2023-04-20T13:46:59.190' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (8, 2, 3, N'Hello John', CAST(N'2023-04-20T13:56:20.370' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (9, 2, 1, N'Hey', CAST(N'2023-04-20T13:56:44.810' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (10, 1, 3, N'hi', CAST(N'2023-04-20T13:58:36.630' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (11, 1, 3, N'hey', CAST(N'2023-04-20T14:15:54.620' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (12, 3, 1, N'hi', CAST(N'2023-04-20T14:16:05.713' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (13, 3, 1, N'what r u doing', CAST(N'2023-04-20T14:16:12.547' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (14, 3, 2, N'hey', CAST(N'2023-04-20T14:22:13.650' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (15, 3, 1, N'nothing', CAST(N'2023-04-20T14:22:59.947' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (16, 1, 3, N'hi', CAST(N'2023-04-20T15:49:33.770' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (17, 3, 1, N'hey', CAST(N'2023-04-20T15:49:50.993' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (18, 3, 1, N'd', CAST(N'2023-04-20T16:07:43.043' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (19, 1, 2, N'Hi', CAST(N'2023-04-20T16:11:16.430' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (20, 1, 3, N'yo', CAST(N'2023-04-20T16:11:23.310' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (21, 3, 1, N'hello', CAST(N'2023-04-21T09:39:47.910' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (22, 1, 3, N'hii', CAST(N'2023-04-21T09:39:55.790' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (23, 0, 1, N'Hi', CAST(N'2023-04-24T09:12:07.430' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (24, 0, 1, N'Hi', CAST(N'2023-04-24T09:12:18.453' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (25, 0, 3, N'Hi', CAST(N'2023-04-24T09:12:22.237' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (26, 0, 1, N'd', CAST(N'2023-04-24T09:12:39.377' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (27, 0, 3, N'Hello', CAST(N'2023-04-24T09:13:07.207' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (28, 0, 2, N'Hi', CAST(N'2023-04-24T09:13:57.763' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (29, 0, 2, N'fsd', CAST(N'2023-04-24T09:13:59.557' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (30, 0, 1, N'Hi', CAST(N'2023-04-24T09:26:05.853' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (31, 0, 1, N'dd', CAST(N'2023-04-24T09:26:22.553' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (32, 0, 1, N'hi', CAST(N'2023-04-24T09:28:00.457' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (33, 0, 3, N'hi', CAST(N'2023-04-24T09:34:02.910' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (34, 0, 3, N'hi', CAST(N'2023-04-24T09:34:34.190' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (35, 1, 2, N'hi', CAST(N'2023-04-24T09:38:45.803' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (36, 1, 3, N'hey', CAST(N'2023-04-24T09:38:58.063' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (37, 0, 1, N'yes', CAST(N'2023-04-24T09:39:41.873' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (38, 0, 1, N'no', CAST(N'2023-04-24T09:39:56.023' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (39, 1, 3, N'dfad', CAST(N'2023-04-24T09:40:56.070' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (40, 1, 3, N'hi', CAST(N'2023-04-24T09:41:08.813' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (41, 3, 1, N'hi', CAST(N'2023-04-24T09:41:12.490' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (42, 3, 1, N'hi', CAST(N'2023-04-24T09:41:22.407' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (43, 1, 3, N'yes', CAST(N'2023-04-24T09:41:31.427' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (44, 1, 3, N'hiya', CAST(N'2023-04-24T09:42:17.923' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (45, 3, 1, N'no', CAST(N'2023-04-24T09:42:32.100' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (46, 1, 3, N'Hya', CAST(N'2023-04-24T09:42:40.007' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (47, 1, 3, N'asdf', CAST(N'2023-04-24T09:42:50.947' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (48, 1, 3, N'asdfasdf', CAST(N'2023-04-24T09:42:56.027' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (49, 3, 1, N'asdfd', CAST(N'2023-04-24T09:42:59.100' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (50, 3, 1, N'da', CAST(N'2023-04-24T09:43:02.157' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (51, 1, 3, N'yes', CAST(N'2023-04-24T15:46:21.733' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (52, 1, 3, N'yes', CAST(N'2023-04-24T15:46:21.733' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (53, 1, 3, N'yes', CAST(N'2023-04-24T15:46:21.733' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (54, 1, 3, N'yes', CAST(N'2023-04-24T15:46:44.643' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (55, 1, 3, N'yes', CAST(N'2023-04-24T15:46:53.133' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (56, 0, 1, N'no', CAST(N'2023-04-24T15:47:09.587' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (57, 3, 1, N'no', CAST(N'2023-04-24T15:47:18.337' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (58, 1, 2, N'hi', CAST(N'2023-04-24T15:56:29.217' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (59, 1, 2, N'hello', CAST(N'2023-04-24T15:56:41.530' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (60, 0, 1, N'hi', CAST(N'2023-04-24T16:30:02.527' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (61, 3, 1, N'hi', CAST(N'2023-04-24T16:30:08.867' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (62, 1, 3, N'hey John', CAST(N'2023-04-24T16:30:17.700' AS DateTime))
INSERT [dbo].[tbChat] ([id], [fromUserId], [toUserId], [message], [accesstime]) VALUES (63, 1, 3, N'hey John', CAST(N'2023-04-24T16:30:17.707' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbChat] OFF
GO
SET IDENTITY_INSERT [dbo].[tbPost] ON 

INSERT [dbo].[tbPost] ([Id], [userId], [postContent], [postPhoto], [isDeleted], [accessTime]) VALUES (52, 3, N'Test pic', N'12960328-efba-479c-a641-14e0d8e7e218.jpg', 0, CAST(N'2023-04-27T11:40:57.377' AS DateTime))
INSERT [dbo].[tbPost] ([Id], [userId], [postContent], [postPhoto], [isDeleted], [accessTime]) VALUES (53, 3, NULL, N'952958c5-3f5d-4694-bf84-7bab434a59a3.jpg', 0, CAST(N'2023-04-27T11:42:22.333' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbPost] OFF
GO
SET IDENTITY_INSERT [dbo].[tbUser] ON 

INSERT [dbo].[tbUser] ([id], [username], [password], [isDeleted], [accesstime]) VALUES (1, N'test', N'dGVzdA==', 0, CAST(N'2023-04-20T13:40:44.990' AS DateTime))
INSERT [dbo].[tbUser] ([id], [username], [password], [isDeleted], [accesstime]) VALUES (2, N'test 2', N'dGVzdDI=', 0, CAST(N'2023-04-20T13:41:16.867' AS DateTime))
INSERT [dbo].[tbUser] ([id], [username], [password], [isDeleted], [accesstime]) VALUES (3, N'John', N'am9obg==', 0, CAST(N'2023-04-20T13:50:18.527' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbUser] OFF
GO
