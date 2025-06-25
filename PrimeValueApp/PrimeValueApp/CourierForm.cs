using System;
using System.Windows.Forms;
using PrimeValueApp;

namespace PrimeValueApp
{
    public partial class CourierForm : Form
    {
        public CourierForm()
        {
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Courier Portal";

            // Add title label
            var lblTitle = new Label
            {
                Text = "Courier Portal",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Navy,
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };
            this.Controls.Add(lblTitle);
            lblTitle.BringToFront();

            InitializeUI();
        }
        private void InitializeUI()
        {
            var btnDispatchOrder = new Button
            {
                Text = "Dispatch Order",
                Location = new System.Drawing.Point(200, 120),
                Height = 40,
                Width = 200,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSteelBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnDispatchOrder.FlatAppearance.BorderSize = 0;

            var btnSetDelivered = new Button
            {
                Text = "Set Shipment Delivered",
                Location = new System.Drawing.Point(200, 180),
                Height = 40,
                Width = 200,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            btnSetDelivered.FlatAppearance.BorderSize = 0;

            var btnBack = new Button
            {
                Text = "Back",
                Location = new System.Drawing.Point(200, 260),
                Height = 40,
                Width = 200,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.WhiteSmoke,
                FlatStyle = FlatStyle.Flat
            };
            btnBack.FlatAppearance.BorderSize = 0;

            btnDispatchOrder.Click += (s, e) => new DispatchOrderForm().ShowDialog();
            btnSetDelivered.Click += (s, e) => new SetShipmentDeliveredForm().ShowDialog();
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnDispatchOrder);
            this.Controls.Add(btnSetDelivered);
            this.Controls.Add(btnBack);
        }
    }
} 