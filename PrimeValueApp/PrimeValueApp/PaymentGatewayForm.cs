using System;
using System.Windows.Forms;

namespace PrimeValueApp
{
    public partial class PaymentGatewayForm : Form
    {
        public PaymentGatewayForm()
        {
            // Do not call InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Gateway Portal";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Payment Gateway Portal",
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
            var btnProcessPayment = new Button { Text = "Process Payment", Location = new System.Drawing.Point(200, 120) };
            var btnBack = new Button { Text = "Back", Location = new System.Drawing.Point(200, 200) };
            // Style buttons directly
            foreach (var btn in new[] { btnProcessPayment, btnBack })
            {
                btn.Height = 40;
                btn.Width = 200;
                btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                btn.BackColor = System.Drawing.Color.LightSteelBlue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }
            btnProcessPayment.Click += (s, e) => new ProcessPaymentForm().ShowDialog();
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnProcessPayment);
            this.Controls.Add(btnBack);
        }
    }
} 