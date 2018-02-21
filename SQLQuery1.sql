
CREATE TABLE [dbo].[Academies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Academies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[User_Id] [uniqueidentifier] NOT NULL,
	[Year_Id] [uniqueidentifier] NOT NULL,
	[Establishment_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Classrooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cycles]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cycles](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cycles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Establishments]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Establishments](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[Town] [nvarchar](50) NOT NULL,
	[User_Id] [uniqueidentifier] NOT NULL,
	[Academie_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Establishments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluations]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluations](
	[Id] [uniqueidentifier] NOT NULL,
	[Classroom_Id] [uniqueidentifier] NOT NULL,
	[User_Id] [uniqueidentifier] NOT NULL,
	[Period_Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[TotalPoint] [int] NOT NULL,
 CONSTRAINT [PK_Evaluations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Levels]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Levels](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Cycle_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Levels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Periods]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periods](
	[Id] [uniqueidentifier] NOT NULL,
	[Begin] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Year_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Periods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pupils]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pupils](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Sex] [smallint] NOT NULL,
	[BirthdayDate] [datetime] NOT NULL,
	[State] [smallint] NOT NULL,
	[Tutor_Id] [uniqueidentifier] NOT NULL,
	[Classroom_Id] [uniqueidentifier] NOT NULL,
	[Level_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Pupils] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Results]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[Id] [uniqueidentifier] NOT NULL,
	[Evaluation_Id] [uniqueidentifier] NOT NULL,
	[Pupil_Id] [uniqueidentifier] NOT NULL,
	[Note] [float] NOT NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tutors]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutors](
	[Id] [uniqueidentifier] NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[PostCode] [nvarchar](50) NOT NULL,
	[Town] [nvarchar](50) NOT NULL,
	[Tel] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Tutors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Years]    Script Date: 11/12/2014 13:06:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Years](
	[Id] [uniqueidentifier] NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Years] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Academies] ADD  CONSTRAINT [DF_Academies_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Classrooms] ADD  CONSTRAINT [DF_Classrooms_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Cycles] ADD  CONSTRAINT [DF_Cycles_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Establishments] ADD  CONSTRAINT [DF_Establishments_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Evaluations] ADD  CONSTRAINT [DF_Evaluations_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Levels] ADD  CONSTRAINT [DF_Levels_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Periods] ADD  CONSTRAINT [DF_Periods_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Pupils] ADD  CONSTRAINT [DF_Pupils_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Results] ADD  CONSTRAINT [DF_Results_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Tutors] ADD  CONSTRAINT [DF_Tutors_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Years] ADD  CONSTRAINT [DF_Years_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Establishments] FOREIGN KEY([Establishment_Id])
REFERENCES [dbo].[Establishments] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Establishments]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Users]
GO
ALTER TABLE [dbo].[Classrooms]  WITH CHECK ADD  CONSTRAINT [FK_Classrooms_Years] FOREIGN KEY([Year_Id])
REFERENCES [dbo].[Years] ([Id])
GO
ALTER TABLE [dbo].[Classrooms] CHECK CONSTRAINT [FK_Classrooms_Years]
GO
ALTER TABLE [dbo].[Establishments]  WITH CHECK ADD  CONSTRAINT [FK_Establishments_Academies] FOREIGN KEY([Academie_Id])
REFERENCES [dbo].[Academies] ([Id])
GO
ALTER TABLE [dbo].[Establishments] CHECK CONSTRAINT [FK_Establishments_Academies]
GO
ALTER TABLE [dbo].[Establishments]  WITH CHECK ADD  CONSTRAINT [FK_Establishments_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Establishments] CHECK CONSTRAINT [FK_Establishments_Users]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Classrooms] FOREIGN KEY([Classroom_Id])
REFERENCES [dbo].[Classrooms] ([Id])
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Classrooms]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Periods] FOREIGN KEY([Period_Id])
REFERENCES [dbo].[Periods] ([Id])
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Periods]
GO
ALTER TABLE [dbo].[Evaluations]  WITH CHECK ADD  CONSTRAINT [FK_Evaluations_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Evaluations] CHECK CONSTRAINT [FK_Evaluations_Users]
GO
ALTER TABLE [dbo].[Levels]  WITH CHECK ADD  CONSTRAINT [FK_Levels_Cycles] FOREIGN KEY([Cycle_Id])
REFERENCES [dbo].[Cycles] ([Id])
GO
ALTER TABLE [dbo].[Levels] CHECK CONSTRAINT [FK_Levels_Cycles]
GO
ALTER TABLE [dbo].[Periods]  WITH CHECK ADD  CONSTRAINT [FK_Periods_Years] FOREIGN KEY([Year_Id])
REFERENCES [dbo].[Years] ([Id])
GO
ALTER TABLE [dbo].[Periods] CHECK CONSTRAINT [FK_Periods_Years]
GO
ALTER TABLE [dbo].[Pupils]  WITH CHECK ADD  CONSTRAINT [FK_Pupils_Classrooms] FOREIGN KEY([Classroom_Id])
REFERENCES [dbo].[Classrooms] ([Id])
GO
ALTER TABLE [dbo].[Pupils] CHECK CONSTRAINT [FK_Pupils_Classrooms]
GO
ALTER TABLE [dbo].[Pupils]  WITH CHECK ADD  CONSTRAINT [FK_Pupils_Levels] FOREIGN KEY([Level_Id])
REFERENCES [dbo].[Levels] ([Id])
GO
ALTER TABLE [dbo].[Pupils] CHECK CONSTRAINT [FK_Pupils_Levels]
GO
ALTER TABLE [dbo].[Pupils]  WITH CHECK ADD  CONSTRAINT [FK_Pupils_Tutors] FOREIGN KEY([Tutor_Id])
REFERENCES [dbo].[Tutors] ([Id])
GO
ALTER TABLE [dbo].[Pupils] CHECK CONSTRAINT [FK_Pupils_Tutors]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Evaluations] FOREIGN KEY([Evaluation_Id])
REFERENCES [dbo].[Evaluations] ([Id])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Evaluations]
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Pupils] FOREIGN KEY([Pupil_Id])
REFERENCES [dbo].[Pupils] ([Id])
GO
ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Pupils]
GO
USE [master]
GO
ALTER DATABASE [Academy] SET  READ_WRITE 
GO