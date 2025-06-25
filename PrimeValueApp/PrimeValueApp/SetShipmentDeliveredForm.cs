using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class SetShipmentDeliveredForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;
        private ComboBox cboOrders;
        private Button btnSetDelivered;
        private Button btnBack;
        private TextBox txtResult;

        public SetShipmentDeliveredForm()
        {
            this.Size = new System.Drawing.Size(600, 300);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Shipment Delivered";

            var lblTitle = new Label
            {
                Text = "Set Shipment Delivered",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Navy,
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };
            var lblOrderId = new Label
            {
                Text = "Order ID:",
                Location = new System.Drawing.Point(100, 60),
                Size = new System.Drawing.Size(100, 23)
            };
            var lblResult = new Label
            {
                Text = "Result:",
                Location = new System.Drawing.Point(100, 110),
                Size = new System.Drawing.Size(100, 23)
            };
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblOrderId);
            this.Controls.Add(lblResult);
            lblTitle.BringToFront();

            cboOrders = new ComboBox { Location = new System.Drawing.Point(100, 80), Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            btnSetDelivered = new Button { Text = "Set Delivered", Location = new System.Drawing.Point(420, 80), Width = 120, Height = 30, BackColor = System.Drawing.Color.LightGreen, FlatStyle = FlatStyle.Flat };
            btnSetDelivered.FlatAppearance.BorderSize = 0;
            btnBack = new Button { Text = "Back", Location = new System.Drawing.Point(250, 200), Width = 100, Height = 30, BackColor = System.Drawing.Color.WhiteSmoke, FlatStyle = FlatStyle.Flat };
            btnBack.FlatAppearance.BorderSize = 0;
            txtResult = new TextBox { Location = new System.Drawing.Point(100, 130), Width = 440, Height = 50, ReadOnly = true, Multiline = true };

            btnSetDelivered.Click += BtnSetDelivered_Click;
            btnBack.Click += (s, e) => this.Close();

            this.Controls.Add(cboOrders);
            this.Controls.Add(btnSetDelivered);
            this.Controls.Add(btnBack);
            this.Controls.Add(txtResult);

            _webService = new PrimeValueServiceSoapClient();
            LoadOrders();
        }

        private void LoadOrders()
        {
            cboOrders.Items.Clear();
            string ordersJson = _webService.GetAllOrders();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var orders = serializer.Deserialize<List<dynamic>>(ordersJson);
            foreach (var order in orders)
            {
                // Fetch full shipment status for each order
                string orderId = order["OrderId"];
                string shipmentStatus = "";
                try
                {
                    string shipmentJson = _webService.GetShipmentStatus(orderId);
                    dynamic shipment = serializer.DeserializeObject(shipmentJson);
                    if (shipment.ContainsKey("Status"))
                        shipmentStatus = shipment["Status"];
                }
                catch { }

                // Only show orders with shipment status IN_TRANSIT
                if (shipmentStatus == "IN_TRANSIT")
                {
                    cboOrders.Items.Add(new { OrderId = orderId, Display = $"ID: {orderId.Substring(0, 8)}... - Status: {shipmentStatus}" });
                }
            }
            cboOrders.DisplayMember = "Display";
            cboOrders.ValueMember = "OrderId";
        }

        private void BtnSetDelivered_Click(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }
            dynamic selected = cboOrders.SelectedItem;
            string orderId = selected.OrderId;
            string result = _webService.GetShipmentStatus(orderId);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic shipment = serializer.DeserializeObject(result);
            if (shipment.ContainsKey("error"))
            {
                txtResult.Text = "No shipment found for this order.";
                return;
            }
            // Call the new SetShipmentDelivered method
            string setResult = _webService.SetShipmentDelivered(orderId);
            txtResult.Text = setResult;
            LoadOrders();
        }
    }
} 