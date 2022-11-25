USE [SkillBill]
GO

/****** Object:  Table [dbo].[ChatUserinGroup]    Script Date: 25.11.2022 08:24:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ChatUserinGroup](
	[UserId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[LastVisit] [smalldatetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ChatUserinGroup]  WITH CHECK ADD  CONSTRAINT [FK_ChatUserinGroup_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[ChatUserinGroup] CHECK CONSTRAINT [FK_ChatUserinGroup_AspNetUsers]
GO

ALTER TABLE [dbo].[ChatUserinGroup]  WITH CHECK ADD  CONSTRAINT [FK_ChatUserinGroup_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO

ALTER TABLE [dbo].[ChatUserinGroup] CHECK CONSTRAINT [FK_ChatUserinGroup_Groups]
GO


CREATE TABLE [dbo].[ChatMess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[MessTyp] [int] NULL,
	[MessDate] [smalldatetime] NOT NULL,
	[MessText] [nvarchar](max) NOT NULL,
	[Appendix] [nvarchar](150) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ChatMess]  WITH CHECK ADD  CONSTRAINT [FK_ChatMess_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[ChatMess] CHECK CONSTRAINT [FK_ChatMess_AspNetUsers]
GO



