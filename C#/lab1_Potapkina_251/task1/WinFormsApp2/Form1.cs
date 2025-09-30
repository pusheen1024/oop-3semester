namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button3.BackColor = SystemColors.Control;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button4.BackColor = SystemColors.Control;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            button5.BackColor = SystemColors.Control;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = SystemColors.Control;
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.BackColor = Color.LavenderBlush;
            button2.Enabled = true;
            button2.BackColor = Color.Thistle;
            button3.Enabled = true;
            button3.BackColor = Color.Plum;
            button4.Enabled = true;
            button4.BackColor = Color.MediumPurple;
            button5.Enabled = true;
            button5.BackColor = Color.SlateBlue;
        }
    }
}
