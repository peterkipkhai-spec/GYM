IF DB_ID('hotel_booking_system') IS NULL
    CREATE DATABASE hotel_booking_system;
GO

USE hotel_booking_system;
GO

CREATE TABLE RoomTypes (
    RoomTypeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    PricePerNight DECIMAL(18,2) NOT NULL,
    Capacity INT NOT NULL,
    Description NVARCHAR(250) NULL
);

CREATE TABLE Rooms (
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(20) NOT NULL UNIQUE,
    RoomTypeId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    Status NVARCHAR(30) NOT NULL DEFAULT 'Available',
    CONSTRAINT FK_Rooms_RoomTypes FOREIGN KEY (RoomTypeId) REFERENCES RoomTypes(RoomTypeId)
);

CREATE TABLE Customers (
    CustomerId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(30) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    IdNumber NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Staff (
    StaffId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Role NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(30) NOT NULL
);

CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    RoomId INT NOT NULL,
    CustomerId INT NOT NULL,
    StaffId INT NULL,
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    Status NVARCHAR(30) NOT NULL DEFAULT 'Reserved',
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Bookings_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId),
    CONSTRAINT FK_Bookings_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    CONSTRAINT FK_Bookings_Staff FOREIGN KEY (StaffId) REFERENCES Staff(StaffId)
);

CREATE TABLE StayRecords (
    StayRecordId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT NOT NULL UNIQUE,
    ActualCheckIn DATETIME2 NULL,
    ActualCheckOut DATETIME2 NULL,
    TotalNights INT NOT NULL DEFAULT 0,
    CONSTRAINT FK_StayRecords_Bookings FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);

CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    PaymentDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    Notes NVARCHAR(250) NULL,
    CONSTRAINT FK_Payments_Bookings FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);
GO

CREATE INDEX IX_Rooms_RoomTypeId ON Rooms(RoomTypeId);
CREATE INDEX IX_Bookings_RoomId ON Bookings(RoomId);
CREATE INDEX IX_Bookings_CustomerId ON Bookings(CustomerId);
CREATE INDEX IX_Payments_BookingId ON Payments(BookingId);
GO

INSERT INTO RoomTypes (Name, PricePerNight, Capacity, Description)
VALUES
('Standard', 80.00, 2, 'Basic room with queen bed'),
('Deluxe', 120.00, 3, 'Larger room with city view'),
('Suite', 200.00, 4, 'Premium suite with living area');

INSERT INTO Rooms (RoomNumber, RoomTypeId, IsActive, Status)
VALUES ('101', 1, 1, 'Available'), ('102', 1, 1, 'Available'), ('201', 2, 1, 'Available'), ('301', 3, 1, 'Available');

INSERT INTO Customers (FullName, Phone, Email, IdNumber)
VALUES
('John Carter', '555-1111', 'john@example.com', 'ID1001'),
('Emily Stone', '555-2222', 'emily@example.com', 'ID1002');

INSERT INTO Staff (FullName, Role, Phone)
VALUES
('Alice Brown', 'Receptionist', '555-3333'),
('Mark Lee', 'Manager', '555-4444');

INSERT INTO Bookings (RoomId, CustomerId, StaffId, CheckInDate, CheckOutDate, Status)
VALUES
(1, 1, 1, '2026-04-01', '2026-04-04', 'Reserved'),
(3, 2, 1, '2026-04-05', '2026-04-08', 'Reserved');

INSERT INTO Payments (BookingId, Amount, PaymentMethod, Notes)
VALUES
(1, 240.00, 'Card', 'Advance payment');
GO

CREATE OR ALTER VIEW vw_BookingReport AS
SELECT b.BookingId, c.FullName AS CustomerName, r.RoomNumber, b.CheckInDate, b.CheckOutDate, b.Status
FROM Bookings b
JOIN Customers c ON b.CustomerId = c.CustomerId
JOIN Rooms r ON b.RoomId = r.RoomId;
GO

CREATE OR ALTER VIEW vw_RoomAvailabilityReport AS
SELECT r.RoomId, r.RoomNumber, rt.Name AS RoomType, r.Status, r.IsActive
FROM Rooms r
JOIN RoomTypes rt ON r.RoomTypeId = rt.RoomTypeId;
GO

CREATE OR ALTER VIEW vw_CustomerStaySummary AS
SELECT c.CustomerId, c.FullName, COUNT(b.BookingId) AS TotalBookings,
       SUM(DATEDIFF(DAY, b.CheckInDate, b.CheckOutDate)) AS TotalNights
FROM Customers c
LEFT JOIN Bookings b ON c.CustomerId = b.CustomerId
GROUP BY c.CustomerId, c.FullName;
GO
