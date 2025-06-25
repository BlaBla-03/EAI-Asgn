namespace PrimeValueApp
{
    partial class DispatchOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnDispatch;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblResult;

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
            this.cboOrders = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnDispatch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Dispatch Order";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            // 
            // cboOrders
            // 
            this.cboOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrders.Location = new System.Drawing.Point(50, 80);
            this.cboOrders.Size = new System.Drawing.Size(300, 25);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(50, 120);
            this.txtAddress.Size = new System.Drawing.Size(300, 25);
            // 
            // btnDispatch
            // 
            this.btnDispatch.Text = "Dispatch";
            this.btnDispatch.Location = new System.Drawing.Point(370, 80);
            this.btnDispatch.Size = new System.Drawing.Size(150, 30);
            // 
            // btnBack
            // 
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(370, 120);
            this.btnBack.Size = new System.Drawing.Size(150, 30);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(50, 170);
            this.txtResult.Size = new System.Drawing.Size(470, 100);
            this.txtResult.Multiline = true;
            this.txtResult.ReadOnly = true;
            // 
            // lblOrderId
            // 
            this.lblOrderId.Text = "Order ID:";
            this.lblOrderId.Location = new System.Drawing.Point(50, 40);
            this.lblOrderId.Size = new System.Drawing.Size(100, 23);
            // 
            // lblAddress
            // 
            this.lblAddress.Text = "Shipping Address:";
            this.lblAddress.Location = new System.Drawing.Point(50, 80);
            this.lblAddress.Size = new System.Drawing.Size(120, 23);
            // 
            // lblResult
            // 
            this.lblResult.Text = "Result:";
            this.lblResult.Location = new System.Drawing.Point(50, 200);
            this.lblResult.Size = new System.Drawing.Size(100, 23);
            // 
            // DispatchOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cboOrders);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnDispatch);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DispatchOrderForm";
            this.Text = "Dispatch Order";
            this.ResumeLayout(false);
        }
        #endregion
    }
} 