using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lesson7
{
    class fDouble: Form
    {
        private Button bPlus, bMulti, bReset;
        private Label lblCurrent;
        private TextBox tbMax;

        public fDouble()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.bPlus = new Button();
            this.bMulti = new Button();
            this.bReset = new Button();
            this.lblCurrent = new Label();
            this.tbMax = new TextBox();

            this.SuspendLayout();
            //
            // bPlus
            //
            this.bPlus.Name = "bPlus";
            this.bPlus.Text = "+1";
            this.bPlus.Location = new Point(10, 20);
            //
            // bMulti
            //
            this.bMulti.Name = "bMulti";
            this.bMulti.Text = "x2";
            this.bMulti.Location = new Point(10, 60);
            //
            // bReset
            //
            this.bReset.Name = "bReset";
            this.bReset.Text = "Сброс";
            this.bReset.Location = new Point(10, 100);
            //
            // lblCurrent
            //
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Text = "1";
            this.lblCurrent.Location = new Point(120, 23);
            //
            // tbMax
            //
            this.tbMax.Name = "tbMax";
            this.tbMax.Text = "";
            this.tbMax.Location = new Point(120, 60);
            // 
            // fDouble
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.AddRange(new Control[] { bPlus, bMulti, bReset, lblCurrent, tbMax });
            this.Text = "Удвоитель";
            this.Name = "fDouble";
            this.ResumeLayout(false);

        }
    }

    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fDouble());
        }
    }
}
