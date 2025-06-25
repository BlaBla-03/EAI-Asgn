# PrimeValue Database Setup

This folder contains the database setup for the PrimeValue e-commerce system.

## Prerequisites

1. **SQL Server LocalDB** - This is a lightweight version of SQL Server that runs locally
   - Download from: https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb
   - Or install via Visual Studio Installer (included with Visual Studio)

## Database Structure

The database includes the following tables:

### Products
- ProductId (Primary Key)
- Name
- Price
- Description
- StockQuantity
- CreatedDate
- IsActive

### Orders
- OrderId (Primary Key)
- CustomerId
- CustomerName
- CustomerEmail
- TotalPrice
- Status (PENDING, PAID, PICKING, SHIPPED, DELIVERED)
- CreationDate
- LastModifiedDate

### OrderItems
- OrderItemId (Primary Key)
- OrderId (Foreign Key to Orders)
- ProductId (Foreign Key to Products)
- Quantity
- UnitPrice
- TotalPrice

### Payments
- PaymentId (Primary Key)
- OrderId (Foreign Key to Orders)
- Amount
- Status (INITIATED, SUCCESS, FAILED)
- PaymentMethod
- TransactionId
- PaymentDate

### Shipments
- ShipmentId (Primary Key)
- OrderId (Foreign Key to Orders)
- TrackingNumber
- ShippingAddress
- Status (CREATED, IN_TRANSIT, DELIVERED)
- CreatedDate
- ShippedDate
- DeliveredDate

## Setup Instructions

### Option 1: Using Batch Script (Windows)
1. Open Command Prompt as Administrator
2. Navigate to the Database folder
3. Run: `SetupDatabase.bat`

### Option 2: Using PowerShell Script (Windows)
1. Open PowerShell as Administrator
2. Navigate to the Database folder
3. Run: `.\SetupDatabase.ps1`

### Option 3: Manual Setup
1. Open SQL Server Management Studio or Azure Data Studio
2. Connect to `(LocalDB)\MSSQLLocalDB`
3. Open and execute the `Database\CreateDatabase.sql` script

## Sample Data

The database is pre-populated with sample products:
- Running Shoes ($79.99)
- Yoga Mat ($25.50)
- Dumbbell Set 5kg ($45.00)
- Resistance Bands ($15.99)
- Football ($22.00)

## Connection String

The web service uses the following connection string:
```
Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PrimeValue;Integrated Security=True;MultipleActiveResultSets=True
```

## Troubleshooting

### SQL Server LocalDB not found
- Install SQL Server LocalDB from Microsoft
- Ensure it's added to your PATH environment variable

### Permission denied
- Run the setup scripts as Administrator
- Ensure your user account has permission to create databases

### Database already exists
- The script will automatically drop and recreate the database
- All existing data will be lost

## Web Service Integration

The web service has been updated to use the database instead of in-memory storage. All operations now persist data to the SQL Server database.

### Key Changes:
- Added `DatabaseContext` class for data access
- Updated all web methods to use database operations
- Added proper error handling and transactions
- Implemented proper data models with decimal precision for prices

## Testing the Database

After setup, you can test the database connection by:
1. Running the web service
2. Calling the `GetProducts()` method
3. Creating a test order
4. Verifying data persistence across service restarts 