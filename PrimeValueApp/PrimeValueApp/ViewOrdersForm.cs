using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class ViewOrdersForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;
        private List<ViewOrderProduct> _availableProducts;

        public ViewOrdersForm()
        {
            InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Order Status";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "View Order Status",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Navy,
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 60
            };
            this.Controls.Add(lblTitle);
            lblTitle.BringToFront();
            _webService = new PrimeValueServiceSoapClient();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadProducts();
            LoadOrders();
            // Wire up event handlers
            cboOrders.SelectedIndexChanged += cboOrders_SelectedIndexChanged;
            btnBack.Click += btnBack_Click;
        }

        private void LoadProducts()
        {
            try
            {
                string productsJson = _webService.GetProducts();
                var serializer = new JavaScriptSerializer();
                _availableProducts = serializer.Deserialize<List<ViewOrderProduct>>(productsJson);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _availableProducts = new List<ViewOrderProduct>(); 
            }
        }

        private void LoadOrders()
        {
            try
            {
                string ordersJson = _webService.GetAllOrders();
                var serializer = new JavaScriptSerializer();
                var orders = serializer.Deserialize<List<dynamic>>(ordersJson);
                
                // We create a new list of anonymous objects for display
                var displayOrders = orders.Select(o => new {
                    OrderId = o["OrderId"],
                    DisplayText = $"ID: {o["OrderId"].Substring(0, 8)}... - Status: {o["Status"]}"
                }).ToList();

                cboOrders.DataSource = displayOrders;
                cboOrders.DisplayMember = "DisplayText";
                cboOrders.ValueMember = "OrderId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                ClearResults();
                return;
            }

            // Cast the selected item to dynamic to access its properties.
            dynamic selectedOrder = cboOrders.SelectedItem;
            string selectedOrderId = selectedOrder.OrderId;

            if (string.IsNullOrEmpty(selectedOrderId))
            {
                ClearResults();
                return;
            }

            try
            {
                // Call web service to get order status
                string result = _webService.GetOrderStatus(selectedOrderId);
                
                // Parse the JSON response
                var serializer = new JavaScriptSerializer();
                dynamic response = serializer.DeserializeObject(result);
                
                if (response.ContainsKey("error"))
                {
                    MessageBox.Show($"Order not found: {response["error"]}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearResults();
                }
                else
                {
                    // Display order details
                    var responseDict = response as IDictionary<string, object>;
                    if (responseDict != null)
                    {
                        txtOrderIdResult.Text = responseDict.ContainsKey("OrderId") ? responseDict["OrderId"].ToString() : "-";

                        if (responseDict.ContainsKey("Items") && responseDict["Items"] is object[] items)
                        {
                            var itemDetails = new List<string>();
                            foreach(var itemObj in items)
                            {
                                var item = itemObj as Dictionary<string, object>;
                                if (item != null)
                                {
                                    int productId = item.ContainsKey("ProductId") ? Convert.ToInt32(item["ProductId"]) : 0;
                                    int quantity = item.ContainsKey("Quantity") ? Convert.ToInt32(item["Quantity"]) : 0;
                                    var product = _availableProducts?.FirstOrDefault(p => p.ProductId == productId);
                                    if (product != null)
                                    {
                                        itemDetails.Add($"{product.Name} (x{quantity}) - {string.Format("RM {0:N2}", product.Price * quantity)}");
                                    }
                                    else
                                    {
                                        itemDetails.Add($"Product ID: {productId}, Quantity: {quantity} - (Details not found)");
                                    }
                                }
                            }
                            txtItemsResult.Text = string.Join(Environment.NewLine, itemDetails);
                        }
                        else
                        {
                            txtItemsResult.Text = "-";
                        }

                        txtStatusResult.Text = responseDict.ContainsKey("Status") ? responseDict["Status"].ToString() : "-";
                        // Show shipping address if available
                        txtShippingAddress.Text = responseDict.ContainsKey("Address") ? responseDict["Address"].ToString() : "-";
                    }
                    else
                    {
                        txtOrderIdResult.Text = txtItemsResult.Text = txtStatusResult.Text = txtShippingAddress.Text = "-";
                    }
                    // Check payment status
                    string paymentResult = _webService.PaymentStatus(selectedOrderId);
                    dynamic paymentResponse = serializer.DeserializeObject(paymentResult);
                    if (paymentResponse.ContainsKey("error"))
                    {
                        txtPaymentStatus.Text = "No payment found";
                    }
                    else
                    {
                        txtPaymentStatus.Text = (paymentResponse.ContainsKey("Status") && paymentResponse.ContainsKey("Amount"))
                            ? $"Status: {paymentResponse["Status"]}, Amount: {string.Format("RM {0:N2}", paymentResponse["Amount"])}"
                            : "-";
                    }
                    // Check shipment status
                    string shipmentResult = _webService.GetShipmentStatus(selectedOrderId);
                    dynamic shipmentResponse = serializer.DeserializeObject(shipmentResult);
                    if (shipmentResponse.ContainsKey("error"))
                    {
                        txtShipmentStatus.Text = "No shipment found";
                    }
                    else
                    {
                        // Show all available shipment details
                        string status = shipmentResponse.ContainsKey("Status") ? shipmentResponse["Status"].ToString() : "-";
                        string tracking = shipmentResponse.ContainsKey("TrackingId") ? shipmentResponse["TrackingId"].ToString() : "-";
                        string address = shipmentResponse.ContainsKey("Address") ? shipmentResponse["Address"].ToString() : "-";
                        txtShipmentStatus.Text = $"Status: {status}, Tracking: {tracking}, Address: {address}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearResults();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearResults()
        {
            txtOrderIdResult.Clear();
            txtItemsResult.Clear();
            txtStatusResult.Clear();
            txtShippingAddress.Clear();
            txtPaymentStatus.Clear();
            txtShipmentStatus.Clear();
        }
    }

    // A local definition of the Product class to help with deserialization.
    public class ViewOrderProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
} 