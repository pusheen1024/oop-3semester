using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x, m;
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
                m = double.Parse(textBox2.Text);
                textBox4.Text += Environment.NewLine + "M = " + m.ToString();
            }
            catch (FormatException)
            {
                textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿¿¿¿ ¿¿¿¿¿¿¿¿ M!";
                return;
            }

            int choice = -1;
            if (radioButton1.Checked) choice = 0;
            else if (radioButton2.Checked) choice = 1;
            else if (radioButton3.Checked) choice = 2;

            double j = 0;
            switch (choice)
            {
                case 0:
                    if (m > -1 && m < x) j = Math.Sin(5 * Math.Sinh(x) + 3 * m * Math.Abs(Math.Sinh(x)));
                    else if (x > m) j = Math.Cos(3 * Math.Sinh(x) + 5 * m * Math.Abs(Math.Sinh(x)));
                    else if (x == m) j = Math.Pow(Math.Sinh(x) + m, 2);
                    else
                    {
                        textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿ ¿¿ ¿¿¿¿¿¿¿¿¿¿!";
                        return;
                    }
                    break;
                case 1:
                    if (m > -1 && m < x) j = Math.Sin(5 * x * x + 3 * m * Math.Abs(x * x));
                    else if (x > m) j = Math.Cos(3 * x * x + 5 * m * Math.Abs(x * x));
                    else if (x == m) j = Math.Pow(x * x + m, 2);
                    else
                    {
                        textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿ ¿¿ ¿¿¿¿¿¿¿¿¿¿!";
                        return;
                    }
                    break;
                case 2:
                    if (m > -1 && m < x) j = Math.Sin(5 * Math.Exp(x) + 3 * m * Math.Abs(Math.Exp(x)));
                    else if (x > m) j = Math.Cos(3 * Math.Exp(x) + 5 * m * Math.Abs(Math.Exp(x)));
                    else if (x == m) j = Math.Pow(Math.Exp(x) + m, 2);
                    else
                    {
                        textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿ ¿¿ ¿¿¿¿¿¿¿¿¿¿!";
                        return;
                    }
                    break;
                default:
                    textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿¿¿¿ ¿¿¿¿¿!";
                    return;
            }
            textBox4.Text += Environment.NewLine + "¿¿¿¿¿¿¿¿¿ = " + j.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
    }
}
