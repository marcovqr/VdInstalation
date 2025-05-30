USE [master]
GO
/****** Object:  Database [Encabezado_Detalle]    Script Date: 2/3/2025 10:02:44 PM ******/
CREATE DATABASE [Encabezado_Detalle]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Encabezado_Detalle', FILENAME = N'C:\SQLData\Data\Encabezado_Detalle.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Encabezado_Detalle_log', FILENAME = N'C:\SQLData\Logs\Encabezado_Detalle_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Encabezado_Detalle] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Encabezado_Detalle].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Encabezado_Detalle] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET ARITHABORT OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Encabezado_Detalle] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Encabezado_Detalle] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Encabezado_Detalle] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Encabezado_Detalle] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Encabezado_Detalle] SET  MULTI_USER 
GO
ALTER DATABASE [Encabezado_Detalle] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Encabezado_Detalle] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Encabezado_Detalle] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Encabezado_Detalle] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Encabezado_Detalle] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Encabezado_Detalle] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Encabezado_Detalle] SET QUERY_STORE = ON
GO
ALTER DATABASE [Encabezado_Detalle] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Encabezado_Detalle]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/3/2025 10:02:44 PM ******/
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
/****** Object:  Table [dbo].[cot_cotizacion]    Script Date: 2/3/2025 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cot_cotizacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[id_persona] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Po] [nvarchar](50) NULL,
	[adress] [nvarchar](150) NULL,
	[customer] [nvarchar](50) NULL,
	[telf] [nvarchar](50) NULL,
	[estado] [nvarchar](max) NULL,
 CONSTRAINT [PK_cot_cotizacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cot_cotizacion_item]    Script Date: 2/3/2025 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cot_cotizacion_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoNombre] [nvarchar](50) NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[id_cot_cotizacion] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Store] [nvarchar](50) NULL,
 CONSTRAINT [PK_cot_cotizacion_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 2/3/2025 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nit] [nvarchar](10) NOT NULL,
	[apellidos] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[nombres] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_cot_cotizacion_id_persona]    Script Date: 2/3/2025 10:02:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_cot_cotizacion_id_persona] ON [dbo].[cot_cotizacion]
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_cot_cotizacion_item_id_cot_cotizacion]    Script Date: 2/3/2025 10:02:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_cot_cotizacion_item_id_cot_cotizacion] ON [dbo].[cot_cotizacion_item]
(
	[id_cot_cotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cot_cotizacion] ADD  DEFAULT ((0)) FOR [id_persona]
GO
ALTER TABLE [dbo].[persona] ADD  DEFAULT (N'') FOR [nombres]
GO
ALTER TABLE [dbo].[cot_cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_cot_cotizacion_persona_id_persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[persona] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cot_cotizacion] CHECK CONSTRAINT [FK_cot_cotizacion_persona_id_persona]
GO
ALTER TABLE [dbo].[cot_cotizacion_item]  WITH CHECK ADD  CONSTRAINT [FK_cot_cotizacion_item_cot_cotizacion_id_cot_cotizacion] FOREIGN KEY([id_cot_cotizacion])
REFERENCES [dbo].[cot_cotizacion] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[cot_cotizacion_item] CHECK CONSTRAINT [FK_cot_cotizacion_item_cot_cotizacion_id_cot_cotizacion]
GO
USE [master]
GO
ALTER DATABASE [Encabezado_Detalle] SET  READ_WRITE 
GO
