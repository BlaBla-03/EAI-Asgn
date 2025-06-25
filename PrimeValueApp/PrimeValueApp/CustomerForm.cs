using System;
using System.Windows.Forms;

namespace PrimeValueApp
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            // Do not call InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Portal";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Customer Portal",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Navy,
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 60
            };
            this.Controls.Add(lblTitle);
            lblTitle.BringToFront();
            InitializeUI();
        }
        private void InitializeUI()
        {
            var btnPlaceOrder = new Button { Text = "Place Order", Location = new System.Drawing.Point(200, 80) };
            var btnViewOrders = new Button { Text = "View Orders", Location = new System.Drawing.Point(200, 140) };
            var btnProceedPayment = new Button { Text = "Proceed Payment", Location = new System.Drawing.Point(200, 200) };
            var btnBack = new Button { Text = "Back", Location = new System.Drawing.Point(200, 320) };
            // Style buttons directly
            foreach (var btn in new[] { btnPlaceOrder, btnViewOrders, btnProceedPayment, btnBack })
            {
                btn.Height = 40;
                btn.Width = 200;
                btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                btn.BackColor = System.Drawing.Color.LightSteelBlue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }
            btnPlaceOrder.Click += (s, e) => new CreateOrderForm().ShowDialog();
            btnViewOrders.Click += (s, e) => new ViewOrdersForm().ShowDialog();
            btnProceedPayment.Click += (s, e) => new ProcessPaymentForm().ShowDialog();
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnPlaceOrder);
            this.Controls.Add(btnViewOrders);
            this.Controls.Add(btnProceedPayment);
            this.Controls.Add(btnBack);
        }
    }
} 