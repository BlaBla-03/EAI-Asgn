-- Create PrimeValue Database
USE master;
GO

-- Drop database if it exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PrimeValue')
BEGIN
    ALTER DATABASE PrimeValue SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PrimeValue;
END
GO

-- Create the database
CREATE DATABASE PrimeValue;
GO

USE PrimeValue;
GO

-- Create Products table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Description NVARCHAR(500),
    StockQuantity INT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

-- Create Orders table
CREATE TABLE Orders (
    OrderId NVARCHAR(50) PRIMARY KEY,
    CustomerId NVARCHAR(50),
    CustomerName NVARCHAR(100),
    CustomerEmail NVARCHAR(100),
    TotalPrice DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'PENDING', -- PENDING, PAID, PICKING, SHIPPED, DELIVERED
    CreationDate DATETIME DEFAULT GETDATE(),
    LastModifiedDate DATETIME DEFAULT GETDATE()
);

-- Create OrderItems table
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId NVARCHAR(50) FOREIGN KEY REFERENCES Orders(OrderId),
    ProductId INT FOREIGN KEY REFERENCES Products(ProductId),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL
);

-- Create Payments table
CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId NVARCHAR(50) FOREIGN KEY REFERENCES Orders(OrderId),
    Amount DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'INITIATED', -- INITIATED, SUCCESS, FAILED
    PaymentMethod NVARCHAR(50),
    TransactionId NVARCHAR(100),
    PaymentDate DATETIME DEFAULT GETDATE()
);

-- Create Shipments table
CREATE TABLE Shipments (
    ShipmentId NVARCHAR(50) PRIMARY KEY,
    OrderId NVARCHAR(50) FOREIGN KEY REFERENCES Orders(OrderId),
    TrackingNumber NVARCHAR(100),
    ShippingAddress NVARCHAR(500) NOT NULL,
    Status NVARCHAR(20) DEFAULT 'CREATED', -- CREATED, IN_TRANSIT, DELIVERED
    CreatedDate DATETIME DEFAULT GETDATE(),
    ShippedDate DATETIME,
    DeliveredDate DATETIME
);

-- Insert sample products
INSERT INTO Products (Name, Price, Description, StockQuantity) VALUES
('Running Shoes', 79.99, 'Comfortable running shoes for all terrains', 50),
('Yoga Mat', 25.50, 'Non-slip yoga mat for home workouts', 100),
('Dumbbell Set (5kg)', 45.00, 'Pair of 5kg dumbbells for strength training', 30),
('Resistance Bands', 15.99, 'Set of 3 resistance bands for home workouts', 75),
('Football', 22.00, 'Professional size football for outdoor sports', 40),
('Basketball', 28.00, 'Official size basketball for indoor/outdoor use', 35),
('Tennis Racket', 60.00, 'Lightweight tennis racket for all skill levels', 20),
('Skipping Rope', 8.50, 'Adjustable skipping rope for cardio workouts', 60),
('Water Bottle', 12.00, 'Insulated stainless steel water bottle', 80),
('Gym Bag', 35.00, 'Spacious gym bag with multiple compartments', 25);

-- Create indexes for better performance
CREATE INDEX IX_Orders_Status ON Orders(Status);
CREATE INDEX IX_Orders_CreationDate ON Orders(CreationDate);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
CREATE INDEX IX_Payments_OrderId ON Payments(OrderId);
CREATE INDEX IX_Shipments_OrderId ON Shipments(OrderId);
CREATE INDEX IX_Shipments_TrackingNumber ON Shipments(TrackingNumber);

GO

PRINT 'PrimeValue database created successfully!'; 