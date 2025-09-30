namespace WinFormsApp4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.DarkMagenta;
            label1.Location = new Point(41, 81);
            label1.Name = "label1";
            label1.Size = new Size(53, 37);
            label1.TabIndex = 0;
            label1.Text = "X =";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.DarkMagenta;
            label2.Location = new Point(36, 151);
            label2.Name = "label2";
            label2.Size = new Size(58, 37);
            label2.TabIndex = 1;
            label2.Text = "M =";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(109, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(211, 23);
            textBox2.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LavenderBlush;
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.ForeColor = Color.Indigo;
            groupBox1.Location = new Point(351, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(163, 201);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "F(x)";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radioButton3.ForeColor = Color.DarkMagenta;
            radioButton3.Location = new Point(10, 154);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(69, 41);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "e^x";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radioButton2.ForeColor = Color.DarkMagenta;
            radioButton2.Location = new Point(10, 108);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(73, 41);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "x^2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radioButton1.ForeColor = Color.DarkMagenta;
            radioButton1.Location = new Point(10, 61);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(84, 41);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "sh(x)";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(36, 226);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ScrollBars = ScrollBars.Both;
            textBox4.Size = new Size(478, 230);
            textBox4.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.Plum;
            button1.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.Indigo;
            button1.Location = new Point(36, 486);
            button1.Name = "button1";
            button1.Size = new Size(153, 43);
            button1.TabIndex = 9;
            button1.Text = "Пуск";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkMagenta;
            button2.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.GhostWhite;
            button2.Location = new Point(361, 487);
            button2.Name = "button2";
            button2.Size = new Size(153, 42);
            button2.TabIndex = 10;
            button2.Text = "Очистить";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(551, 563);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(groupBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Лаб. раб. №1 зад. 3 Ст. гр. 251 Потапкина М. А.";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
    }
}
