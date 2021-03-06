USE [master]
GO
/****** Object:  Database [Epam.Task10]    Script Date: 22.02.2020 15:44:56 ******/
CREATE DATABASE [Epam.Task10]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Epam.Task10', FILENAME = N'E:\Work\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Epam.Task10.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Epam.Task10_log', FILENAME = N'E:\Work\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Epam.Task10_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Epam.Task10] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Epam.Task10].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Epam.Task10] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Epam.Task10] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Epam.Task10] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Epam.Task10] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Epam.Task10] SET ARITHABORT OFF 
GO
ALTER DATABASE [Epam.Task10] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Epam.Task10] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Epam.Task10] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Epam.Task10] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Epam.Task10] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Epam.Task10] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Epam.Task10] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Epam.Task10] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Epam.Task10] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Epam.Task10] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Epam.Task10] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Epam.Task10] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Epam.Task10] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Epam.Task10] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Epam.Task10] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Epam.Task10] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Epam.Task10] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Epam.Task10] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Epam.Task10] SET  MULTI_USER 
GO
ALTER DATABASE [Epam.Task10] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Epam.Task10] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Epam.Task10] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Epam.Task10] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Epam.Task10] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Epam.Task10] SET QUERY_STORE = OFF
GO
USE [Epam.Task10]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 22.02.2020 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AwardByUser]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardByUser](
	[Id_User] [int] NOT NULL,
	[Id_Award] [int] NOT NULL,
 CONSTRAINT [PK_AwardByUser] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC,
	[Id_Award] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Age] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_User1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAttachment]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAttachment](
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserAttachment] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAttachmentByRoles]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAttachmentByRoles](
	[Login_UserAttachment] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserAttachmentByRoles] PRIMARY KEY CLUSTERED 
(
	[Login_UserAttachment] ASC,
	[Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AwardByUser]  WITH CHECK ADD  CONSTRAINT [FK_AwardByUser_User] FOREIGN KEY([Id_User])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AwardByUser] CHECK CONSTRAINT [FK_AwardByUser_User]
GO
ALTER TABLE [dbo].[UserAttachmentByRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserAttachmentByRoles_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([Role])
GO
ALTER TABLE [dbo].[UserAttachmentByRoles] CHECK CONSTRAINT [FK_UserAttachmentByRoles_Roles]
GO
ALTER TABLE [dbo].[UserAttachmentByRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserAttachmentByRoles_UserAttachment] FOREIGN KEY([Login_UserAttachment])
REFERENCES [dbo].[UserAttachment] ([Login])
GO
ALTER TABLE [dbo].[UserAttachmentByRoles] CHECK CONSTRAINT [FK_UserAttachmentByRoles_UserAttachment]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAward]
	@Title nvarchar(50),
	@Id int output

AS
	INSERT INTO Award(Title) 
	VALUES (@Title)
	SET @Id = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[AddAwardImage]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAwardImage]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Image nvarchar(MAX)
AS
BEGIN
	UPDATE Award SET Image = @Image
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@Name nvarchar(50),
	@DateOfBirth date,
	@Age int,
	@Id int output

AS
	INSERT INTO "User" ("Name",DateOfBirth,Age) 
	VALUES (@Name, @DateOfBirth, @Age)
	SET @Id = SCOPE_IDENTITY();
GO
/****** Object:  StoredProcedure [dbo].[AddUserAttachment]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserAttachment]
	@Login nvarchar(50),
	@Password nvarchar(50)

AS
	INSERT INTO UserAttachment(Login,Password) 
	VALUES (@Login, @Password)
GO
/****** Object:  StoredProcedure [dbo].[AddUserAttachmentRole]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[AddUserAttachmentRole]
	@Login nvarchar(50),
	@Role nvarchar(50)

AS
	INSERT INTO UserAttachmentByRoles (Login_UserAttachment,"Role") 
	VALUES (@Login, @Role)
GO
/****** Object:  StoredProcedure [dbo].[AddUserAward]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserAward]
	@IdUser int,
	@IdAward int

AS
	INSERT INTO AwardByUser(Id_User,Id_Award) 
	VALUES (@IdUser, @IdAward)
GO
/****** Object:  StoredProcedure [dbo].[AddUserImage]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUserImage] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Image nvarchar(MAX)
AS
BEGIN
	UPDATE "User" SET Image = @Image
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAward]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAward]
AS
	SET NOCOUNT ON;
	SELECT Id, Title FROM Award
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers] 
AS
	SET NOCOUNT ON;
	SELECT u.Id, u."Name", u.DateOfBirth, u.Age, u."Image", a.Id_Award FROM "User" AS u
	LEFT JOIN AwardByUser AS a ON u.Id = a.Id_User
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsersAttachment]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsersAttachment] 
AS
	SET NOCOUNT ON;
	SELECT u.Login, u.Password, r.Role FROM UserAttachment AS u
	LEFT JOIN UserAttachmentByRoles AS r ON u.Login = r.Login_UserAttachment
GO
/****** Object:  StoredProcedure [dbo].[GetAwardImage]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardImage] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	SELECT "Image" FROM Award
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardTitle]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardTitle] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	SELECT Title FROM Award
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserImage]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserImage] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	SELECT "Image" FROM "User"
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveAdwardAllUsers]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAdwardAllUsers]
	@Id int
AS
	DELETE AwardByUser
	WHERE Id_Award = @Id
GO
/****** Object:  StoredProcedure [dbo].[RemoveAward]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAward]
	@Id int
AS
	DELETE Award
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RemoveAwardImage]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAwardImage]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Image nvarchar(MAX)
AS
BEGIN
	UPDATE Award SET Image = @Image
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUser]
	@Id int
AS
	DELETE "User"
	WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[RemoveUserImage]    Script Date: 22.02.2020 15:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUserImage]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Image nvarchar(MAX)
AS
BEGIN
	UPDATE "User" SET Image = @Image
	WHERE Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [Epam.Task10] SET  READ_WRITE 
GO
