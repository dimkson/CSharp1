using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class fBelieve : Form
    {
        TrueFalse database;
        BindingSource binding;
        bool changeBase;
        bool newFile;

        public fBelieve()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            database = new TrueFalse(string.Empty);
            binding = new BindingSource(database, "List");
            bindingNavigator.BindingSource = binding;
            dataGridView.DataSource = binding;
            tabPage1.Text = "Новый файл*";
            newFile = true;
            changeBase = true;
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFile.FileName);
                database.Load();
                binding = new BindingSource(database, "List");
                bindingNavigator.BindingSource = binding;
                dataGridView.DataSource = binding;
                tabPage1.Text = Path.GetFileName(openFile.FileName);
                newFile = false;
                changeBase = false;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (newFile)
            {
                tsmiSaveAs.PerformClick();
                return;
            }
            database.Save();
            changeBase = false;
            tabPage1.Text = Path.GetFileName(database.FileName);
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                database.FileName = saveFile.FileName;
                database.Save();
                tabPage1.Text = Path.GetFileName(saveFile.FileName);
                newFile = false;
                changeBase = false;
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!changeBase)
            {
                tabPage1.Text += "*";
                changeBase = true;
            }
        }
    }
}
