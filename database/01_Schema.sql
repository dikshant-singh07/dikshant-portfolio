USE [PortfolioDb]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 26-09-2026 15:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[GithubUrl] [nvarchar](500) NULL,
	[LiveUrl] [nvarchar](500) NULL,
	[CreatedAt] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectSkills]    Script Date: 26-09-2026 15:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectSkills](
	[ProjectId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectSkills] PRIMARY KEY CLUSTERED
(
	[ProjectId] ASC,
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTechnologies]    Script Date: 26-09-2026 15:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTechnologies](
	[ProjectId] [int] NOT NULL,
	[TechnologyId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectTechnologies] PRIMARY KEY CLUSTERED
(
	[ProjectId] ASC,
	[TechnologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 26-09-2026 15:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[SkillId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Skills_Name] UNIQUE NONCLUSTERED
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Technologies]    Script Date: 26-09-2026 15:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technologies](
	[TechnologyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Technologies] PRIMARY KEY CLUSTERED
(
	[TechnologyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Technologies_Name] UNIQUE NONCLUSTERED
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_CreatedAt]  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ProjectSkills]  WITH CHECK ADD  CONSTRAINT [FK_ProjectSkills_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectSkills] CHECK CONSTRAINT [FK_ProjectSkills_Projects]
GO
ALTER TABLE [dbo].[ProjectSkills]  WITH CHECK ADD  CONSTRAINT [FK_ProjectSkills_Skills] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([SkillId])
GO
ALTER TABLE [dbo].[ProjectSkills] CHECK CONSTRAINT [FK_ProjectSkills_Skills]
GO
ALTER TABLE [dbo].[ProjectTechnologies]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTechnologies_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectTechnologies] CHECK CONSTRAINT [FK_ProjectTechnologies_Projects]
GO
ALTER TABLE [dbo].[ProjectTechnologies]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTechnologies_Technologies] FOREIGN KEY([TechnologyId])
REFERENCES [dbo].[Technologies] ([TechnologyId])
GO
ALTER TABLE [dbo].[ProjectTechnologies] CHECK CONSTRAINT [FK_ProjectTechnologies_Technologies]
GO

USE [PortfolioDb]
GO

/****** Object:  Table [dbo].[Experience]    Script Date: 26-09-2026 21:34:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Experience](
	[ExperienceId] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](150) NOT NULL,
	[JobTitle] [nvarchar](150) NOT NULL,
	[Location] [nvarchar](150) NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[IsCurrent] [bit] NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED
(
	[ExperienceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Experience] ADD  CONSTRAINT [DF_Experience_IsCurrent]  DEFAULT ((0)) FOR [IsCurrent]
GO
