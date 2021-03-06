USE [master]
GO
/****** Object:  Database [Vendas_DW]    Script Date: 21/10/2015 15:06:59 ******/
CREATE DATABASE [Vendas_DW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Vendas_DW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Vendas_DW.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Vendas_DW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Vendas_DW_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Vendas_DW] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [Vendas_DW] SET AUTO_CREATE_STATISTICS ON 
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
USE [Vendas_DW]
GO
/****** Object:  Table [dbo].[DimAeroporto]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimAeroporto](
	[Id_Aeroporto] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoNegocio] [int] NOT NULL,
	[Id_Filial] [int] NOT NULL,
	[SiglaAeroporto] [nvarchar](4) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimCargo]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimCargo](
	[Id_Cargo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCargoAlternate] [nvarchar](2) NOT NULL,
	[NomeCargo] [nvarchar](80) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimColaborador]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimColaborador](
	[Id_Colaborador] [int] IDENTITY(1,1) NOT NULL,
	[Id_Loja] [int] NOT NULL,
	[Id_Cargo] [int] NOT NULL,
	[Id_Turno] [int] NOT NULL,
	[CodigoSecundario] [nchar](4) NOT NULL,
	[NomeCompleto] [nvarchar](40) NOT NULL,
	[DataAdmissao] [date] NULL,
	[DataNascimento] [date] NULL,
	[Email] [nvarchar](50) NULL,
	[Genero] [nchar](1) NULL,
	[Comissao] [decimal](4, 2) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimEmpresa]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimEmpresa](
	[Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Id_Pais] [int] NOT NULL,
	[CodigoEmpresaAlternate] [numeric](5, 3) NOT NULL,
	[NomeEmpresa] [nvarchar](120) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimFilial]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimFilial](
	[Id_Filial] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoNegocio] [int] NOT NULL,
	[CodigoFilialAlternate] [nvarchar](2) NOT NULL,
	[NomeFilial] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimLoja]    Script Date: 21/10/2015 15:06:59 ******/
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
/****** Object:  Table [dbo].[DimProduto]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DimProduto](
	[Id_Produto] [int] IDENTITY(1,1) NOT NULL,
	[Id_ProdutoTipo] [int] NOT NULL,
	[Id_ProdutoSubGrupoDufry] [int] NOT NULL,
	[Id_TipoBusiness] [int] NOT NULL,
	[CodigoProdutoAlternate] [nvarchar](10) NOT NULL,
	[DescricaoProdutoNome] [nvarchar](250) NOT NULL,
	[DescricaoProdutoNomeIngles] [nvarchar](250) NULL,
	[Cor] [nvarchar](15) NULL,
	[NCM] [nvarchar](20) NULL,
	[Nacional] [char](1) NULL,
	[MarcaLocal] [nvarchar](250) NULL,
	[LinhaLocal] [nvarchar](250) NULL,
	[MarcaGlobal] [nvarchar](250) NULL,
	[LinhaGlobal] [nvarchar](250) NULL,
	[Tamanho] [nvarchar](50) NULL,
	[Peso] [numeric](7, 3) NOT NULL,
	[Modelo] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Status] [nvarchar](1) NULL,
	[Consignado] [nvarchar](3) NULL,
	[Hudson] [nvarchar](3) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DimProdutoGrupo]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimProdutoGrupo](
	[Id_ProdutoGrupo] [int] IDENTITY(1,1) NOT NULL,
	[Id_ProdutoSegmento] [int] NOT NULL,
	[CodigoProdutoGrupoAlternate] [nvarchar](10) NOT NULL,
	[NomeProdutoGrupo] [nvarchar](120) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimProdutoSegmento]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimProdutoSegmento](
	[Id_ProdutoSegmento] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProdutoSegmentoAlternate] [nvarchar](4) NOT NULL,
	[NomeProdutoSegmento] [nvarchar](30) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimProdutoSubGrupo]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimProdutoSubGrupo](
	[Id_ProdutoSubGrupo] [int] IDENTITY(1,1) NOT NULL,
	[Id_ProdutoGrupo] [int] NOT NULL,
	[CodigoProdutoGrupoAlternate] [nvarchar](10) NOT NULL,
	[CodigoProdutoSubGrupoAlternate] [nvarchar](3) NOT NULL,
	[NomeProdutoSubGrupo] [nvarchar](30) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimTipoBusiness]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimTipoBusiness](
	[Id_TipoBusiness] [int] IDENTITY(1,1) NOT NULL,
	[CodigoTipoBusinessAlternate] [numeric](5, 1) NOT NULL,
	[CodigoNegocio] [nvarchar](3) NOT NULL,
	[NomeTipoBusiness] [nvarchar](30) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DimTipoNegocio]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimTipoNegocio](
	[Id_TipoNegocio] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoBusiness] [int] NOT NULL,
	[Id_Empresa] [int] NOT NULL,
	[CodigoEmpresaLegado] [nvarchar](2) NOT NULL,
	[CodigoTipoNegocioAlternate] [numeric](5, 4) NOT NULL,
	[NomeTipoNegocio] [nvarchar](120) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FatoVenda]    Script Date: 21/10/2015 15:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FatoVenda](
	[Id_Produto] [int] NOT NULL,
	[Id_DataVenda] [int] NOT NULL,
	[Id_HoraVenda] [int] NOT NULL,
	[Id_Loja] [int] NOT NULL,
	[Id_Colaborador] [int] NOT NULL,
	[Id_Promocao] [int] NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_CiaAerea] [int] NOT NULL,
	[Id_Voo] [int] NOT NULL,
	[Id_Turno] [int] NOT NULL,
	[Id_Desconto] [int] NOT NULL,
	[Id_TipoVenda] [int] NOT NULL,
	[CodigoVenda] [nvarchar](20) NOT NULL,
	[NumeroLinhaVenda] [tinyint] NOT NULL,
	[Quantidade] [bigint] NULL,
	[PrecoUnitarioCustoWACemReal] [money] NULL,
	[PrecoUnitarioCustoRACemReal] [money] NULL,
	[PrecoUnitarioRegularEmReal] [money] NULL,
	[PrecoUnitarioPromoEmReal] [money] NULL,
	[PrecoUnitarioFinalEmReal] [money] NULL,
	[PrecoUnitarioCustoWACemDolar] [money] NULL,
	[PrecoUnitarioCustoRACemDolar] [money] NULL,
	[PrecoUnitarioRegularEmDolar] [money] NULL,
	[PrecoUnitarioPromoEmDolar] [money] NULL,
	[PrecoUnitarioFinalEmDolar] [money] NULL,
	[ImpostoPisEmReal] [money] NULL,
	[ImpostoCofinsEmReal] [money] NULL,
	[ImpostoIcmsEmReal] [money] NULL,
	[ImpostoPisEmDolar] [money] NULL,
	[ImpostoCofinsEmDolar] [money] NULL,
	[ImpostoIcmsEmDolar] [money] NULL,
	[ValorDescontoEtiquetaEmReal] [money] NULL,
	[ValorDescontoEtiquetaEmDolar] [money] NULL,
	[ValorDescontoEstadoEmReal] [money] NULL,
	[ValorDescontoEstadoEmDolar] [money] NULL,
	[ValorDescontoTripulanteEmReal] [money] NULL,
	[ValorDescontoTripulanteEmDolar] [money] NULL,
	[ValorDescontoPreOrderEmReal] [money] NULL,
	[ValorDescontoPreOrderEmDolar] [money] NULL,
	[ValorDescontoRateioEmReal] [money] NULL,
	[ValorDescontoRateioEmDolar] [money] NULL,
	[ValorPagtoMoedaOrigem1] [money] NULL,
	[Codigo_Moeda1] [int] NULL,
	[ValorPagtoMoedaOrigem2] [money] NULL,
	[Codigo_Moeda2] [int] NULL,
	[ValorPagtoMoedaOrigem3] [money] NULL,
	[Codigo_Moeda3] [int] NULL,
	[ValorPagtoMoedaOrigem4] [money] NULL,
	[Codigo_Moeda4] [int] NULL,
	[ValorPagtoMoedaOrigem5] [money] NULL,
	[Codigo_Moeda5] [int] NULL
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
