USE [master]
GO
/****** Object:  Database [ShopCaKoiDatabase]    Script Date: 10/31/2024 11:00:34 PM ******/
CREATE DATABASE [ShopCaKoiDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopCaKoiDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopCaKoiDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopCaKoiDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopCaKoiDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[CartItem]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[CartItemId] [varchar](50) NOT NULL,
	[koiId] [varchar](50) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total]  AS ([price]*[Quantity]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewCartSummary]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewCartSummary] AS
SELECT 
    SUM(Quantity * price) AS TotalAmount,
    SUM(Quantity) AS TotalQuantity
FROM 
    CartItem;
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [nvarchar](50) NOT NULL,
	[AccID] [nvarchar](50) NULL,
	[tripID] [nvarchar](50) NULL,
	[custom_request] [text] NULL,
	[status] [nvarchar](20) NULL,
	[created_at] [datetime] NULL,
	[approved_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsultingStaff]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[CustomerPassword] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveringStaff]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IDNV] [nvarchar](50) NOT NULL,
	[NameVN] [nvarchar](100) NULL,
	[Role] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[Koi]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi](
	[koiID] [nvarchar](50) NOT NULL,
	[species] [nvarchar](50) NULL,
	[size] [decimal](5, 2) NULL,
	[price] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[koiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiFarm]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiFarm](
	[farm_id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
	[location] [nvarchar](225) NULL,
	[description] [text] NULL,
	[contact_info] [nvarchar](100) NULL,
	[koiID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[farm_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[OrderKoi]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[OrderTrip]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTrip](
	[orderID] [nvarchar](50) NOT NULL,
	[customerID] [nvarchar](50) NULL,
	[quotationID] [nvarchar](50) NULL,
	[paymentStatus] [nvarchar](50) NULL,
	[orderDate] [date] NULL,
	[tripID] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[SalesStaff]    Script Date: 10/31/2024 11:00:34 PM ******/
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
/****** Object:  Table [dbo].[ShopCaKoiAccount]    Script Date: 10/31/2024 11:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopCaKoiAccount](
	[AccID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](90) NULL,
	[EmailAddress] [nvarchar](90) NULL,
	[Description] [nvarchar](140) NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 10/31/2024 11:00:34 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[tripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([AccID])
REFERENCES [dbo].[ShopCaKoiAccount] ([AccID])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([tripID])
REFERENCES [dbo].[Trip] ([tripID])
GO
ALTER TABLE [dbo].[ConsultingStaff]  WITH CHECK ADD FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[ConsultingStaff]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[DeliveringStaff]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[KoiFarm]  WITH CHECK ADD FOREIGN KEY([koiID])
REFERENCES [dbo].[Koi] ([koiID])
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[OrderKoi]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[OrderKoi]  WITH CHECK ADD FOREIGN KEY([koiID])
REFERENCES [dbo].[Koi] ([koiID])
GO
ALTER TABLE [dbo].[OrderKoi]  WITH CHECK ADD FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[OrderTrip]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[OrderTrip]  WITH CHECK ADD FOREIGN KEY([tripID])
REFERENCES [dbo].[Trip] ([tripID])
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD FOREIGN KEY([orderID])
REFERENCES [dbo].[OrderTrip] ([orderID])
GO
ALTER TABLE [dbo].[SalesStaff]  WITH CHECK ADD FOREIGN KEY([quotationID])
REFERENCES [dbo].[Quotation] ([quotationID])
GO
ALTER TABLE [dbo].[SalesStaff]  WITH CHECK ADD FOREIGN KEY([IDNV])
REFERENCES [dbo].[Employee] ([IDNV])
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD FOREIGN KEY([farm_id])
REFERENCES [dbo].[KoiFarm] ([farm_id])
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD FOREIGN KEY([koiID])
REFERENCES [dbo].[Koi] ([koiID])
GO
USE [master]
GO
ALTER DATABASE [ShopCaKoiDatabase] SET  READ_WRITE 
GO
INSERT INTO Employee (IDNV, NameVN, Role) VALUES 
	('NV001', 'Mai Huy Hoang', 'Manager'),
    ('NV002', 'Nguyen Khanh Duong', 'SalesStaff'),
    ('NV003', 'Tran Quoc Viet', 'ConsultingStaff'),
    ('NV004', 'Nguyen Sang', 'DeliveringStaff');
	-- Thêm dữ liệu vào bảng Customer
INSERT INTO Customer (customerID, Name, Phone, Email, Address, CustomerPassword) VALUES 
    ('KH002', 'Bao Tram', '0987654321', 'baotram@gmail.com', 'Binh Duong', 'baotram123'),
    ('KH003', 'Thu Hoai', '0123445566', 'thuhoai@gmail.com', 'Phu Yen', 'thuhoai123');

-- Thêm dữ liệu vào bảng Koi
INSERT INTO Koi (koiID, species, size, price) VALUES 
    ('K001', 'Kohaku', 30.0, 1200.00),
    ('K002', 'Showa', 27.0, 1500.00);
-- Thêm dữ liệu vào bảng KoiFarm
INSERT INTO KoiFarm (farm_id, name, location, description, contact_info, koiID) VALUES 
    ('F001', 'Ho Ca Koi Yamakoshi', 'Yamakoshi', 'Specializes in Sanke Koi', 'yamakoshi@gmail.com', 'K001')
-- Thêm dữ liệu vào bảng Trip
INSERT INTO Trip (tripID, departureDate, arrivalDate, farm_id, koiID, price, description) VALUES 
    ('T001', '2024-10-05', '2024-10-06', 'F001', 'K001', 600.00, 'Visit Kohaku Farm'),
    ('T002', '2024-10-10', '2024-10-12', 'F001', 'K001', 800.00, 'Showa Koi Farm Tour');
-- Thêm dữ liệu vào bảng OrderTrip
INSERT INTO OrderTrip (orderID, customerID, quotationID, paymentStatus, orderDate, tripID, Quantity) VALUES 
    ('O001', 'KH002', 'Q001', 'Paid', '2024-09-15', 'T001', 3),
    ('O002', 'KH003', 'Q002', 'Pending', '2024-09-20', 'T002', 2);
-- Thêm dữ liệu vào bảng Quotation
INSERT INTO Quotation (quotationID, orderID, amount, approveStatus) VALUES 
    ('Q002', 'O001', 2000.00, 'Approved'),
    ('Q003', 'O002', 2500.00, 'Pending');
	-- Thêm dữ liệu vào bảng Manager
INSERT INTO Manager (IDNV, pendingQuotations, quotationID) VALUES 
    ('NV001', 'Quotation2, Quotation3', 'Q002');

-- Thêm dữ liệu vào bảng SalesStaff
INSERT INTO SalesStaff (IDNV, assignedOrders, quotationID) VALUES 
    ('NV002', 'Order1, Order2', 'Q003');

-- Thêm dữ liệu vào bảng ConsultingStaff
INSERT INTO ConsultingStaff (IDNV, assignedCustomers, quotationID) VALUES 
    ('NV003', 'Customer1, Customer2', 'Q002');

-- Thêm dữ liệu vào bảng DeliveringStaff
INSERT INTO DeliveringStaff (IDNV, assignedDeliveries) VALUES 
    ('NV004', 'Delivery1, Delivery2');
	-- Thêm dữ liệu vào bảng OrderKoi
INSERT INTO OrderKoi (orderID, customerID, quotationID, paymentStatus, orderDate, koiID, Quantity) VALUES 
    ('OK001', 'KH002', 'Q003', 'Paid', '2024-09-10', 'K001', 1),
    ('OK002', 'KH003', 'Q002', 'Pending', '2024-09-12', 'K002', 2);
	-- Thêm dữ liệu vào bảng Feedback
INSERT INTO Feedback (id, customerID, rating, comment) VALUES 
    ('FB001', 'KH002', 4, 'Good quality Koi fish.'),
    ('FB002', 'KH003', 3, 'Satisfactory service.');
	-- Thêm dữ liệu vào bảng ShopCaKoiAccount
INSERT INTO ShopCaKoiAccount (AccID, Password, EmailAddress, Description, Role) VALUES 
    ('ACC001', 'man123', 'manager@gmail.com', 'Manager Account', 1),
    ('ACC002', 'sale123', 'sale@gmail.com', 'Sales Staff Account', 2)
	-- Thêm dữ liệu vào bảng Booking
INSERT INTO Booking (BookingID, AccID, tripID, custom_request, status, created_at, approved_at) VALUES 
    ('BK001', 'ACC001', 'T001', 'No special request', 'Approved', '2024-09-01', '2024-09-02'),
    ('BK002', 'ACC002', 'T002', 'Please include extra information', 'Pending', '2024-09-05', NULL)
	-- Thêm dữ liệu vào bảng CartItem
INSERT INTO CartItem (CartItemId, koiId, price, Quantity)
VALUES ('CI001', 'K001', 200000.00, 3),
       ('CI002', 'K002', 150000.00, 2);
	-- lệnh để tự cập nhật số lượng khi trùng tên
CREATE TRIGGER trg_UpdateQuantityOnDuplicateKoiId
ON CartItem
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @CartItemId VARCHAR(50), @koiId VARCHAR(50), @price DECIMAL(18, 2), @Quantity INT;

    -- Lấy thông tin sản phẩm từ bảng Inserted (bảng ảo chứa bản ghi mới được thêm vào)
    SELECT @CartItemId = CartItemId, @koiId = koiId, @price = price, @Quantity = Quantity FROM Inserted;

    -- Kiểm tra nếu sản phẩm với koiId đã tồn tại
    IF EXISTS (SELECT 1 FROM CartItem WHERE koiId = @koiId)
    BEGIN
        -- Nếu tồn tại, cập nhật Quantity
        UPDATE CartItem
        SET Quantity = Quantity + @Quantity
        WHERE koiId = @koiId;
    END
    ELSE
    BEGIN
        -- Nếu không tồn tại, thêm sản phẩm mới vào bảng
        INSERT INTO CartItem (CartItemId, koiId, price, Quantity)
        SELECT CartItemId, koiId, price, Quantity FROM Inserted;
    END
END;
	--tạo ViewCartSummary
CREATE VIEW ViewCartSummary AS
SELECT 
    SUM(Quantity * price) AS TotalAmount,
    SUM(Quantity) AS TotalQuantity
FROM 
    CartItem;
	--xem bảng ViewCartSummary
	SELECT * FROM ViewCartSummary;