USE [master]
GO
/****** Object:  Database [database]    Script Date: 2022/12/26 20:19:41 ******/
CREATE DATABASE [database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'database', FILENAME = N'D:\sqlserver\MSSQL15.MSSQLSERVER\MSSQL\DATA\database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'database_log', FILENAME = N'D:\sqlserver\MSSQL15.MSSQLSERVER\MSSQL\DATA\database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [database] SET ARITHABORT OFF 
GO
ALTER DATABASE [database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [database] SET RECOVERY FULL 
GO
ALTER DATABASE [database] SET  MULTI_USER 
GO
ALTER DATABASE [database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'database', N'ON'
GO
ALTER DATABASE [database] SET QUERY_STORE = OFF
GO
USE [database]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [uniqueidentifier] NOT NULL,
	[userName] [nvarchar](20) NULL,
	[password] [nvarchar](20) NULL,
	[name] [nvarchar](10) NULL,
	[sex] [int] NULL,
	[tel] [nchar](11) NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dormbuild]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dormbuild](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](10) NOT NULL,
	[detail] [nvarchar](100) NULL,
	[dormmanager] [uniqueidentifier] NULL,
	[sex] [int] NOT NULL,
 CONSTRAINT [PK_dormbuild] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dormitory]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dormitory](
	[id] [uniqueidentifier] NOT NULL,
	[dormBuildId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_dormitory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dormmanager]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dormmanager](
	[id] [uniqueidentifier] NOT NULL,
	[userName] [nvarchar](20) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
	[sex] [int] NOT NULL,
	[tel] [nchar](11) NOT NULL,
 CONSTRAINT [PK_dormmanager] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notice]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notice](
	[id] [uniqueidentifier] NOT NULL,
	[date] [datetime2](7) NOT NULL,
	[content] [nvarchar](500) NOT NULL,
	[Pid] [uniqueidentifier] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_notice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[repair]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[repair](
	[id] [uniqueidentifier] NOT NULL,
	[thing] [nvarchar](50) NULL,
	[detail] [nvarchar](100) NULL,
	[reportTime] [datetime2](7) NULL,
	[status] [int] NULL,
	[dormitoryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_repair] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[student]    Script Date: 2022/12/26 20:19:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[student](
	[id] [uniqueidentifier] NOT NULL,
	[stuNum] [nchar](10) NOT NULL,
	[password] [nvarchar](20) NOT NULL,
	[name] [nvarchar](10) NOT NULL,
	[dormitoryId] [uniqueidentifier] NOT NULL,
	[sex] [int] NOT NULL,
	[tel] [nchar](11) NOT NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dormbuild] ADD  DEFAULT (N'') FOR [name]
GO
ALTER TABLE [dbo].[dormbuild] ADD  DEFAULT ((0)) FOR [sex]
GO
ALTER TABLE [dbo].[notice] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [date]
GO
ALTER TABLE [dbo].[notice] ADD  DEFAULT (N'') FOR [content]
GO
ALTER TABLE [dbo].[notice] ADD  DEFAULT (N'') FOR [title]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'userName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'admin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宿舍楼Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormbuild', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宿舍楼名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormbuild', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'详细说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormbuild', @level2type=N'COLUMN',@level2name=N'detail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormbuild', @level2type=N'COLUMN',@level2name=N'dormmanager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宿舍楼居住人的性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormbuild', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储宿舍楼信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormbuild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寝室Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormitory', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属宿舍楼Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormitory', @level2type=N'COLUMN',@level2name=N'dormBuildId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寝室名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormitory', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寝室管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormitory'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宿舍管理员Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名，用于登录系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager', @level2type=N'COLUMN',@level2name=N'userName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主要存储宿舍管理员信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dormmanager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'notice', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告发布日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'notice', @level2type=N'COLUMN',@level2name=N'date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'notice', @level2type=N'COLUMN',@level2name=N'content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告发布人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'notice', @level2type=N'COLUMN',@level2name=N'Pid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'notice', @level2type=N'COLUMN',@level2name=N'title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于存储公告信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'notice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报修Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上报物品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'thing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'物品详细描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'detail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上报时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'reportTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报修状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报修寝室' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair', @level2type=N'COLUMN',@level2name=N'dormitoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用于存储报修记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'repair'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生Id，唯一' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生学号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'stuNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寝室Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'dormitoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student', @level2type=N'COLUMN',@level2name=N'tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生表，用于存放学生信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'student'
GO
USE [master]
GO
ALTER DATABASE [database] SET  READ_WRITE 
GO
