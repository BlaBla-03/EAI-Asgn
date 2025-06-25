namespace PrimeValueApp
{
    partial class WarehouseStaffForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPickPackOrder;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPickPackOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Warehouse Staff Portal";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            // 
            // btnPickPackOrder
            // 
            this.btnPickPackOrder.Text = "Pick & Pack Order";
            this.btnPickPackOrder.Location = new System.Drawing.Point(200, 120);
            this.btnPickPackOrder.Size = new System.Drawing.Size(200, 40);
            this.btnPickPackOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPickPackOrder.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPickPackOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickPackOrder.FlatAppearance.BorderSize = 0;
            // 
            // btnBack
            // 
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(200, 200);
            this.btnBack.Size = new System.Drawing.Size(200, 40);
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            // 
            // WarehouseStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnPickPackOrder);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WarehouseStaffForm";
            this.Text = "Warehouse Staff Portal";
            this.ResumeLayout(false);
        }
        #endregion
    }
} 