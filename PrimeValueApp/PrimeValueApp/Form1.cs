using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeValueApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeRoleButtons();
        }

        private void InitializeRoleButtons()
        {
            btnCustomer.Click += (s, e) => { new CustomerForm().ShowDialog(); };
            btnWarehouseStaff.Click += (s, e) => { new WarehouseStaffForm().ShowDialog(); };
            btnCourier.Click += (s, e) => { new CourierForm().ShowDialog(); };
            btnPaymentGateway.Click += (s, e) => { new PaymentGatewayForm().ShowDialog(); };
        }
    }
}
