USE [master]
GO
/****** Object:  Database [StudentDb]    Script Date: 11.09.2021 14:50:16 ******/
CREATE DATABASE [StudentDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentDb', FILENAME = N'C:\Users\azder\StudentDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentDb_log', FILENAME = N'C:\Users\azder\StudentDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentDb] SET  MULTI_USER 
GO
ALTER DATABASE [StudentDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentDb] SET QUERY_STORE = OFF
GO
USE [StudentDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [StudentDb]
GO
/****** Object:  Table [dbo].[Clubs]    Script Date: 11.09.2021 14:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clubs](
	[clubId] [int] IDENTITY(1,1) NOT NULL,
	[clubName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[clubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 11.09.2021 14:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[lessId] [tinyint] IDENTITY(1,1) NOT NULL,
	[lessName] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[lessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 11.09.2021 14:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[scoreId] [int] IDENTITY(1,1) NOT NULL,
	[lessId] [tinyint] NULL,
	[stuId] [int] NULL,
	[exam1] [tinyint] NULL,
	[exam2] [tinyint] NULL,
	[exam3] [tinyint] NULL,
	[projectScore] [tinyint] NULL,
	[average] [decimal](5, 2) NULL,
	[scoreStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[scoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11.09.2021 14:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[stuId] [int] IDENTITY(1,1) NOT NULL,
	[stuName] [nvarchar](50) NULL,
	[stuSurname] [nvarchar](50) NULL,
	[stuClub] [int] NULL,
	[stuSex] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[stuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 11.09.2021 14:50:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[tchId] [tinyint] IDENTITY(1,1) NOT NULL,
	[tchName] [nvarchar](50) NULL,
	[tchBranch] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[tchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clubs] ON 

INSERT [dbo].[Clubs] ([clubId], [clubName]) VALUES (1, N'Chess')
INSERT [dbo].[Clubs] ([clubId], [clubName]) VALUES (2, N'Algorithm')
INSERT [dbo].[Clubs] ([clubId], [clubName]) VALUES (3, N'Literature')
INSERT [dbo].[Clubs] ([clubId], [clubName]) VALUES (5, N'Turkish Language')
INSERT [dbo].[Clubs] ([clubId], [clubName]) VALUES (6, N'Doğayı Koruma')
INSERT [dbo].[Clubs] ([clubId], [clubName]) VALUES (7, N'Hayvanları Koruma')
SET IDENTITY_INSERT [dbo].[Clubs] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 

INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (1, N'Mathematic')
INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (2, N'Software Desing')
INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (3, N'Web Programming')
INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (4, N'Algorithm Analysis')
INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (5, N'Data Structures')
INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (6, N'OOP')
INSERT [dbo].[Lessons] ([lessId], [lessName]) VALUES (7, N'Yazılım Mühendisliği Temelleri')
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[Scores] ON 

INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (11, 1, 7, 50, 75, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (12, 1, 8, 45, 68, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (13, 1, 9, 90, 87, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (14, 1, 10, 65, 94, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (15, 1, 11, 86, 28, 75, 65, CAST(63.50 AS Decimal(5, 2)), 1)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (16, 2, 7, 87, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (17, 2, 8, 67, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (18, 2, 9, 97, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (19, 2, 10, 25, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (20, 2, 11, 0, 28, 0, 65, CAST(23.25 AS Decimal(5, 2)), 0)
INSERT [dbo].[Scores] ([scoreId], [lessId], [stuId], [exam1], [exam2], [exam3], [projectScore], [average], [scoreStatus]) VALUES (21, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Scores] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (7, N'Özgür', N'Tokay', 1, N'Erkek')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (8, N'Jenifer', N'Lawrance', 3, N'Kadin')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (9, N'Jenifer', N'Aniston', 2, N'Kadin')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (10, N'Margot', N'Robie', 1, N'Kadin')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (11, N'Barbara', N'Palvin', 1, N'Kadin')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (12, NULL, NULL, NULL, NULL)
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (13, N'Türkan', N'Şoray', 2, N'Kadin')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (14, N'İbrahim', N'Abak', 6, N'Erkek')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (15, N'Filiz', N'Akın', 7, N'Kadin')
INSERT [dbo].[Students] ([stuId], [stuName], [stuSurname], [stuClub], [stuSex]) VALUES (16, N'Mehmet', N'Tokay', 5, N'Erkek')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([tchId], [tchName], [tchBranch]) VALUES (1, N'Julia Roberts', 1)
INSERT [dbo].[Teachers] ([tchId], [tchName], [tchBranch]) VALUES (2, N'Scarlet Johanson', 2)
INSERT [dbo].[Teachers] ([tchId], [tchName], [tchBranch]) VALUES (3, N'Angelina Joly', 3)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD FOREIGN KEY([lessId])
REFERENCES [dbo].[Lessons] ([lessId])
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD FOREIGN KEY([stuId])
REFERENCES [dbo].[Students] ([stuId])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD FOREIGN KEY([stuClub])
REFERENCES [dbo].[Clubs] ([clubId])
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD FOREIGN KEY([tchBranch])
REFERENCES [dbo].[Lessons] ([lessId])
GO
USE [master]
GO
ALTER DATABASE [StudentDb] SET  READ_WRITE 
GO
