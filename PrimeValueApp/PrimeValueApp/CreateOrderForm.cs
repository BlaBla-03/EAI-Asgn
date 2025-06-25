using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using PrimeValueApp.PrimeValueService;

namespace PrimeValueApp
{
    public partial class CreateOrderForm : Form
    {
        private readonly PrimeValueServiceSoapClient _webService;
        private readonly List<Product> _availableProducts;
        private readonly BindingList<OrderItem> _shoppingCart = new BindingList<OrderItem>();

        public CreateOrderForm()
        {
            InitializeComponent();
            // Apply theme directly
            this.Size = new System.Drawing.Size(600, 400);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a New Order";
            var lblTitle = new System.Windows.Forms.Label
            {
                Text = "Create a New Order",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Navy,
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 60
            };
            this.Controls.Add(lblTitle);
            lblTitle.BringToFront();
            _webService = new PrimeValueServiceSoapClient();
            
            // Load products and populate dropdown
            _availableProducts = LoadProducts();
            if (_availableProducts != null)
            {
                cboProducts.DataSource = _availableProducts;
                cboProducts.DisplayMember = "DisplayText";
                cboProducts.ValueMember = "ProductId";
            }

            // Set up the shopping cart grid
            RefreshCartView();
            // Wire up button events
            btnAddItem.Click += btnAddItem_Click;
            btnCreateOrder.Click += btnCreateOrder_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        private void RefreshCartView()
        {
            var cartView = _shoppingCart.Select(item => new CartItemView
            {
                ProductId = item.ProductId,
                ProductName = _availableProducts.FirstOrDefault(p => p.ProductId == item.ProductId)?.Name ?? "",
                Quantity = item.Quantity,
                Price = _availableProducts.FirstOrDefault(p => p.ProductId == item.ProductId)?.Price ?? 0
            }).ToList();
            dgvShoppingCart.DataSource = null;
            dgvShoppingCart.DataSource = cartView;
            // Set column widths if columns exist
            if (dgvShoppingCart.Columns["ProductName"] != null)
            {
                dgvShoppingCart.Columns["ProductId"].Width = 80;
                dgvShoppingCart.Columns["ProductName"].Width = 160;
                dgvShoppingCart.Columns["Quantity"].Width = 80;
                dgvShoppingCart.Columns["Price"].Width = 80;
            }
        }

        private List<Product> LoadProducts()
        {
            try
            {
                string productsJson = _webService.GetProducts();
                var serializer = new JavaScriptSerializer();
                // Deserialize to dynamic first
                var productsDynamic = serializer.Deserialize<List<dynamic>>(productsJson);
                // Map to local Product class
                var products = productsDynamic.Select(p => new Product
                {
                    ProductId = Convert.ToInt32(p["ProductId"]),
                    Name = p["Name"].ToString(),
                    Price = Convert.ToDouble(p["Price"])
                }).ToList();
                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cboProducts.SelectedItem == null) return;

            var selectedProduct = (Product)cboProducts.SelectedItem;
            int quantity = (int)numQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Please enter a quantity greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if item is already in the cart
            var existingItem = _shoppingCart.FirstOrDefault(item => item.ProductId == selectedProduct.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _shoppingCart.Add(new OrderItem { ProductId = selectedProduct.ProductId, Quantity = quantity });
            }
            
            // Refresh the grid to show changes
            RefreshCartView();
            UpdateTotals();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (_shoppingCart.Count == 0)
            {
                MessageBox.Show("Cannot create an empty order. Please add items to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // The local OrderItem objects must be converted to the web service's OrderItemRequest type.
                var serviceItems = _shoppingCart.Select(i => new PrimeValueService.OrderItemRequest
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToArray();

                string result = _webService.CreateOrder(serviceItems);
                var serializer = new JavaScriptSerializer();
                dynamic response = serializer.DeserializeObject(result);

                if (response.ContainsKey("orderId"))
                {
                    string orderId = response["orderId"];
                    MessageBox.Show($"Order created successfully!\nOrder ID: {orderId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click(null, null); // Clear the form
                }
                else
                {
                    string errorMsg = response.ContainsKey("error") ? response["error"].ToString() : "Unknown error";
                    MessageBox.Show($"Failed to create order.\n{errorMsg}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void UpdateTotals()
        {
            double total = 0;
            foreach (var item in _shoppingCart)
            {
                var product = _availableProducts.First(p => p.ProductId == item.ProductId);
                total += product.Price * item.Quantity;
            }
            lblTotal.Text = $"Total: {string.Format("RM {0:N2}", total)}"; // Format as currency
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _shoppingCart.Clear();
            numQuantity.Value = 1;
            RefreshCartView();
            UpdateTotals();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // These classes are defined here to match the data structures used by the web service.
    // In a larger application, these might be in a separate "Models" file.
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string DisplayText => $"{ProductId} - {Name}";
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    // New class for DataGridView display
    public class CartItemView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
} 