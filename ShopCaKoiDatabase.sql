USE [master]
GO
/****** Object:  Database [ShopCaKoiDatabase]    Script Date: 21/10/2024 6:07:29 CH ******/
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
ALTER DATABASE [ShopCaKoiDatabase] SET  READ_WRITE 
GO


-- Tạo bảng Employee
CREATE TABLE Employee (
    IDNV NVARCHAR(50) PRIMARY KEY,
    NameVN NVARCHAR(100),
    Role NVARCHAR(50)
);

-- Tạo bảng Customer
CREATE TABLE Customer (
    customerID NVARCHAR(50) PRIMARY KEY,
    Name NVARCHAR(100),
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    CustomerPassword NVARCHAR(50)
);

-- Tạo bảng Koi
CREATE TABLE Koi (
    koiID NVARCHAR(50) PRIMARY KEY,
    species NVARCHAR(50),
    age INT,
    size DECIMAL(5,2),
    price DECIMAL(18,2)
);
-- Tạo bảng KoiFarm
CREATE TABLE KoiFarm (
    farm_id NVARCHAR(50) PRIMARY KEY,
    name NVARCHAR(100),
    location NVARCHAR(225),
    description TEXT,
    contact_info NVARCHAR(100),
    koiID NVARCHAR(50),
    FOREIGN KEY (koiID) REFERENCES Koi(koiID)
);
-- Tạo bảng Trip
CREATE TABLE Trip (
    tripID NVARCHAR(50) PRIMARY KEY,
    departureDate DATE,
    arrivalDate DATE,
    farm_id NVARCHAR(50),
    koiID NVARCHAR(50),
    price FLOAT,
    description TEXT,
    FOREIGN KEY (farm_id) REFERENCES KoiFarm(farm_id),
    FOREIGN KEY (koiID) REFERENCES Koi(koiID)
);

-- Tạo bảng OrderTrip
CREATE TABLE OrderTrip (
    orderID NVARCHAR(50) PRIMARY KEY,
    customerID NVARCHAR(50),
    quotationID NVARCHAR(50),
    paymentStatus NVARCHAR(50),
    orderDate DATE,
    tripID NVARCHAR(50),
    Quantity INT,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID),
    FOREIGN KEY (tripID) REFERENCES Trip(tripID)
);

-- Tạo bảng Quotation
CREATE TABLE Quotation (
    quotationID NVARCHAR(50) PRIMARY KEY,
    orderID NVARCHAR(50),
    amount DECIMAL(18,2),
    approveStatus NVARCHAR(50),
    FOREIGN KEY (orderID) REFERENCES OrderTrip(orderID)
);

-- Tạo bảng Manager
CREATE TABLE Manager (
    IDNV NVARCHAR(50) PRIMARY KEY,
    pendingQuotations NVARCHAR(MAX),
    quotationID NVARCHAR(50),
    FOREIGN KEY (IDNV) REFERENCES Employee(IDNV),
    FOREIGN KEY (quotationID) REFERENCES Quotation(quotationID)
);

-- Tạo bảng SalesStaff
CREATE TABLE SalesStaff (
    IDNV NVARCHAR(50) PRIMARY KEY,
    assignedOrders NVARCHAR(MAX),
    quotationID NVARCHAR(50),
    FOREIGN KEY (IDNV) REFERENCES Employee(IDNV),
    FOREIGN KEY (quotationID) REFERENCES Quotation(quotationID)
);

-- Tạo bảng DeliveringStaff
CREATE TABLE DeliveringStaff (
    IDNV NVARCHAR(50) PRIMARY KEY,
    assignedDeliveries TEXT,
    FOREIGN KEY (IDNV) REFERENCES Employee(IDNV)
);

-- Tạo bảng ConsultingStaff
CREATE TABLE ConsultingStaff (
    IDNV NVARCHAR(50) PRIMARY KEY,
    assignedCustomers TEXT,
    quotationID NVARCHAR(50),
    FOREIGN KEY (IDNV) REFERENCES Employee(IDNV),
    FOREIGN KEY (quotationID) REFERENCES Quotation(quotationID)
);





-- Tạo bảng OrderKoi
CREATE TABLE OrderKoi (
    orderID NVARCHAR(50) PRIMARY KEY,
    customerID NVARCHAR(50),
    quotationID NVARCHAR(50),
    paymentStatus NVARCHAR(50),
    orderDate DATE,
    koiID NVARCHAR(50),
    Quantity INT,
    FOREIGN KEY (customerID) REFERENCES Customer(customerID),
    FOREIGN KEY (quotationID) REFERENCES Quotation(quotationID),
    FOREIGN KEY (koiID) REFERENCES Koi(koiID)
);



-- Tạo bảng Feedback
CREATE TABLE Feedback (
    id NVARCHAR(50) PRIMARY KEY,
    customerID NVARCHAR(50),
    rating INT,
    comment NVARCHAR(1000),
    FOREIGN KEY (customerID) REFERENCES Customer(customerID)
);



-- Tạo bảng ShopCaKoiAccount
CREATE TABLE ShopCaKoiAccount (
    AccID NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(90),
    EmailAddress NVARCHAR(90),
    Description NVARCHAR(140),
    Role INT
);

-- Tạo bảng Booking
CREATE TABLE Booking (
    BookingID NVARCHAR(50) PRIMARY KEY,
    AccID NVARCHAR(50),
    tripID NVARCHAR(50),
    custom_request TEXT,
    status NVARCHAR(20),
    created_at DATETIME,
    approved_at DATETIME,
    FOREIGN KEY (AccID) REFERENCES ShopCaKoiAccount(AccID),
    FOREIGN KEY (tripID) REFERENCES Trip(tripID)
);
CREATE TABLE Feedback (
    id NVARCHAR(50) PRIMARY KEY,          -- Mã phản hồi
    customerID NVARCHAR(50),              -- Khóa ngoại tới bảng Customer
    rating INT,                           -- Đánh giá (ví dụ từ 1 đến 5 sao)
    comment NVARCHAR(1000),               -- Bình luận của khách hàng
    FOREIGN KEY (customerID) REFERENCES Customer(customerID)
);
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
