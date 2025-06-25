namespace PrimeValueApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnWarehouseStaff;
        private System.Windows.Forms.Button btnCourier;
        private System.Windows.Forms.Button btnPaymentGateway;

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
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnWarehouseStaff = new System.Windows.Forms.Button();
            this.btnCourier = new System.Windows.Forms.Button();
            this.btnPaymentGateway = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Prime Value EAI System";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.Location = new System.Drawing.Point(200, 100);
            this.btnCustomer.Size = new System.Drawing.Size(200, 40);
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCustomer.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            // 
            // btnWarehouseStaff
            // 
            this.btnWarehouseStaff.Text = "Warehouse Staff";
            this.btnWarehouseStaff.Location = new System.Drawing.Point(200, 160);
            this.btnWarehouseStaff.Size = new System.Drawing.Size(200, 40);
            this.btnWarehouseStaff.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnWarehouseStaff.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnWarehouseStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouseStaff.FlatAppearance.BorderSize = 0;
            // 
            // btnCourier
            // 
            this.btnCourier.Text = "Courier";
            this.btnCourier.Location = new System.Drawing.Point(200, 220);
            this.btnCourier.Size = new System.Drawing.Size(200, 40);
            this.btnCourier.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCourier.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCourier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCourier.FlatAppearance.BorderSize = 0;
            // 
            // btnPaymentGateway
            // 
            this.btnPaymentGateway.Text = "Payment Gateway";
            this.btnPaymentGateway.Location = new System.Drawing.Point(200, 280);
            this.btnPaymentGateway.Size = new System.Drawing.Size(200, 40);
            this.btnPaymentGateway.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPaymentGateway.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPaymentGateway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentGateway.FlatAppearance.BorderSize = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnWarehouseStaff);
            this.Controls.Add(this.btnCourier);
            this.Controls.Add(this.btnPaymentGateway);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Prime Value EAI System";
            this.ResumeLayout(false);
        }

        #endregion
    }
}

