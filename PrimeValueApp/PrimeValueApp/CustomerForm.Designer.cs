namespace PrimeValueApp
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnProceedPayment;
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
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.btnProceedPayment = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Customer Portal";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.Location = new System.Drawing.Point(200, 80);
            this.btnPlaceOrder.Size = new System.Drawing.Size(200, 40);
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlaceOrder.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlaceOrder.FlatAppearance.BorderSize = 0;
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.Text = "View Orders";
            this.btnViewOrders.Location = new System.Drawing.Point(200, 140);
            this.btnViewOrders.Size = new System.Drawing.Size(200, 40);
            this.btnViewOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnViewOrders.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnViewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrders.FlatAppearance.BorderSize = 0;
            // 
            // btnProceedPayment
            // 
            this.btnProceedPayment.Text = "Proceed Payment";
            this.btnProceedPayment.Location = new System.Drawing.Point(200, 200);
            this.btnProceedPayment.Size = new System.Drawing.Size(200, 40);
            this.btnProceedPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnProceedPayment.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnProceedPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedPayment.FlatAppearance.BorderSize = 0;
            // 
            // btnBack
            // 
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(200, 260);
            this.btnBack.Size = new System.Drawing.Size(200, 40);
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBack.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnViewOrders);
            this.Controls.Add(this.btnProceedPayment);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CustomerForm";
            this.Text = "Customer Portal";
            this.ResumeLayout(false);
        }
        #endregion
    }
} 