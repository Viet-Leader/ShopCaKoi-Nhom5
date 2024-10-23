USE [master]
GO
/****** Object:  Database [ShopCaKoiDatabase]    Script Date: 10/24/2024 12:18:27 AM ******/
CREATE DATABASE [ShopCaKoiDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopCaKoi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopCaKoi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopCaKoi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopCaKoi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopCaKoiDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopCaKoiDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopCaKoiDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopCaKoiDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopCaKoiDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopCaKoiDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopCaKoiDatabase]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[bookingID] [nvarchar](50) NOT NULL,
	[AccID] [nvarchar](50) NULL,
	[tripID] [nvarchar](50) NULL,
	[custom_request] [text] NULL,
	[status] [nvarchar](20) NULL,
	[created_at] [datetime] NULL,
	[approved_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[bookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsultingStaff]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultingStaff](
	[IDNV] [nvarchar](50) NOT NULL,
	[assignedCustomers] [text] NULL,
	[quotationID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[CustomerPassword] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveringStaff]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveringStaff](
	[IDNV] [nvarchar](50) NOT NULL,
	[assignedDeliveries] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IDNV] [nvarchar](50) NOT NULL,
	[NameNV] [nvarchar](100) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [nvarchar](50) NOT NULL,
	[customerID] [nvarchar](50) NULL,
	[rating] [int] NULL,
	[comment] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koi]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi](
	[koiID] [nvarchar](50) NOT NULL,
	[species] [nvarchar](50) NULL,
	[age] [int] NULL,
	[size] [decimal](5, 2) NULL,
	[price] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[koiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiFarm]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiFarm](
	[farm_id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
	[location] [nvarchar](255) NULL,
	[description] [text] NULL,
	[contact_info] [nvarchar](100) NULL,
	[koiID] [nvarchar](50) NULL,
 CONSTRAINT [PK_farm] PRIMARY KEY CLUSTERED 
(
	[farm_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[IDNV] [nvarchar](50) NOT NULL,
	[pendingQuotations] [nvarchar](max) NULL,
	[quotationID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderKoi]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderKoi](
	[orderID] [nvarchar](50) NOT NULL,
	[customerID] [nvarchar](50) NULL,
	[quotationID] [nvarchar](50) NULL,
	[paymentStatus] [nvarchar](50) NULL,
	[orderDate] [date] NULL,
	[koiID] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTrip]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTrip](
	[OrderID] [nvarchar](50) NOT NULL,
	[customerID] [nvarchar](50) NULL,
	[quotationID] [nvarchar](50) NULL,
	[paymentStatus] [nvarchar](50) NULL,
	[orderDate] [date] NULL,
	[tripID] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[quotationID] [nvarchar](50) NOT NULL,
	[orderID] [nvarchar](50) NULL,
	[amount] [decimal](18, 2) NULL,
	[approveStatus] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[quotationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesStaff]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesStaff](
	[IDNV] [nvarchar](50) NOT NULL,
	[assignedOrders] [nvarchar](max) NULL,
	[quotationID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopCaKoiAccount]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopCaKoiAccount](
	[AccID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](90) NOT NULL,
	[EmailAddress] [nvarchar](90) NULL,
	[Description] [nvarchar](140) NOT NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 10/24/2024 12:18:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[tripID] [nvarchar](50) NOT NULL,
	[departureDate] [date] NULL,
	[arrivalDate] [date] NULL,
	[farm_id] [nvarchar](50) NULL,
	[koiID] [nvarchar](50) NULL,
	[price] [float] NULL,
	[description] [text] NULL,
 CONSTRAINT [PK_tour] PRIMARY KEY CLUSTERED 
(
	[tripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT ('Pending') FOR [status]
GO
ALTER TABLE [dbo].[Booking] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[OrderKoi] ADD  DEFAULT (getdate()) FOR [orderDate]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([AccID])
REFERENCES [dbo].[ShopCaKoiAccount] ([AccID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([tripID])
REFERENCES [dbo].[Trip] ([tripID])
GO
ALTER TABLE [dbo].[ConsultingStaff]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[ConsultingStaff]  WITH CHECK ADD  CONSTRAINT [FK_ConsultingStaff_Quotation] FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[ConsultingStaff] CHECK CONSTRAINT [FK_ConsultingStaff_Quotation]
GO
ALTER TABLE [dbo].[DeliveringStaff]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[KoiFarm]  WITH CHECK ADD  CONSTRAINT [FK_KoiFarm_Koi] FOREIGN KEY([koiID])
REFERENCES [dbo].[Koi] ([koiID])
GO
ALTER TABLE [dbo].[KoiFarm] CHECK CONSTRAINT [FK_KoiFarm_Koi]
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager_Quotation] FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager_Quotation]
GO
ALTER TABLE [dbo].[OrderKoi]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[OrderKoi]  WITH CHECK ADD  CONSTRAINT [FK_OrderKoi_Quotation] FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[OrderKoi] CHECK CONSTRAINT [FK_OrderKoi_Quotation]
GO
ALTER TABLE [dbo].[OrderTrip]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[OrderTrip]  WITH CHECK ADD FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[OrderTrip]  WITH CHECK ADD FOREIGN KEY([tripID])
REFERENCES [dbo].[Trip] ([tripID])
GO
ALTER TABLE [dbo].[SalesStaff]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[SalesStaff]  WITH CHECK ADD  CONSTRAINT [FK_SalesStaff_Quotation] FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[SalesStaff] CHECK CONSTRAINT [FK_SalesStaff_Quotation]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_KoiFarm] FOREIGN KEY([farm_id])
REFERENCES [dbo].[KoiFarm] ([farm_id])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_KoiFarm]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD CHECK  (([status]='Completed' OR [status]='Rejected' OR [status]='Approved' OR [status]='Pending'))
GO
USE [master]
GO
ALTER DATABASE [ShopCaKoiDatabase] SET  READ_WRITE 
GO
