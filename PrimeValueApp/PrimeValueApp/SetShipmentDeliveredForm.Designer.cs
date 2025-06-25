namespace PrimeValueApp
{
    partial class SetShipmentDeliveredForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.Button btnSetDelivered;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtResult;

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
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.cboOrders = new System.Windows.Forms.ComboBox();
            this.btnSetDelivered = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Set Shipment Delivered";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            // 
            // lblOrderId
            // 
            this.lblOrderId.Text = "Order ID:";
            this.lblOrderId.Location = new System.Drawing.Point(100, 60);
            this.lblOrderId.Size = new System.Drawing.Size(100, 23);
            // 
            // lblResult
            // 
            this.lblResult.Text = "Result:";
            this.lblResult.Location = new System.Drawing.Point(100, 110);
            this.lblResult.Size = new System.Drawing.Size(100, 23);
            // 
            // cboOrders
            // 
            this.cboOrders.Location = new System.Drawing.Point(100, 80);
            this.cboOrders.Width = 300;
            this.cboOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // btnSetDelivered
            // 
            this.btnSetDelivered.Text = "Set Delivered";
            this.btnSetDelivered.Location = new System.Drawing.Point(420, 80);
            this.btnSetDelivered.Size = new System.Drawing.Size(120, 30);
            this.btnSetDelivered.BackColor = System.Drawing.Color.LightGreen;
            this.btnSetDelivered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetDelivered.FlatAppearance.BorderSize = 0;
            // 
            // btnBack
            // 
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(250, 200);
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(100, 130);
            this.txtResult.Size = new System.Drawing.Size(440, 50);
            this.txtResult.ReadOnly = true;
            this.txtResult.Multiline = true;
            // 
            // SetShipmentDeliveredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cboOrders);
            this.Controls.Add(this.btnSetDelivered);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetShipmentDeliveredForm";
            this.Text = "Set Shipment Delivered";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
} 