using System;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class fAbout : Form
    {
        public fAbout()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
