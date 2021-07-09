USE [master]
GO

/****** Object:  Database [database1]    Script Date: 7/9/2021 2:46:46 AM ******/
CREATE DATABASE [database1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'database1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\database1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'database1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\database1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [database1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [database1] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [database1] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [database1] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [database1] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [database1] SET ARITHABORT OFF 
GO

ALTER DATABASE [database1] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [database1] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [database1] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [database1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [database1] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [database1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [database1] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [database1] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [database1] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [database1] SET  DISABLE_BROKER 
GO

ALTER DATABASE [database1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [database1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [database1] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [database1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [database1] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [database1] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [database1] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [database1] SET RECOVERY FULL 
GO

ALTER DATABASE [database1] SET  MULTI_USER 
GO

ALTER DATABASE [database1] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [database1] SET DB_CHAINING OFF 
GO

ALTER DATABASE [database1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [database1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [database1] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [database1] SET QUERY_STORE = OFF
GO

ALTER DATABASE [database1] SET  READ_WRITE 
GO


