USE [master]
GO
/****** Object:  Database [PetShop]    Script Date: 12.04.2024 14:14:50 ******/
CREATE DATABASE [PetShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PetShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PetShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PetShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PetShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PetShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PetShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PetShop] SET  MULTI_USER 
GO
ALTER DATABASE [PetShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PetShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PetShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PetShop] SET QUERY_STORE = OFF
GO
USE [PetShop]
GO
/****** Object:  Table [dbo].[Dog]    Script Date: 12.04.2024 14:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodPet]    Script Date: 12.04.2024 14:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodPet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Cost] [int] NULL,
	[Discription] [nvarchar](50) NULL,
	[DataEdit] [datetime] NULL,
 CONSTRAINT [PK_FoodPet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12.04.2024 14:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_FoodPet]    Script Date: 12.04.2024 14:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_FoodPet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DogId] [int] NULL,
	[OrderId] [int] NULL,
	[FoodPetId] [int] NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Order_FoodPet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dog] ON 

INSERT [dbo].[Dog] ([Id], [Name], [Password]) VALUES (1, N'Lame', N'12345')
SET IDENTITY_INSERT [dbo].[Dog] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodPet] ON 

INSERT [dbo].[FoodPet] ([Id], [Name], [Cost], [Discription], [DataEdit]) VALUES (1, N'Новый Корм с мясом', 150, N'Корм с мясом круглый', CAST(N'2024-04-12T12:17:35.513' AS DateTime))
INSERT [dbo].[FoodPet] ([Id], [Name], [Cost], [Discription], [DataEdit]) VALUES (2, N'Корм с рыбой', 170, N'Корм с рыбой треугольный', NULL)
INSERT [dbo].[FoodPet] ([Id], [Name], [Cost], [Discription], [DataEdit]) VALUES (3, N'Корм с мясом импортный', 250, N'Импортный корм с мясом из италии', NULL)
INSERT [dbo].[FoodPet] ([Id], [Name], [Cost], [Discription], [DataEdit]) VALUES (4, N'ККорм с крабом', 450, N'корм со вкусом краба', CAST(N'2024-04-12T11:22:56.757' AS DateTime))
INSERT [dbo].[FoodPet] ([Id], [Name], [Cost], [Discription], [DataEdit]) VALUES (5, N'Корм с сыром', 200, N'корм со вкусом сыра', NULL)
SET IDENTITY_INSERT [dbo].[FoodPet] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Address], [Price]) VALUES (1, N'dada', NULL)
INSERT [dbo].[Order] ([Id], [Address], [Price]) VALUES (2, N'daw', NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_FoodPet] ON 

INSERT [dbo].[Order_FoodPet] ([Id], [DogId], [OrderId], [FoodPetId], [Count]) VALUES (1, 1, 1, 4, 2)
INSERT [dbo].[Order_FoodPet] ([Id], [DogId], [OrderId], [FoodPetId], [Count]) VALUES (2, 1, 2, 4, 1)
INSERT [dbo].[Order_FoodPet] ([Id], [DogId], [OrderId], [FoodPetId], [Count]) VALUES (3, 1, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Order_FoodPet] OFF
GO
ALTER TABLE [dbo].[Order_FoodPet]  WITH CHECK ADD  CONSTRAINT [FK_Order_FoodPet_Dog] FOREIGN KEY([DogId])
REFERENCES [dbo].[Dog] ([Id])
GO
ALTER TABLE [dbo].[Order_FoodPet] CHECK CONSTRAINT [FK_Order_FoodPet_Dog]
GO
ALTER TABLE [dbo].[Order_FoodPet]  WITH CHECK ADD  CONSTRAINT [FK_Order_FoodPet_FoodPet] FOREIGN KEY([FoodPetId])
REFERENCES [dbo].[FoodPet] ([Id])
GO
ALTER TABLE [dbo].[Order_FoodPet] CHECK CONSTRAINT [FK_Order_FoodPet_FoodPet]
GO
ALTER TABLE [dbo].[Order_FoodPet]  WITH CHECK ADD  CONSTRAINT [FK_Order_FoodPet_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Order_FoodPet] CHECK CONSTRAINT [FK_Order_FoodPet_Order]
GO
USE [master]
GO
ALTER DATABASE [PetShop] SET  READ_WRITE 
GO
