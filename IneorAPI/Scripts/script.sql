USE [master]
GO
/****** Object:  Database [Ineor]    Script Date: 05/11/2019 00:23:39 ******/
 If(db_id(N'Ineor') IS NULL)
	CREATE DATABASE Ineor
	 CONTAINMENT = NONE
	 ON  PRIMARY 
	( NAME = N'Ineor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Ineor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
	 LOG ON 
	( NAME = N'Ineor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Ineor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Ineor] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ineor].[dbo].[sp_fulltext_database] @action = 'enable'
end
USE [Ineor]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 05/11/2019 00:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF not exists (select * from sysobjects where name='Book' and xtype='U')
	CREATE TABLE [dbo].[Book](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Author] [nvarchar](50) NOT NULL,
		[Price] [int] NOT NULL,
		[DatePublished] [date] NOT NULL,
	 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Ineor] SET  READ_WRITE 
GO
