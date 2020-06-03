using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson7
{
    class fBase: Form
    {
        Button bGuess;
        Label lblText, lblCount;
        GuessNumber guessNumber;
        fGuess guess;

        public fBase()
        {
            InitializeComponent();
            New();
            guess = new fGuess();
        }
        void InitializeComponent()
        {
            bGuess = new Button();
            lblText = new Label();
            lblCount = new Label();
            //
            // bGuess
            //
            bGuess.Text = "Попытаться";
            bGuess.Location = new Point(70, 55);
            bGuess.AutoSize = true;
            bGuess.Click += BGuess_Click;
            //
            // lblText
            //
            lblText.Text = "Попробуй угадать число от 1 до 100";
            lblText.AutoSize = true;
            lblText.Location = new Point(10, 10);
            //
            // lblCount
            //
            lblCount.Text = "Попытка: 0";
            lblCount.AutoSize = true;
            lblCount.Location = new Point(10, 30);
            //
            // fBase
            //
            this.Text = "Угадай число";
            this.ClientSize = new Size(215, 100);
            this.Controls.AddRange(new Control[] { bGuess, lblText, lblCount });
        }

        private void BGuess_Click(object sender, EventArgs e)
        {
            if (guess.ShowDialog() == DialogResult.OK)
            {
                if (guessNumber.Guess(fGuess.Number))
                {
                    MessageBox.Show("Вы угадали!");
                    New();
                }
                else
                {
                    if (guessNumber.LessMore(fGuess.Number))
                        MessageBox.Show("Перебор");
                    else
                        MessageBox.Show("Недобор");
                }
                lblCount.Text = $"Попытка {guessNumber.Count} из мин. попыток: {guessNumber.MaxCount}";
            }
        }
        private void New()
        {
            guessNumber = new GuessNumber();
            lblCount.Text = $"Попытка {guessNumber.Count} из мин. попыток: {guessNumber.MaxCount}";
        }
    }
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fBase());
        }
    }
}
