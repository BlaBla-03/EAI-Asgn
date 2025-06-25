using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class ShipmentManagementForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;

        public ShipmentManagementForm()
        {
            InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipment Management";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Shipment Management",
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
            this.Text = "Shipment Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadOrders();
            // Wire up button events
            btnInitiateShipment.Click += btnInitiateShipment_Click;
            btnCheckShipmentStatus.Click += btnCheckShipmentStatus_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        private void LoadOrders()
        {
            try
            {
                string ordersJson = _webService.GetAllOrders();
                var serializer = new JavaScriptSerializer();
                var orders = serializer.Deserialize<List<dynamic>>(ordersJson);
                
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

        private void btnInitiateShipment_Click(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedOrder = cboOrders.SelectedItem;
            string orderId = selectedOrder.OrderId;

            try
            {
                if (string.IsNullOrWhiteSpace(txtShippingAddress.Text))
                {
                    MessageBox.Show("Please enter a shipping address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var shippingInfo = new { Address = txtShippingAddress.Text };
                var serializer = new JavaScriptSerializer();
                string shippingInfoJson = serializer.Serialize(shippingInfo);

                // Call web service to initiate shipment
                string result = _webService.InitiateShipment(orderId, shippingInfoJson);
                
                // Parse the JSON response
                dynamic response = serializer.DeserializeObject(result);
                
                if (response.ContainsKey("error"))
                {
                    MessageBox.Show($"Shipment initiation failed: {response["error"]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string responseOrderId = response["orderId"];
                    string shipmentStatus = response["shipmentStatus"];
                    
                    txtResult.Text = $"Shipment initiated successfully!\nOrder ID: {responseOrderId}\nStatus: {shipmentStatus}\nAddress: {txtShippingAddress.Text}";
                    
                    MessageBox.Show($"Shipment initiated successfully!\nOrder ID: {responseOrderId}\nStatus: {shipmentStatus}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Clear form and reload orders
                    txtShippingAddress.Clear();
                    txtResult.Clear();
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initiating shipment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckShipmentStatus_Click(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            dynamic selectedOrder = cboOrders.SelectedItem;
            string orderId = selectedOrder.OrderId;

            try
            {
                // Call web service to check shipment status
                string result = _webService.GetShipmentStatus(orderId);
                
                // Parse the JSON response
                var serializer = new JavaScriptSerializer();
                dynamic response = serializer.DeserializeObject(result);
                
                if (response.ContainsKey("error"))
                {
                    txtResult.Text = $"No shipment found for Order ID: {orderId}";
                }
                else
                {
                    var resultText = new System.Text.StringBuilder();
                    var responseDict = (IDictionary<string, object>)response;

                    if (responseDict.ContainsKey("TrackingNumber"))
                    {
                        resultText.AppendLine($"Tracking ID: {responseDict["TrackingNumber"]}");
                    }
                    if (responseDict.ContainsKey("Status"))
                    {
                        resultText.AppendLine($"Status: {responseDict["Status"]}");
                    }
                    if (responseDict.ContainsKey("Address"))
                    {
                        resultText.AppendLine($"Address: {responseDict["Address"]}");
                    }
                    txtResult.Text = resultText.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking shipment status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboOrders.SelectedIndex = -1;
            txtShippingAddress.Clear();
            txtResult.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 