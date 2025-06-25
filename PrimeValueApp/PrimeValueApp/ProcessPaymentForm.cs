using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class ProcessPaymentForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;

        public ProcessPaymentForm()
        {
            InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Payment";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Process Payment",
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
            this.Text = "Process Payment";
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadOrders();
            this.cboOrders.SelectedIndexChanged += new System.EventHandler(this.cboOrders_SelectedIndexChanged);
            lblOrderTotal.Text = "";
            // Wire up button events
            btnProcessPayment.Click += btnProcessPayment_Click;
            btnCheckPaymentStatus.Click += btnCheckPaymentStatus_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        private void cboOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrders.SelectedItem == null)
            {
                lblOrderTotal.Text = "";
                txtAmount.Clear();
                return;
            }

            try
            {
                dynamic selectedOrderInfo = cboOrders.SelectedItem;
                string orderId = selectedOrderInfo.OrderId;

                string result = _webService.GetOrderStatus(orderId);
                var serializer = new JavaScriptSerializer();
                dynamic orderDetails = serializer.DeserializeObject(result);
                var orderDict = orderDetails as IDictionary<string, object>;

                if (orderDict == null || orderDict.ContainsKey("error"))
                {
                    MessageBox.Show($"Could not retrieve details for order {orderId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblOrderTotal.Text = "Error loading total.";
                    txtAmount.Clear();
                }
                else
                {
                    object priceValue;
                    if (orderDict.TryGetValue("TotalPrice", out priceValue))
                    {
                        decimal totalPrice = Convert.ToDecimal(priceValue);
                        lblOrderTotal.Text = $"Order Total: {string.Format("RM {0:N2}", totalPrice)}";
                        txtAmount.Text = totalPrice.ToString("F2");
                    }
                    else
                    {
                        lblOrderTotal.Text = "Total not available.";
                        txtAmount.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblOrderTotal.Text = "";
                txtAmount.Clear();
            }
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

        private void btnProcessPayment_Click(object sender, EventArgs e)
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
                if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
                {
                    MessageBox.Show("Please enter a valid amount greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Call web service to process payment
                string result = _webService.ProcessPayment(orderId, (decimal)amount);
                
                // Parse the JSON response
                var serializer = new JavaScriptSerializer();
                dynamic response = serializer.DeserializeObject(result);
                
                if (response.ContainsKey("error"))
                {
                    MessageBox.Show($"Payment failed: {response["error"]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string responseOrderId = response["orderId"];
                    string paymentStatus = response["paymentStatus"];
                    
                    txtResult.Text = $"Payment processed successfully!\nOrder ID: {responseOrderId}\nStatus: {paymentStatus}\nAmount: {string.Format("RM {0:N2}", amount)}";
                    
                    MessageBox.Show($"Payment processed successfully!\nOrder ID: {responseOrderId}\nStatus: {paymentStatus}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Clear form and reload orders to reflect status change
                    txtAmount.Clear();
                    txtResult.Clear();
                    LoadOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckPaymentStatus_Click(object sender, EventArgs e)
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
                // Call web service to check payment status
                string result = _webService.PaymentStatus(orderId);
                
                // Parse the JSON response
                var serializer = new JavaScriptSerializer();
                dynamic response = serializer.DeserializeObject(result);
                
                if (response.ContainsKey("error"))
                {
                    txtResult.Text = $"No payment found for Order ID: {orderId}";
                }
                else
                {
                    // Handle amount as decimal to prevent casting issues and format as currency
                    decimal amount = Convert.ToDecimal(response["Amount"]);
                    txtResult.Text = $"Payment Status: {response["Status"]}\nAmount: {string.Format("RM {0:N2}", amount)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking payment status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboOrders.SelectedIndex = -1;
            txtAmount.Clear();
            txtResult.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 