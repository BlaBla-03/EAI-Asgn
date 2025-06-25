namespace PrimeValueApp
{
    partial class PickPackOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.Button btnPickPack;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtOrderItems;
        private System.Windows.Forms.Label lblOrderItems;

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
            this.btnPickPack = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtOrderItems = new System.Windows.Forms.TextBox();
            this.lblOrderItems = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 74);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pick & Pack Order";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboOrders
            // 
            this.cboOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrders.Location = new System.Drawing.Point(67, 98);
            this.cboOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboOrders.Name = "cboOrders";
            this.cboOrders.Size = new System.Drawing.Size(399, 24);
            this.cboOrders.TabIndex = 1;
            // 
            // btnPickPack
            // 
            this.btnPickPack.Location = new System.Drawing.Point(493, 98);
            this.btnPickPack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPickPack.Name = "btnPickPack";
            this.btnPickPack.Size = new System.Drawing.Size(200, 37);
            this.btnPickPack.TabIndex = 2;
            this.btnPickPack.Text = "Pick & Pack";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(493, 148);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(200, 37);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(67, 450);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(625, 122);
            this.txtResult.TabIndex = 4;
            // 
            // lblOrderId
            // 
            this.lblOrderId.Location = new System.Drawing.Point(67, 49);
            this.lblOrderId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(133, 28);
            this.lblOrderId.TabIndex = 5;
            this.lblOrderId.Text = "Order ID:";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.Location = new System.Drawing.Point(67, 463);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(133, 28);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Result:";
            // 
            // txtOrderItems
            // 
            this.txtOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderItems.Location = new System.Drawing.Point(67, 209);
            this.txtOrderItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrderItems.Multiline = true;
            this.txtOrderItems.Name = "txtOrderItems";
            this.txtOrderItems.ReadOnly = true;
            this.txtOrderItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOrderItems.Size = new System.Drawing.Size(625, 200);
            this.txtOrderItems.TabIndex = 7;
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.Location = new System.Drawing.Point(67, 177);
            this.lblOrderItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(133, 28);
            this.lblOrderItems.TabIndex = 8;
            this.lblOrderItems.Text = "Order Items:";
            // 
            // PickPackOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cboOrders);
            this.Controls.Add(this.btnPickPack);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtOrderItems);
            this.Controls.Add(this.lblOrderItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "PickPackOrderForm";
            this.Text = "Pick & Pack Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
} 