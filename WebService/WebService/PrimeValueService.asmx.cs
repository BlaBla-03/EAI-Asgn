using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using WebService.Data;

namespace WebService
{
    /// <summary>
    /// Summary description for PrimeValueService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class PrimeValueService : System.Web.Services.WebService
    {
        private readonly DatabaseContext _dbContext;

        public PrimeValueService()
        {
            _dbContext = new DatabaseContext();
        }

        private string Serialize(object obj)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "Returns a list of all available products.")]
        public string GetProducts()
        {
            try
            {
                var products = _dbContext.GetProducts();
                return Serialize(products);
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Returns a summary list of all orders.")]
        public string GetAllOrders()
        {
            try
            {
                var orders = _dbContext.GetAllOrders();
                return Serialize(orders);
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Creates a new order from a list of items and returns the generated orderId.")]
        public string CreateOrder(List<OrderItemRequest> items)
        {
            try
            {
                if (items == null || items.Count == 0)
                {
                    return Serialize(new { error = "No items provided for order." });
                }

                // Get products to calculate prices
                var products = _dbContext.GetProducts();
                var orderItems = new List<Data.OrderItem>();
                decimal totalPrice = 0;

                foreach (var item in items)
                {
                    var product = products.FirstOrDefault(p => p.ProductId == item.ProductId);
                    if (product == null)
                    {
                        return Serialize(new { error = $"Product with ID {item.ProductId} not found." });
                    }

                    var orderItem = new Data.OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price,
                        TotalPrice = product.Price * item.Quantity
                    };
                    orderItems.Add(orderItem);
                    totalPrice += orderItem.TotalPrice;
                }

                var order = new Data.Order
                {
                    OrderId = Guid.NewGuid().ToString(),
                    Items = orderItems,
                    TotalPrice = totalPrice,
                    Status = "PENDING",
                    CreationDate = DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow
                };

                _dbContext.CreateOrder(order);
                return Serialize(new { orderId = order.OrderId, status = "PENDING", creationDate = order.CreationDate, totalPrice });
            }
            catch (Exception ex)
            {
                // Return full exception details for debugging
                return Serialize(new { error = ex.ToString() });
            }
        }

        [WebMethod(Description = "Returns current status details for an order.")]
        public string GetOrderStatus(string orderId)
        {
            try
            {
                var order = _dbContext.GetOrder(orderId);
                if (order != null)
                {
                    return Serialize(order);
                }
                return Serialize(new { error = "ORDER_NOT_FOUND" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Simulates payment processing and updates order status to PAID.")]
        public string ProcessPayment(string orderId, decimal amount)
        {
            try
            {
                var order = _dbContext.GetOrder(orderId);
                if (order == null)
                {
                    return Serialize(new { error = "ORDER_NOT_FOUND" });
                }

                // Only allow payment if order is in PENDING status
                if (order.Status != "PENDING")
                {
                    return Serialize(new { error = "Order cannot be paid. Only orders in PENDING status can be paid." });
                }

                var payment = new Data.Payment
                {
                    OrderId = orderId,
                    Amount = amount,
                    Status = "SUCCESS",
                    PaymentMethod = "Credit Card",
                    TransactionId = Guid.NewGuid().ToString(),
                    PaymentDate = DateTime.UtcNow
                };

                _dbContext.CreatePayment(payment);
                _dbContext.UpdateOrderStatus(orderId, "PAID");

                return Serialize(new { orderId, paymentStatus = "SUCCESS" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Returns payment status for an order.")]
        public string PaymentStatus(string orderId)
        {
            try
            {
                var payment = _dbContext.GetPayment(orderId);
                if (payment != null)
                {
                    return Serialize(payment);
                }
                return Serialize(new { error = "PAYMENT_NOT_FOUND" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Creates a shipment and updates order status to SHIPPED.")]
        public string InitiateShipment(string orderId, string shippingInfoJson)
        {
            try
            {
                if (string.IsNullOrEmpty(orderId) || string.IsNullOrEmpty(shippingInfoJson))
                {
                    return Serialize(new { error = "Order ID and shipping info are required." });
                }

                var order = _dbContext.GetOrder(orderId);
                if (order == null)
                {
                    return Serialize(new { error = "Order not found." });
                }

                if (order.Status != "PAID")
                {
                    return Serialize(new { error = "Order has not been paid for." });
                }

                var shipment = new Data.Shipment
                {
                    ShipmentId = Guid.NewGuid().ToString(),
                    OrderId = orderId,
                    Address = shippingInfoJson,
                    Status = "CREATED",
                    CreatedDate = DateTime.UtcNow
                };

                _dbContext.CreateShipment(shipment);
                _dbContext.UpdateOrderStatus(orderId, "PICKING");

                return Serialize(new { shipmentId = shipment.ShipmentId, status = "CREATED" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Returns shipment status for an order.")]
        public string GetShipmentStatus(string orderId)
        {
            try
            {
                var shipment = _dbContext.GetShipment(orderId);
                if (shipment != null)
                {
                    return Serialize(shipment);
                }
                return Serialize(new { error = "SHIPMENT_NOT_FOUND" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Warehouse staff picks and packs the order, updating status to PACKED.")]
        public string PickPackOrder(string orderId)
        {
            try
            {
                var order = _dbContext.GetOrder(orderId);
                if (order == null)
                {
                    return Serialize(new { error = "Order not found." });
                }

                // Allow pick/pack for both PAID and PICKING statuses
                if (order.Status != "PAID" && order.Status != "PICKING")
                {
                    return Serialize(new { error = "Order is not in a pickable status (must be PAID or PICKING)." });
                }

                _dbContext.UpdateOrderStatus(orderId, "PACKED");
                return Serialize(new { orderId, status = "PACKED" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Courier dispatches the order, updating status to SHIPPED and assigning a tracking number.")]
        public string DispatchOrder(string orderId, string address)
        {
            try
            {
                var order = _dbContext.GetOrder(orderId);
                if (order == null)
                {
                    return Serialize(new { error = "Order not found." });
                }

                // Allow dispatch only if order is PACKED
                if (order.Status != "PACKED")
                {
                    return Serialize(new { error = "Order is not ready for dispatch." });
                }

                var shipment = _dbContext.GetShipment(orderId);
                if (shipment == null)
                {
                    // Create shipment using provided address
                    shipment = new Data.Shipment
                    {
                        ShipmentId = Guid.NewGuid().ToString(),
                        OrderId = orderId,
                        Address = address,
                        Status = "IN_TRANSIT",
                        CreatedDate = DateTime.UtcNow
                    };
                    _dbContext.CreateShipment(shipment);
                }
                else
                {
                    // Update shipment address and status if needed
                    shipment.Address = address;
                    shipment.Status = "IN_TRANSIT";
                }

                var trackingNumber = "TRK" + DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                _dbContext.UpdateShipmentStatus(shipment.ShipmentId, "IN_TRANSIT", DateTime.UtcNow);
                _dbContext.UpdateOrderStatus(orderId, "SHIPPED");

                return Serialize(new { orderId, trackingNumber, status = "SHIPPED" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Customer confirms delivery, updating status to DELIVERED.")]
        public string ConfirmDelivery(string orderId)
        {
            try
            {
                var order = _dbContext.GetOrder(orderId);
                if (order == null)
                {
                    return Serialize(new { error = "Order not found." });
                }

                if (order.Status != "SHIPPED")
                {
                    return Serialize(new { error = "Order is not in shipped status." });
                }

                var shipment = _dbContext.GetShipment(orderId);
                if (shipment != null)
                {
                    _dbContext.UpdateShipmentStatus(shipment.ShipmentId, "DELIVERED", null, DateTime.UtcNow);
                }

                _dbContext.UpdateOrderStatus(orderId, "DELIVERED");
                return Serialize(new { orderId, status = "DELIVERED" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod(Description = "Courier sets shipment status to DELIVERED.")]
        public string SetShipmentDelivered(string orderId)
        {
            try
            {
                var shipment = _dbContext.GetShipment(orderId);
                if (shipment == null)
                {
                    return Serialize(new { error = "Shipment not found." });
                }

                _dbContext.UpdateShipmentStatus(shipment.ShipmentId, "DELIVERED", null, DateTime.UtcNow);
                _dbContext.UpdateOrderStatus(orderId, "DELIVERED");

                return Serialize(new { orderId, status = "DELIVERED" });
            }
            catch (Exception ex)
            {
                return Serialize(new { error = ex.Message });
            }
        }

        [WebMethod]
        public string TestDbConnection()
        {
            try
            {
                var products = _dbContext.GetProducts();
                return $"Success. Found {products.Count} products.";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }

    // Request models for web service
    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
