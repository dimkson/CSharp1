using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson7
{
    class fGuess : Form
    {
        Button bCheck;
        TextBox tbGuess;
        Label lblText;
        public static int Number { get; private set; }

        public fGuess()
        {
            InitializeComponent();
        }

        void InitializeComponent()
        {
            tbGuess = new TextBox();
            lblText = new Label();
            bCheck = new Button();
            //
            // tbGuess
            //
            tbGuess.Name = "tbGuess";
            tbGuess.Location = new Point(100, 10);
            //
            // lblText
            //
            lblText.Text = "Введите число: ";
            lblText.Location = new Point(10, 10);
            //
            // bCheck
            //
            bCheck.Text = "Проверить";
            bCheck.Location = new Point(70, 40);
            bCheck.Click += BCheck_Click;
            //
            // fGuess
            //
            this.Text = "Угадай число!";
            this.ClientSize = new Size(215, 80);
            this.Controls.AddRange(new Control[] { tbGuess, lblText, bCheck });
        }

        private void BCheck_Click(object sender, EventArgs e)
        {
            Number = int.Parse(tbGuess.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
