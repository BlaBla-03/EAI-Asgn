using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class PickPackOrderForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;

        public PickPackOrderForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick & Pack Order";
            _webService = new PrimeValueServiceSoapClient();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeUI();
            LoadOrders();
            // Wire up button events
            btnPickPack.Click += btnPickPack_Click;
            btnBack.Click += (s, e) => this.Close();
            // Wire up combo box selection change event
            cboOrders.SelectedIndexChanged += cboOrders_SelectedIndexChanged;
        }

        private void InitializeUI()
        {
            // Setup text box for order items
            txtOrderItems.Font = new System.Drawing.Font("Consolas", 9F);
            txtOrderItems.BackColor = System.Drawing.Color.White;
            txtOrderItems.ForeColor = System.Drawing.Color.Black;
        }

        private void LoadOrders()
        {
            cboOrders.Items.Clear();
            string ordersJson = _webService.GetAllOrders();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var orders = serializer.Deserialize<List<dynamic>>(ordersJson);
            foreach (var order in orders)
            {
                if (order["Status"] == "PAID")
                {
                    cboOrders.Items.Add(new { OrderId = order["OrderId"], Display = $"ID: {order["OrderId"].Substring(0, 8)}... - Status: {order["Status"]}" });
                }
            }
            cboOrders.DisplayMember = "Display";
            cboOrders.ValueMember = "OrderId";
        }

        private void cboOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                txtOrderItems.Clear();
                return;
            }

            try
            {
                dynamic selected = cboOrders.SelectedItem;
                string orderId = selected.OrderId;

                // Get order details including items
                string orderDetailsJson = _webService.GetOrderStatus(orderId);
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic orderDetails = serializer.DeserializeObject(orderDetailsJson);

                txtOrderItems.Clear();

                if (orderDetails.ContainsKey("error"))
                {
                    txtOrderItems.Text = $"Error loading order details: {orderDetails["error"]}";
                    return;
                }

                var itemsText = new System.Text.StringBuilder();
                itemsText.AppendLine("ORDER ITEMS:");
                itemsText.AppendLine(new string('-', 50));

                // Try to get the items as a list
                var itemsObj = orderDetails["Items"];
                if (itemsObj != null)
                {
                    var itemsList = itemsObj as System.Collections.IEnumerable;
                    int itemNumber = 1;
                    bool hasItems = false;

                    if (itemsList != null)
                    {
                        foreach (var item in itemsList)
                        {
                            hasItems = true;
                            var itemDict = item as System.Collections.Generic.Dictionary<string, object>;
                            if (itemDict != null)
                            {
                                string productName = itemDict.ContainsKey("ProductName") ? itemDict["ProductName"].ToString() : "Unknown";
                                string quantity = itemDict.ContainsKey("Quantity") ? itemDict["Quantity"].ToString() : "0";
                                string unitPrice = itemDict.ContainsKey("UnitPrice") ? itemDict["UnitPrice"].ToString() : "0";
                                string totalPrice = itemDict.ContainsKey("TotalPrice") ? itemDict["TotalPrice"].ToString() : "0";

                                itemsText.AppendLine($"Item {itemNumber}:");
                                itemsText.AppendLine($"  Product: {productName}");
                                itemsText.AppendLine($"  Quantity: {quantity}");
                                itemsText.AppendLine($"  Unit Price: ${unitPrice}");
                                itemsText.AppendLine($"  Total Price: ${totalPrice}");
                                itemsText.AppendLine();
                                itemNumber++;
                            }
                        }
                    }

                    if (!hasItems)
                    {
                        itemsText.AppendLine("No items found in this order.");
                    }
                    else if (orderDetails.ContainsKey("TotalPrice"))
                    {
                        itemsText.AppendLine(new string('-', 50));
                        itemsText.AppendLine($"ORDER TOTAL: ${orderDetails["TotalPrice"]}");
                    }
                }
                else
                {
                    itemsText.AppendLine("No items found in this order.");
                }

                txtOrderItems.Text = itemsText.ToString();
            }
            catch (Exception ex)
            {
                txtOrderItems.Text = $"Error loading order details: {ex.Message}";
            }
        }

        private void btnPickPack_Click(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }
            dynamic selected = cboOrders.SelectedItem;
            string orderId = selected.OrderId;
            string result = _webService.PickPackOrder(orderId);
            txtResult.Text = result;
            LoadOrders();
        }
    }
} 