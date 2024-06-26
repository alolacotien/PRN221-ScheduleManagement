USE [master]
GO
/****** Object:  Database [ScheduleManagement]    Script Date: 11/06/2024 11:35:31 pm ******/
CREATE DATABASE [ScheduleManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScheduleManagement', FILENAME = N'D:\SQL2022\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ScheduleManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ScheduleManagement_log', FILENAME = N'D:\SQL2022\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ScheduleManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ScheduleManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScheduleManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScheduleManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScheduleManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScheduleManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScheduleManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScheduleManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScheduleManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScheduleManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScheduleManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScheduleManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScheduleManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScheduleManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScheduleManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScheduleManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [ScheduleManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ScheduleManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScheduleManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScheduleManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScheduleManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ScheduleManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ScheduleManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ScheduleManagement', N'ON'
GO
ALTER DATABASE [ScheduleManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [ScheduleManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ScheduleManagement]
GO
/****** Object:  Table [dbo].[GroupClass]    Script Date: 11/06/2024 11:35:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](255) NOT NULL,
 CONSTRAINT [classes_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 11/06/2024 11:35:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](255) NOT NULL,
 CONSTRAINT [rooms_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 11/06/2024 11:35:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[classId] [int] NOT NULL,
	[subjectId] [int] NOT NULL,
	[teacherId] [int] NOT NULL,
	[roomId] [int] NOT NULL,
	[slotId] [int] NOT NULL,
 CONSTRAINT [schedule_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slots]    Script Date: 11/06/2024 11:35:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slots](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[details] [nvarchar](255) NOT NULL,
	[slotName] [nvarchar](255) NOT NULL,
 CONSTRAINT [slots_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 11/06/2024 11:35:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](255) NOT NULL,
	[details] [nvarchar](255) NOT NULL,
 CONSTRAINT [subjects_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 11/06/2024 11:35:31 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](255) NOT NULL,
	[fullName] [nvarchar](255) NOT NULL,
 CONSTRAINT [teachers_id_primary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GroupClass] ON 

INSERT [dbo].[GroupClass] ([id], [code]) VALUES (1, N'SE1702')
INSERT [dbo].[GroupClass] ([id], [code]) VALUES (2, N'SE1712')
INSERT [dbo].[GroupClass] ([id], [code]) VALUES (3, N'SE1760')
INSERT [dbo].[GroupClass] ([id], [code]) VALUES (4, N'SE1703')
SET IDENTITY_INSERT [dbo].[GroupClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([id], [code]) VALUES (1, N'BE-113')
INSERT [dbo].[Rooms] ([id], [code]) VALUES (2, N'BE-416')
INSERT [dbo].[Rooms] ([id], [code]) VALUES (3, N'BE-114')
INSERT [dbo].[Rooms] ([id], [code]) VALUES (4, N'BE-410')
INSERT [dbo].[Rooms] ([id], [code]) VALUES (5, N'BE-209')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (336, 1, 2, 7, 1, 6)
INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (337, 2, 1, 2, 1, 2)
INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (338, 3, 6, 6, 2, 4)
INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (339, 1, 4, 4, 1, 7)
INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (340, 2, 8, 8, 5, 9)
INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (341, 3, 9, 9, 4, 11)
INSERT [dbo].[Schedule] ([id], [classId], [subjectId], [teacherId], [roomId], [slotId]) VALUES (342, 4, 5, 12, 3, 13)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Slots] ON 

INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (2, N'A24', N'A24')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (3, N'A35', N'A35')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (4, N'A63', N'A63')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (6, N'A52', N'A52')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (7, N'A46', N'A46')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (8, N'P24', N'P24')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (9, N'P35', N'P35')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (10, N'P63', N'P63')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (11, N'P52', N'P52')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (12, N'P46', N'P46')
INSERT [dbo].[Slots] ([id], [details], [slotName]) VALUES (13, N'slot 4 của thứ 3', N'P03')
SET IDENTITY_INSERT [dbo].[Slots] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (1, N'PRN221', N'	Advanced Cross-Platform Application Programming With .NET(PRN221)')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (2, N'SWD392', N'	SW Architecture and Design(SWD392)')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (3, N'PRM392', N'Mobile Programming(PRM392)')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (4, N'PRU212', N'	C# Programming and Unity(PRU212)')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (5, N'EXE101', N'	Experiential Entrepreneurship 1(EXE101)')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (6, N'SWT301', N'	Software Testing(SWT301)')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (8, N'SWP391', N'SWP')
INSERT [dbo].[Subjects] ([id], [code], [details]) VALUES (9, N'SWR302', N'SWR')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (2, N'ChiLP', N'Le Phuong Chi')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (4, N'KhuongPD', N'Phung Duy Khuong')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (5, N'KhangPQ', N'Pham Quang Khang')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (6, N'ThangPD', N'Pham Duc Thang')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (7, N'TriTD', N'Tran Dinh Tri')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (8, N'HaPN', N'Pham Ngoc Ha')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (9, N'HueCTM', N'Chu Thi Minh Hue')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (11, N'LinhDTT', N'Do Thi Thuy Linh')
INSERT [dbo].[Teachers] ([id], [code], [fullName]) VALUES (12, N'AnhLH', N'Le Hoang Anh')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [schedule_classid_foreign] FOREIGN KEY([classId])
REFERENCES [dbo].[GroupClass] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [schedule_classid_foreign]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [schedule_roomid_foreign] FOREIGN KEY([roomId])
REFERENCES [dbo].[Rooms] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [schedule_roomid_foreign]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [schedule_subjectid_foreign] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subjects] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [schedule_subjectid_foreign]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [schedule_teacherid_foreign] FOREIGN KEY([teacherId])
REFERENCES [dbo].[Teachers] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [schedule_teacherid_foreign]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [schedule_timeslotid_foreign] FOREIGN KEY([slotId])
REFERENCES [dbo].[Slots] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [schedule_timeslotid_foreign]
GO
USE [master]
GO
ALTER DATABASE [ScheduleManagement] SET  READ_WRITE 
GO
