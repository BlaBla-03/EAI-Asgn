using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace WebService.Data
{
    public class DatabaseContext
    {
        private readonly string connectionString;

        public DatabaseContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PrimeValueConnection"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT ProductId, Name, Price, Description, StockQuantity FROM Products WHERE IsActive = 1", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                StockQuantity = reader.GetInt32(reader.GetOrdinal("StockQuantity"))
                            });
                        }
                    }
                }
            }
            return products;
        }

        public string CreateOrder(Order order)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert order
                        using (var command = new SqlCommand(
                            "INSERT INTO Orders (OrderId, CustomerId, CustomerName, CustomerEmail, TotalPrice, Status, CreationDate, LastModifiedDate) " +
                            "VALUES (@OrderId, @CustomerId, @CustomerName, @CustomerEmail, @TotalPrice, @Status, @CreationDate, @LastModifiedDate)", 
                            connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrderId", order.OrderId);
                            command.Parameters.AddWithValue("@CustomerId", (object)order.CustomerId ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CustomerName", (object)order.CustomerName ?? DBNull.Value);
                            command.Parameters.AddWithValue("@CustomerEmail", (object)order.CustomerEmail ?? DBNull.Value);
                            command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                            command.Parameters.AddWithValue("@Status", order.Status);
                            command.Parameters.AddWithValue("@CreationDate", order.CreationDate);
                            command.Parameters.AddWithValue("@LastModifiedDate", order.LastModifiedDate);
                            command.ExecuteNonQuery();
                        }

                        // Insert order items
                        foreach (var item in order.Items)
                        {
                            using (var command = new SqlCommand(
                                "INSERT INTO OrderItems (OrderId, ProductId, Quantity, UnitPrice, TotalPrice) " +
                                "VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @TotalPrice)", 
                                connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                                command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                                command.Parameters.AddWithValue("@TotalPrice", item.TotalPrice);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return order.OrderId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Order GetOrder(string orderId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                
                // Get order details
                Order order = null;
                using (var command = new SqlCommand(
                    "SELECT OrderId, CustomerId, CustomerName, CustomerEmail, TotalPrice, Status, CreationDate, LastModifiedDate " +
                    "FROM Orders WHERE OrderId = @OrderId", connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                                CustomerId = reader.IsDBNull(reader.GetOrdinal("CustomerId")) ? null : reader.GetString(reader.GetOrdinal("CustomerId")),
                                CustomerName = reader.IsDBNull(reader.GetOrdinal("CustomerName")) ? null : reader.GetString(reader.GetOrdinal("CustomerName")),
                                CustomerEmail = reader.IsDBNull(reader.GetOrdinal("CustomerEmail")) ? null : reader.GetString(reader.GetOrdinal("CustomerEmail")),
                                TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                                LastModifiedDate = reader.GetDateTime(reader.GetOrdinal("LastModifiedDate")),
                                Items = new List<OrderItem>()
                            };
                        }
                    }
                }

                if (order != null)
                {
                    // Get order items
                    using (var command = new SqlCommand(
                        "SELECT oi.OrderItemId, oi.ProductId, oi.Quantity, oi.UnitPrice, oi.TotalPrice, p.Name " +
                        "FROM OrderItems oi " +
                        "INNER JOIN Products p ON oi.ProductId = p.ProductId " +
                        "WHERE oi.OrderId = @OrderId", connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                order.Items.Add(new OrderItem
                                {
                                    OrderItemId = reader.GetInt32(reader.GetOrdinal("OrderItemId")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                                    TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                    ProductName = reader.GetString(reader.GetOrdinal("Name"))
                                });
                            }
                        }
                    }

                    // Get shipment info
                    using (var command = new SqlCommand(
                        "SELECT ShipmentId, TrackingNumber, ShippingAddress, Status, CreatedDate, ShippedDate, DeliveredDate " +
                        "FROM Shipments WHERE OrderId = @OrderId", connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                order.ShipmentInfo = new Shipment
                                {
                                    ShipmentId = reader.GetString(reader.GetOrdinal("ShipmentId")),
                                    TrackingNumber = reader.IsDBNull(reader.GetOrdinal("TrackingNumber")) ? null : reader.GetString(reader.GetOrdinal("TrackingNumber")),
                                    Address = reader.GetString(reader.GetOrdinal("ShippingAddress")),
                                    Status = reader.GetString(reader.GetOrdinal("Status")),
                                    CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                    ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ShippedDate")),
                                    DeliveredDate = reader.IsDBNull(reader.GetOrdinal("DeliveredDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DeliveredDate"))
                                };
                            }
                        }
                    }
                }

                return order;
            }
        }

        public List<OrderSummary> GetAllOrders()
        {
            var orders = new List<OrderSummary>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT OrderId, CustomerName, TotalPrice, Status, CreationDate, LastModifiedDate " +
                    "FROM Orders ORDER BY CreationDate DESC", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new OrderSummary
                            {
                                OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                                CustomerName = reader.IsDBNull(reader.GetOrdinal("CustomerName")) ? null : reader.GetString(reader.GetOrdinal("CustomerName")),
                                TotalPrice = reader.GetDecimal(reader.GetOrdinal("TotalPrice")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                                LastModifiedDate = reader.GetDateTime(reader.GetOrdinal("LastModifiedDate"))
                            });
                        }
                    }
                }
            }
            return orders;
        }

        public bool UpdateOrderStatus(string orderId, string status)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "UPDATE Orders SET Status = @Status, LastModifiedDate = @LastModifiedDate WHERE OrderId = @OrderId", 
                    connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@LastModifiedDate", DateTime.UtcNow);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public string CreatePayment(Payment payment)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Payments (OrderId, Amount, Status, PaymentMethod, TransactionId, PaymentDate) " +
                    "VALUES (@OrderId, @Amount, @Status, @PaymentMethod, @TransactionId, @PaymentDate)", 
                    connection))
                {
                    command.Parameters.AddWithValue("@OrderId", payment.OrderId);
                    command.Parameters.AddWithValue("@Amount", payment.Amount);
                    command.Parameters.AddWithValue("@Status", payment.Status);
                    command.Parameters.AddWithValue("@PaymentMethod", (object)payment.PaymentMethod ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TransactionId", (object)payment.TransactionId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                    command.ExecuteNonQuery();
                }
            }
            return payment.OrderId;
        }

        public Payment GetPayment(string orderId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT PaymentId, OrderId, Amount, Status, PaymentMethod, TransactionId, PaymentDate " +
                    "FROM Payments WHERE OrderId = @OrderId", connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Payment
                            {
                                PaymentId = reader.GetInt32(reader.GetOrdinal("PaymentId")),
                                OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                PaymentMethod = reader.IsDBNull(reader.GetOrdinal("PaymentMethod")) ? null : reader.GetString(reader.GetOrdinal("PaymentMethod")),
                                TransactionId = reader.IsDBNull(reader.GetOrdinal("TransactionId")) ? null : reader.GetString(reader.GetOrdinal("TransactionId")),
                                PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate"))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public string CreateShipment(Shipment shipment)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "INSERT INTO Shipments (ShipmentId, OrderId, TrackingNumber, ShippingAddress, Status, CreatedDate) " +
                    "VALUES (@ShipmentId, @OrderId, @TrackingNumber, @ShippingAddress, @Status, @CreatedDate)", 
                    connection))
                {
                    command.Parameters.AddWithValue("@ShipmentId", shipment.ShipmentId);
                    command.Parameters.AddWithValue("@OrderId", shipment.OrderId);
                    command.Parameters.AddWithValue("@TrackingNumber", (object)shipment.TrackingNumber ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ShippingAddress", shipment.Address);
                    command.Parameters.AddWithValue("@Status", shipment.Status);
                    command.Parameters.AddWithValue("@CreatedDate", shipment.CreatedDate);
                    command.ExecuteNonQuery();
                }
            }
            return shipment.ShipmentId;
        }

        public bool UpdateShipmentStatus(string shipmentId, string status, DateTime? shippedDate = null, DateTime? deliveredDate = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string sql = "UPDATE Shipments SET Status = @Status";
                if (shippedDate.HasValue) sql += ", ShippedDate = @ShippedDate";
                if (deliveredDate.HasValue) sql += ", DeliveredDate = @DeliveredDate";
                sql += " WHERE ShipmentId = @ShipmentId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ShipmentId", shipmentId);
                    command.Parameters.AddWithValue("@Status", status);
                    if (shippedDate.HasValue)
                        command.Parameters.AddWithValue("@ShippedDate", shippedDate.Value);
                    if (deliveredDate.HasValue)
                        command.Parameters.AddWithValue("@DeliveredDate", deliveredDate.Value);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Shipment GetShipment(string orderId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT ShipmentId, OrderId, TrackingNumber, ShippingAddress, Status, CreatedDate, ShippedDate, DeliveredDate " +
                    "FROM Shipments WHERE OrderId = @OrderId", connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Shipment
                            {
                                ShipmentId = reader.GetString(reader.GetOrdinal("ShipmentId")),
                                OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                                TrackingNumber = reader.IsDBNull(reader.GetOrdinal("TrackingNumber")) ? null : reader.GetString(reader.GetOrdinal("TrackingNumber")),
                                Address = reader.GetString(reader.GetOrdinal("ShippingAddress")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate")),
                                ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ShippedDate")),
                                DeliveredDate = reader.IsDBNull(reader.GetOrdinal("DeliveredDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DeliveredDate"))
                            };
                        }
                    }
                }
            }
            return null;
        }
    }

    // Data Models
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
    }

    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Shipment ShipmentInfo { get; set; }
    }

    public class OrderSummary
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class Payment
    {
        public int PaymentId { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
    }

    public class Shipment
    {
        public string ShipmentId { get; set; }
        public string OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
    }
} 