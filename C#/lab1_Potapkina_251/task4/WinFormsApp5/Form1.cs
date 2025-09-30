namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            double x_0, x_k, dx, b;
            try
            {
                x_0 = double.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                textBox5.Text += Environment.NewLine + "真真真真真真 真真真真 X_0!";
                return;
            }
            try
            {
                x_k = double.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                textBox5.Text += Environment.NewLine + "真真真真真真 真真真真 X_k!";
                return;
            }
            try
            {
                dx = double.Parse(textBox3.Text);
            }
            catch (FormatException)
            {
                textBox5.Text += Environment.NewLine + "真真真真真真 真真真真 Dx!";
                return;
            }
            try
            {
                b = double.Parse(textBox4.Text);
            }
            catch (FormatException)
            {
                textBox5.Text += Environment.NewLine + "真真真真真真 真真真真 B!";
                return;
            }
            double x = x_0;
            while (x <= x_k)
            {
                double y = 0.0025 * b * Math.Pow(x, 3) + Math.Sqrt(x + Math.Exp(0.82));
                textBox5.Text += Environment.NewLine + "X = " + x.ToString() + ", Y = " + y.ToString();
                x += dx;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double x_0 = -1;
            double x_k = 4;
            double dx = 0.5;
            double b = 2.3;
            textBox1.Text = x_0.ToString();
            textBox2.Text = x_k.ToString();
            textBox3.Text = dx.ToString();
            textBox4.Text = b.ToString();
        }
    }
}
