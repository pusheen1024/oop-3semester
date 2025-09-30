using System.Configuration;
using System.Drawing.Printing;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double x = 1.825 * 1e2;
            double y = 18.225;
            double z = -3.298 * 1e-2;
            textBox1.Text = x.ToString();
            textBox2.Text = y.ToString();
            textBox3.Text = z.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            double x, y, z;
            try
            {
                x = double.Parse(textBox1.Text);
                textBox4.Text += Environment.NewLine + "X = " + x.ToString();
            }
            catch (FormatException)
            {
                textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿¿¿¿ ¿¿¿¿¿¿¿¿ X!";
                return;
            }
            try
            {
                y = double.Parse(textBox2.Text);
                textBox4.Text += Environment.NewLine + "Y = " + y.ToString();
            }
            catch (FormatException)
            {
                textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿¿¿¿ ¿¿¿¿¿¿¿¿ Y!";
                return;
            }
            try
            {
                z = double.Parse(textBox3.Text);
                textBox4.Text += Environment.NewLine + "Z = " + z.ToString();
            }
            catch (FormatException)
            {
                textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿¿¿¿ ¿¿¿¿¿¿¿¿ Z!";
                return;
            }
            double a = Math.Abs(Math.Pow(x, y / x) - Math.Pow(y / x, 1.0 / 3));
            double b = (Math.Cos(y) - z / (y - x)) / (1 + (y - x) * (y - x));
            double phi = a + (y - x) * b;

            if (double.IsInfinity(phi) || double.IsNaN(phi))
                textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿ ¿¿ ¿¿¿¿¿¿¿¿¿¿!";
            else textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿ = " + phi.ToString();
        }
    }
}
