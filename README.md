# PrimeValue E-Commerce System - EAI Assignment

## Project Overview

This is a comprehensive e-commerce system built as part of the CIT6324 Enterprise Application Integration (EAI) assignment. The system demonstrates enterprise application integration concepts through a multi-tier architecture consisting of a Windows Forms client application, a web service layer, and a SQL Server database.

## System Architecture

The PrimeValue e-commerce system follows a three-tier architecture:

1. **Presentation Layer**: Windows Forms application (`PrimeValueApp`)
2. **Service Layer**: ASP.NET Web Service (`WebService`)
3. **Data Layer**: SQL Server Database (`Database`)

## Components

### 1. PrimeValueApp (Windows Forms Client)
A desktop application that provides role-based interfaces for different stakeholders:

- **Customer Interface**: Browse products, create orders, track order status
- **Warehouse Staff Interface**: Pick and pack orders, manage inventory
- **Courier Interface**: Dispatch orders, update shipping status
- **Payment Gateway Interface**: Process payments, manage transactions

### 2. WebService (ASP.NET Web Service)
RESTful web service providing the following operations:

- `GetProducts()` - Retrieve available products
- `CreateOrder()` - Create new orders
- `GetOrderStatus()` - Check order status
- `ProcessPayment()` - Handle payment processing
- `PickPackOrder()` - Warehouse operations
- `DispatchOrder()` - Courier operations
- `ConfirmDelivery()` - Delivery confirmation

### 3. Database (SQL Server)
Relational database with the following tables:

- **Products**: Product catalog with pricing and inventory
- **Orders**: Order management with status tracking
- **OrderItems**: Order line items
- **Payments**: Payment transaction records
- **Shipments**: Shipping and delivery tracking

## Prerequisites

- **Visual Studio 2019/2022** (Community Edition or higher)
- **SQL Server 2019/2022** (Express Edition or higher)
- **SQL Server Management Studio (SSMS)** (optional, for database management)
- **.NET Framework 4.7.2** or higher

## Installation and Setup

### 1. Database Setup

1. Open SQL Server Management Studio or use the command line
2. Run the database creation script:
   ```
   Database/Database/Scripts/CreateDatabase.sql
   ```
3. Alternatively, use the provided setup scripts:
   - `Database/SetupDatabase.bat` (Windows batch file)
   - `Database/SetupDatabase.ps1` (PowerShell script)

### 2. Web Service Setup

1. Open the WebService solution in Visual Studio:
   ```
   WebService/WebService.sln
   ```
2. Update the connection string in `Web.config` to point to your SQL Server instance
3. Build and run the web service project
4. The web service will be available at: `http://localhost:port/PrimeValueService.asmx`

### 3. Client Application Setup

1. Open the PrimeValueApp solution in Visual Studio:
   ```
   PrimeValueApp/PrimeValueApp.sln
   ```
2. Update the web service URL in the client application to match your web service endpoint
3. Build and run the application

## Usage Guide

### For Customers
1. Launch the PrimeValueApp
2. Click "Customer" button
3. Browse available products
4. Add items to cart and create orders
5. Track order status through the order lifecycle

### For Warehouse Staff
1. Launch the PrimeValueApp
2. Click "Warehouse Staff" button
3. View pending orders
4. Pick and pack orders
5. Update order status to "PACKED"

### For Couriers
1. Launch the PrimeValueApp
2. Click "Courier" button
3. View orders ready for dispatch
4. Dispatch orders with shipping information
5. Update delivery status

### For Payment Processing
1. Launch the PrimeValueApp
2. Click "Payment Gateway" button
3. Process payments for pending orders
4. View payment transaction history

## Order Lifecycle

The system supports a complete order lifecycle:

1. **PENDING** - Order created, awaiting payment
2. **PAID** - Payment processed successfully
3. **PICKING** - Warehouse staff picking items
4. **PACKED** - Order packed and ready for shipping
5. **SHIPPED** - Order dispatched with tracking number
6. **DELIVERED** - Order delivered and confirmed

## API Documentation

### Web Service Endpoints

| Method | Description | Parameters |
|--------|-------------|------------|
| `GetProducts()` | Returns all available products | None |
| `CreateOrder()` | Creates a new order | List of OrderItemRequest |
| `GetOrderStatus()` | Returns order status | orderId (string) |
| `ProcessPayment()` | Processes payment | orderId (string), amount (decimal) |
| `PickPackOrder()` | Picks and packs order | orderId (string) |
| `DispatchOrder()` | Dispatches order | orderId (string), address (string) |
| `ConfirmDelivery()` | Confirms delivery | orderId (string) |

### Sample API Usage

```csharp
// Create a web service reference
var service = new PrimeValueService();

// Get products
var products = service.GetProducts();

// Create an order
var orderItems = new List<OrderItemRequest>
{
    new OrderItemRequest { ProductId = 1, Quantity = 2 }
};
var orderResult = service.CreateOrder(orderItems);
```

## Database Schema

### Products Table
- `ProductId` (INT, Primary Key)
- `Name` (NVARCHAR(100))
- `Price` (DECIMAL(10,2))
- `Description` (NVARCHAR(500))
- `StockQuantity` (INT)
- `CreatedDate` (DATETIME)
- `IsActive` (BIT)

### Orders Table
- `OrderId` (NVARCHAR(50), Primary Key)
- `CustomerId` (NVARCHAR(50))
- `CustomerName` (NVARCHAR(100))
- `CustomerEmail` (NVARCHAR(100))
- `TotalPrice` (DECIMAL(10,2))
- `Status` (NVARCHAR(20))
- `CreationDate` (DATETIME)
- `LastModifiedDate` (DATETIME)

### Additional Tables
- **OrderItems**: Links orders to products with quantities and prices
- **Payments**: Stores payment transaction details
- **Shipments**: Tracks shipping and delivery information

## Troubleshooting

### Common Issues

1. **Database Connection Error**
   - Verify SQL Server is running
   - Check connection string in Web.config
   - Ensure database exists and is accessible

2. **Web Service Not Found**
   - Verify web service is running
   - Check the service URL in client application
   - Ensure firewall allows the connection

3. **Build Errors**
   - Restore NuGet packages
   - Clean and rebuild solution
   - Verify .NET Framework version compatibility

## Project Structure

```
EAI Asgn/
├── Database/                 # Database project and scripts
│   ├── Database/            # SQL Server Database project
│   ├── Scripts/             # SQL creation scripts
│   └── SetupDatabase.*      # Setup automation scripts
├── WebService/              # ASP.NET Web Service
│   ├── WebService/          # Web service implementation
│   ├── Data/               # Data access layer
│   └── Models/             # Data models
├── PrimeValueApp/          # Windows Forms Client
│   ├── PrimeValueApp/      # Main application
│   ├── Forms/              # UI forms for different roles
│   └── Connected Services/ # Web service references
└── README.md               # This file
```

## Technologies Used

- **Backend**: ASP.NET Web Services, C#
- **Frontend**: Windows Forms, C#
- **Database**: SQL Server, T-SQL
- **Data Access**: Entity Framework 6.4.4
- **Development**: Visual Studio 2019/2022

## Contributing

This is an academic assignment project. For educational purposes, feel free to:

1. Study the code structure and architecture
2. Experiment with different integration patterns
3. Extend functionality for learning purposes
4. Report issues or suggest improvements

## License

This project is created for educational purposes as part of the CIT6324 Enterprise Application Integration course.

## Contact

For questions about this project, please refer to the course instructor or teaching assistant.

---

**Note**: This system demonstrates enterprise application integration concepts including service-oriented architecture, multi-tier applications, and database integration. The modular design allows for easy extension and maintenance of the e-commerce functionality.
