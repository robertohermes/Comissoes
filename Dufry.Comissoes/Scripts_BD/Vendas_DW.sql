USE [master]
GO
/****** Object:  Database [Vendas_DW]    Script Date: 11/09/2015 15:35:31 ******/
CREATE DATABASE [Vendas_DW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vendas_DW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Vendas_DW.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Vendas_DW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Vendas_DW_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Vendas_DW] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Vendas_DW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Vendas_DW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Vendas_DW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Vendas_DW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Vendas_DW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Vendas_DW] SET ARITHABORT OFF 
GO
ALTER DATABASE [Vendas_DW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Vendas_DW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Vendas_DW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Vendas_DW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Vendas_DW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Vendas_DW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Vendas_DW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Vendas_DW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Vendas_DW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Vendas_DW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Vendas_DW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Vendas_DW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Vendas_DW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Vendas_DW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Vendas_DW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Vendas_DW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Vendas_DW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Vendas_DW] SET RECOVERY FULL 
GO
ALTER DATABASE [Vendas_DW] SET  MULTI_USER 
GO
ALTER DATABASE [Vendas_DW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Vendas_DW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Vendas_DW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Vendas_DW] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Vendas_DW] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Vendas_DW]
GO
/****** Object:  Table [dbo].[DimLoja]    Script Date: 11/09/2015 15:35:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimLoja](
	[Id_Loja] [int] IDENTITY(1,1) NOT NULL,
	[Id_Filial] [int] NOT NULL,
	[Id_Grouping] [int] NOT NULL,
	[Id_DataOpen] [int] NOT NULL,
	[Id_DataClose] [int] NOT NULL,
	[Id_Cidade] [int] NOT NULL,
	[CodigoLojaAlternate] [nvarchar](10) NOT NULL,
	[CodigoLojaLegado] [nvarchar](3) NOT NULL,
	[NomeLoja] [nvarchar](150) NOT NULL,
	[NomeReduzido] [nvarchar](10) NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DimLoja] ON 

INSERT [dbo].[DimLoja] ([Id_Loja], [Id_Filial], [Id_Grouping], [Id_DataOpen], [Id_DataClose], [Id_Cidade], [CodigoLojaAlternate], [CodigoLojaLegado], [NomeLoja], [NomeReduzido]) VALUES (2, 2, 2, 2, 2, 2, N'02LEGACYP6', N'bbb', N'Loja 02', N'Loja 02')
INSERT [dbo].[DimLoja] ([Id_Loja], [Id_Filial], [Id_Grouping], [Id_DataOpen], [Id_DataClose], [Id_Cidade], [CodigoLojaAlternate], [CodigoLojaLegado], [NomeLoja], [NomeReduzido]) VALUES (3, 3, 3, 3, 3, 3, N'04LEGACYF1', N'ccc', N'Loja 03', N'Loja 03')
INSERT [dbo].[DimLoja] ([Id_Loja], [Id_Filial], [Id_Grouping], [Id_DataOpen], [Id_DataClose], [Id_Cidade], [CodigoLojaAlternate], [CodigoLojaLegado], [NomeLoja], [NomeReduzido]) VALUES (4, 4, 4, 4, 4, 4, N'3021161173', N'ddd', N'Loja 04', N'Loja 04')
INSERT [dbo].[DimLoja] ([Id_Loja], [Id_Filial], [Id_Grouping], [Id_DataOpen], [Id_DataClose], [Id_Cidade], [CodigoLojaAlternate], [CodigoLojaLegado], [NomeLoja], [NomeReduzido]) VALUES (5, 5, 5, 5, 5, 5, N'3022521768', N'eee', N'Loja 05', N'Loja 05')
INSERT [dbo].[DimLoja] ([Id_Loja], [Id_Filial], [Id_Grouping], [Id_DataOpen], [Id_DataClose], [Id_Cidade], [CodigoLojaAlternate], [CodigoLojaLegado], [NomeLoja], [NomeReduzido]) VALUES (6, 6, 6, 6, 6, 6, N'3022520378', N'fff', N'Loja 06', N'Loja 06')
INSERT [dbo].[DimLoja] ([Id_Loja], [Id_Filial], [Id_Grouping], [Id_DataOpen], [Id_DataClose], [Id_Cidade], [CodigoLojaAlternate], [CodigoLojaLegado], [NomeLoja], [NomeReduzido]) VALUES (7, 7, 7, 7, 7, 7, N'04LEGACY0A', N'ggg', N'Loja 07', N'Loja 07')
SET IDENTITY_INSERT [dbo].[DimLoja] OFF
USE [master]
GO
ALTER DATABASE [Vendas_DW] SET  READ_WRITE 
GO
