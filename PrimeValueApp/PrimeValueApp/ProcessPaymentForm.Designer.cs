namespace PrimeValueApp
{
    partial class ProcessPaymentForm
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblOrderTotal = new System.Windows.Forms.Label();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.btnCheckPaymentStatus = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Process Payment";
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
            this.cboOrders.Location = new System.Drawing.Point(50, 70);
            this.cboOrders.Size = new System.Drawing.Size(250, 25);
            // 
            // lblAmount
            // 
            this.lblAmount.Text = "Amount:";
            this.lblAmount.Location = new System.Drawing.Point(50, 110);
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(180, 110);
            this.txtAmount.Size = new System.Drawing.Size(250, 23);
            // 
            // lblOrderTotal
            // 
            this.lblOrderTotal.Text = "Order Total: RM 0.00";
            this.lblOrderTotal.Location = new System.Drawing.Point(50, 150);
            this.lblOrderTotal.Size = new System.Drawing.Size(200, 23);
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Text = "Process Payment";
            this.btnProcessPayment.Location = new System.Drawing.Point(50, 190);
            this.btnProcessPayment.Size = new System.Drawing.Size(150, 30);
            // 
            // btnCheckPaymentStatus
            // 
            this.btnCheckPaymentStatus.Text = "Check Payment Status";
            this.btnCheckPaymentStatus.Location = new System.Drawing.Point(220, 190);
            this.btnCheckPaymentStatus.Size = new System.Drawing.Size(180, 30);
            // 
            // btnClear
            // 
            this.btnClear.Text = "Clear";
            this.btnClear.Location = new System.Drawing.Point(420, 190);
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            // 
            // btnBack
            // 
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(510, 190);
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            // 
            // lblResult
            // 
            this.lblResult.Text = "Result:";
            this.lblResult.Location = new System.Drawing.Point(50, 240);
            this.lblResult.Size = new System.Drawing.Size(100, 23);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(50, 270);
            this.txtResult.Size = new System.Drawing.Size(500, 80);
            this.txtResult.Multiline = true;
            this.txtResult.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.cboOrders);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.lblOrderTotal);
            this.panel1.Controls.Add(this.btnProcessPayment);
            this.panel1.Controls.Add(this.btnCheckPaymentStatus);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 400);
            this.panel1.TabIndex = 16;
            // 
            // ProcessPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProcessPaymentForm";
            this.Text = "Process Payment";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboOrders;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblOrderTotal;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnCheckPaymentStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Panel panel1;
    }
} 