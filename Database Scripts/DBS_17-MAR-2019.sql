USE [master]
GO
/****** Object:  Database [MHGoldenJute]    Script Date: 03/17/2019 3:10:57 PM ******/
CREATE DATABASE [MHGoldenJute]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MHGoldenJute', FILENAME = N'D:\DataBase\MHGoldenJute\MHGoldenJute.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MHGoldenJute_log', FILENAME = N'D:\DataBase\MHGoldenJute\MHGoldenJute_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MHGoldenJute] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MHGoldenJute].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MHGoldenJute] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MHGoldenJute] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MHGoldenJute] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MHGoldenJute] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MHGoldenJute] SET ARITHABORT OFF 
GO
ALTER DATABASE [MHGoldenJute] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MHGoldenJute] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MHGoldenJute] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MHGoldenJute] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MHGoldenJute] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MHGoldenJute] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MHGoldenJute] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MHGoldenJute] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MHGoldenJute] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MHGoldenJute] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MHGoldenJute] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MHGoldenJute] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MHGoldenJute] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MHGoldenJute] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MHGoldenJute] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MHGoldenJute] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MHGoldenJute] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MHGoldenJute] SET RECOVERY FULL 
GO
ALTER DATABASE [MHGoldenJute] SET  MULTI_USER 
GO
ALTER DATABASE [MHGoldenJute] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MHGoldenJute] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MHGoldenJute] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MHGoldenJute] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MHGoldenJute] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MHGoldenJute', N'ON'
GO
USE [MHGoldenJute]
GO
/****** Object:  UserDefinedFunction [dbo].[CheckUser]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE function [dbo].[CheckUser](@username nvarchar(250), @password nvarchar(MAX))
returns int 

begin
declare @result int

if((select count(UserId) from tblUser where UserName=@username and Password=@password)>0)
begin
 select @result=UserId from tblUser where UserName=@username and Password=@password;
end
else if ((select count(UserId) from tblUser where UserName=@username and Password!=@password)>0)
begin
set @result=-1;
end
else
begin
set @result=-2
end
return @result;
end

 
GO
/****** Object:  Table [dbo].[Item]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemGroupId] [bigint] NULL,
	[ItemCode] [nvarchar](500) NULL,
	[ItemName] [nvarchar](500) NULL,
	[Department] [nvarchar](500) NULL,
	[Unit] [nvarchar](500) NULL,
	[SalesPrice] [decimal](18, 2) NULL,
	[ReOrderLevel] [int] NULL,
	[ReOrderQuantity] [decimal](18, 2) NULL,
	[ItemType] [nvarchar](500) NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemGroup](
	[ItemGroupId] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemGroupName] [nvarchar](500) NULL,
 CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED 
(
	[ItemGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Party]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Party](
	[PartyId] [bigint] IDENTITY(1,1) NOT NULL,
	[PartyName] [nvarchar](500) NULL,
	[ContactPerson] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NULL,
	[PhoneNo] [nvarchar](500) NULL,
	[MobileNo] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
	[ImageUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED 
(
	[PartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[PurchaseId] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseInvoiceNo] [nvarchar](500) NULL,
	[PurhcaseDateTime] [datetime] NULL,
	[SuppilerId] [bigint] NULL,
	[PurchaseByUserId] [bigint] NULL,
	[Remarks] [nvarchar](max) NULL,
	[ChalanNo] [nvarchar](500) NULL,
	[MrNo] [nvarchar](500) NULL,
	[IsApproved] [int] NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovedDateTime] [datetime] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseDetails]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetails](
	[PurchaseDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [bigint] NULL,
	[PurhcaseInvoiceNo] [nvarchar](500) NULL,
	[ItemGroupId] [bigint] NULL,
	[ItemId] [bigint] NULL,
	[ItemName] [nvarchar](500) NULL,
	[GodownId] [bigint] NULL,
	[ProductName] [nvarchar](500) NULL,
	[Quantity] [decimal](18, 2) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[IsApproved] [int] NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovedDateTime] [datetime] NULL,
	[Department] [nvarchar](500) NULL,
	[Location] [nvarchar](500) NULL,
 CONSTRAINT [PK_PurchaseDetails] PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [bigint] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 03/17/2019 3:10:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](500) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [MHGoldenJute] SET  READ_WRITE 
GO
