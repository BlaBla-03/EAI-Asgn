using System;
using System.Windows.Forms;

namespace PrimeValueApp
{
    public partial class WarehouseStaffForm : Form
    {
        public WarehouseStaffForm()
        {
            InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Staff Portal";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Warehouse Staff Portal",
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
            var btnPickPackOrder = new Button { Text = "Pick & Pack Order", Location = new System.Drawing.Point(200, 120) };
            var btnBack = new Button { Text = "Back", Location = new System.Drawing.Point(200, 200) };
            // Style buttons directly
            foreach (var btn in new[] { btnPickPackOrder, btnBack })
            {
                btn.Height = 40;
                btn.Width = 200;
                btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                btn.BackColor = System.Drawing.Color.LightSteelBlue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }
            btnPickPackOrder.Click += (s, e) => new PickPackOrderForm().ShowDialog();
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnPickPackOrder);
            this.Controls.Add(btnBack);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WarehouseStaffForm
            // 
            this.ClientSize = new System.Drawing.Size(689, 383);
            this.Name = "WarehouseStaffForm";
            this.ResumeLayout(false);

        }
    }
} 