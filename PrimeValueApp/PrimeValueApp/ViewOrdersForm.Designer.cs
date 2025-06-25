namespace PrimeValueApp
{
    partial class ViewOrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboOrders = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblOrderIdResult = new System.Windows.Forms.Label();
            this.txtOrderIdResult = new System.Windows.Forms.TextBox();
            this.lblItemsResult = new System.Windows.Forms.Label();
            this.txtItemsResult = new System.Windows.Forms.TextBox();
            this.lblStatusResult = new System.Windows.Forms.Label();
            this.txtStatusResult = new System.Windows.Forms.TextBox();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.txtPaymentStatus = new System.Windows.Forms.TextBox();
            this.lblShipmentStatus = new System.Windows.Forms.Label();
            this.txtShipmentStatus = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.lblTitle.Text = "View Order Status";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboOrders
            // 
            this.cboOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrders.Location = new System.Drawing.Point(67, 86);
            this.cboOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboOrders.Name = "cboOrders";
            this.cboOrders.Size = new System.Drawing.Size(332, 24);
            this.cboOrders.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(427, 86);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(133, 31);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            // 
            // lblOrderIdResult
            // 
            this.lblOrderIdResult.Location = new System.Drawing.Point(67, 135);
            this.lblOrderIdResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderIdResult.Name = "lblOrderIdResult";
            this.lblOrderIdResult.Size = new System.Drawing.Size(133, 28);
            this.lblOrderIdResult.TabIndex = 3;
            this.lblOrderIdResult.Text = "Order ID:";
            // 
            // txtOrderIdResult
            // 
            this.txtOrderIdResult.Location = new System.Drawing.Point(240, 135);
            this.txtOrderIdResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOrderIdResult.Name = "txtOrderIdResult";
            this.txtOrderIdResult.ReadOnly = true;
            this.txtOrderIdResult.Size = new System.Drawing.Size(332, 22);
            this.txtOrderIdResult.TabIndex = 4;
            // 
            // lblItemsResult
            // 
            this.lblItemsResult.Location = new System.Drawing.Point(67, 185);
            this.lblItemsResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemsResult.Name = "lblItemsResult";
            this.lblItemsResult.Size = new System.Drawing.Size(133, 28);
            this.lblItemsResult.TabIndex = 5;
            this.lblItemsResult.Text = "Items:";
            // 
            // txtItemsResult
            // 
            this.txtItemsResult.Location = new System.Drawing.Point(240, 185);
            this.txtItemsResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtItemsResult.Multiline = true;
            this.txtItemsResult.Name = "txtItemsResult";
            this.txtItemsResult.ReadOnly = true;
            this.txtItemsResult.Size = new System.Drawing.Size(332, 61);
            this.txtItemsResult.TabIndex = 6;
            // 
            // lblStatusResult
            // 
            this.lblStatusResult.Location = new System.Drawing.Point(67, 258);
            this.lblStatusResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusResult.Name = "lblStatusResult";
            this.lblStatusResult.Size = new System.Drawing.Size(133, 28);
            this.lblStatusResult.TabIndex = 7;
            this.lblStatusResult.Text = "Status:";
            // 
            // txtStatusResult
            // 
            this.txtStatusResult.Location = new System.Drawing.Point(240, 258);
            this.txtStatusResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatusResult.Name = "txtStatusResult";
            this.txtStatusResult.ReadOnly = true;
            this.txtStatusResult.Size = new System.Drawing.Size(332, 22);
            this.txtStatusResult.TabIndex = 8;
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.Location = new System.Drawing.Point(67, 308);
            this.lblPaymentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(165, 21);
            this.lblPaymentStatus.TabIndex = 9;
            this.lblPaymentStatus.Text = "Payment Status:";
            // 
            // txtPaymentStatus
            // 
            this.txtPaymentStatus.Location = new System.Drawing.Point(240, 308);
            this.txtPaymentStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaymentStatus.Name = "txtPaymentStatus";
            this.txtPaymentStatus.ReadOnly = true;
            this.txtPaymentStatus.Size = new System.Drawing.Size(332, 22);
            this.txtPaymentStatus.TabIndex = 10;
            // 
            // lblShipmentStatus
            // 
            this.lblShipmentStatus.Location = new System.Drawing.Point(67, 357);
            this.lblShipmentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShipmentStatus.Name = "lblShipmentStatus";
            this.lblShipmentStatus.Size = new System.Drawing.Size(173, 21);
            this.lblShipmentStatus.TabIndex = 11;
            this.lblShipmentStatus.Text = "Shipment Status:";
            // 
            // txtShipmentStatus
            // 
            this.txtShipmentStatus.Location = new System.Drawing.Point(240, 357);
            this.txtShipmentStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtShipmentStatus.Multiline = true;
            this.txtShipmentStatus.Name = "txtShipmentStatus";
            this.txtShipmentStatus.ReadOnly = true;
            this.txtShipmentStatus.Size = new System.Drawing.Size(332, 64);
            this.txtShipmentStatus.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.cboOrders);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.lblOrderIdResult);
            this.panel1.Controls.Add(this.txtOrderIdResult);
            this.panel1.Controls.Add(this.lblItemsResult);
            this.panel1.Controls.Add(this.txtItemsResult);
            this.panel1.Controls.Add(this.lblStatusResult);
            this.panel1.Controls.Add(this.txtStatusResult);
            this.panel1.Controls.Add(this.lblPaymentStatus);
            this.panel1.Controls.Add(this.txtPaymentStatus);
            this.panel1.Controls.Add(this.lblShipmentStatus);
            this.panel1.Controls.Add(this.txtShipmentStatus);
            this.panel1.Controls.Add(this.lblShippingAddress);
            this.panel1.Controls.Add(this.txtShippingAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 492);
            this.panel1.TabIndex = 16;
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(240, 457);
            this.txtShippingAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.ReadOnly = true;
            this.txtShippingAddress.Size = new System.Drawing.Size(332, 22);
            this.txtShippingAddress.TabIndex = 14;
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.Location = new System.Drawing.Point(67, 457);
            this.lblShippingAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(173, 21);
            this.lblShippingAddress.TabIndex = 13;
            this.lblShippingAddress.Text = "Shipping Address:";
            // 
            // ViewOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ViewOrdersForm";
            this.Text = "View Order Status";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblOrderIdResult;
        private System.Windows.Forms.TextBox txtOrderIdResult;
        private System.Windows.Forms.Label lblItemsResult;
        private System.Windows.Forms.TextBox txtItemsResult;
        private System.Windows.Forms.Label lblStatusResult;
        private System.Windows.Forms.TextBox txtStatusResult;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.TextBox txtPaymentStatus;
        private System.Windows.Forms.Label lblShipmentStatus;
        private System.Windows.Forms.TextBox txtShipmentStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.TextBox txtShippingAddress;
    }
} 