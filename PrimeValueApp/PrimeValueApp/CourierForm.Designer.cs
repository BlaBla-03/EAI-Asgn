namespace PrimeValueApp
{
    partial class CourierForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDispatchOrder;
        private System.Windows.Forms.Button btnSetDelivered;
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
            this.btnDispatchOrder = new System.Windows.Forms.Button();
            this.btnSetDelivered = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Courier Portal";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            // 
            // btnDispatchOrder
            // 
            this.btnDispatchOrder.Text = "Dispatch Order";
            this.btnDispatchOrder.Location = new System.Drawing.Point(200, 120);
            this.btnDispatchOrder.Size = new System.Drawing.Size(200, 40);
            this.btnDispatchOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDispatchOrder.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDispatchOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispatchOrder.FlatAppearance.BorderSize = 0;
            // 
            // btnSetDelivered
            // 
            this.btnSetDelivered.Text = "Set Shipment Delivered";
            this.btnSetDelivered.Location = new System.Drawing.Point(200, 180);
            this.btnSetDelivered.Size = new System.Drawing.Size(200, 40);
            this.btnSetDelivered.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSetDelivered.BackColor = System.Drawing.Color.LightGreen;
            this.btnSetDelivered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDelivered.FlatAppearance.BorderSize = 0;
            // 
            // btnBack
            // 
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(200, 260);
            this.btnBack.Size = new System.Drawing.Size(200, 40);
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            // 
            // CourierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDispatchOrder);
            this.Controls.Add(this.btnSetDelivered);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CourierForm";
            this.Text = "Courier Portal";
            this.ResumeLayout(false);
        }
        #endregion
    }
} 