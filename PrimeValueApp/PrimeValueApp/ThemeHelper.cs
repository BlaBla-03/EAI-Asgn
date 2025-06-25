using System.Windows.Forms;
using System.Drawing;

namespace PrimeValueApp
{
    public static class ThemeHelper
    {
        public static void ApplyTheme(Form form, string title)
        {
            form.Size = new Size(600, 400);
            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10F);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = title;

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.Navy,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };
            form.Controls.Add(lblTitle);
            lblTitle.BringToFront();
        }
        public static void StyleButton(Button btn)
        {
            btn.Height = 40;
            btn.Width = 200;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn.BackColor = Color.LightSteelBlue;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }
    }
} 