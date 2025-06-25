using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class DispatchOrderForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;

        public DispatchOrderForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatch Order";
            _webService = new PrimeValueServiceSoapClient();
            InitializeUI();
            LoadOrders();
            // Wire up button events
            btnDispatch.Click += btnDispatch_Click;
            btnBack.Click += (s, e) => this.Close();
        }

        private void InitializeUI()
        {
            // UI setup only, do not wire up events here
        }

        private void LoadOrders()
        {
            cboOrders.Items.Clear();
            string ordersJson = _webService.GetAllOrders();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var orders = serializer.Deserialize<List<dynamic>>(ordersJson);
            foreach (var order in orders)
            {
                if (order["Status"] == "PACKED")
                {
                    cboOrders.Items.Add(new { OrderId = order["OrderId"], Display = $"ID: {order["OrderId"].Substring(0, 8)}... - Status: {order["Status"]}" });
                }
            }
            cboOrders.DisplayMember = "Display";
            cboOrders.ValueMember = "OrderId";
        }

        private void btnDispatch_Click(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter a shipping address.");
                return;
            }
            dynamic selected = cboOrders.SelectedItem;
            string orderId = selected.OrderId;
            string address = txtAddress.Text;
            string result = _webService.DispatchOrder(orderId, address);
            txtResult.Text = result;
            LoadOrders();
        }
    }
} 