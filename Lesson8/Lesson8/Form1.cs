using System;
using System.IO;
using System.Windows.Forms;

namespace Lesson8
{
    public partial class fBelieve : Form
    {
        TrueFalse database;
        BindingSource binding;
        Game game;
        bool changeBase;
        bool newFile;
        bool fileOpen;

        public fBelieve()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            //Запрос на сохранение изменений перед выходом
            if (changeBase)
            { 
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) tsmiSave.PerformClick();
                else if (result == DialogResult.Cancel) return;
            }
            this.Close();
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            //Создание новый базы данных
            if (changeBase)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) tsmiSave.PerformClick();
                else if (result == DialogResult.Cancel) return;
            }
            database = new TrueFalse(string.Empty);
            Binding();
            tbText.Text = string.Empty;
            cbTrueFalse.Checked = false;
            tabPage1.Text = "Новая БД*";
            newFile = true;
            changeBase = true;
            fileOpen = true;
        }

        private void Binding()
        {
            //Создание связи между элементами формы
            binding = new BindingSource(database, "List");
            bindingNavigator.BindingSource = binding;
            dataGridView.DataSource = binding;
            tbText.Enabled = cbTrueFalse.Enabled = true;
            tbText.DataBindings.Clear();
            tbText.DataBindings.Add("Text", binding, "Text");
            cbTrueFalse.DataBindings.Clear();
            cbTrueFalse.DataBindings.Add("Checked", binding, "TrueFalse", false, DataSourceUpdateMode.OnPropertyChanged);
            tbGame.DataBindings.Clear();
            tbGame.DataBindings.Add("Text", binding, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            cbAnswer.DataBindings.Clear();
            cbAnswer.DataBindings.Add("Checked", binding, "TrueFalse", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            //Открытие существующего файла БД
            if (changeBase)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) tsmiSave.PerformClick();
                else if (result == DialogResult.Cancel) return;
            }
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(openFile.FileName);
                database.Load();
                Binding();
                tabPage1.Text = Path.GetFileName(openFile.FileName);
                newFile = false;
                changeBase = false;
                fileOpen = true;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            //Сохранение текущего файла БД, если файл новый, то запускается метод SaveAs
            if (!fileOpen) return;
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
            //Сохранить КАК
            if (!fileOpen) return;
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
            //Добавление "*" к имени файла при изменении БД
            if (!changeBase)
            {
                tabPage1.Text += "*";
                changeBase = true;
            }
        }

        private void bBelieve_Click(object sender, EventArgs e)
        {
            //Верю
            Check(true);
        }
        private void bNotBelieve_Click(object sender, EventArgs e)
        {
            //Не верю
            Check(false);
        }
        private void Check(bool check)
        {
            //Проверка ответа
            if (check == cbAnswer.Checked)
            {
                game.Increase();
            }
            else
            {
                game.Step();
            }
            label1.Text = "Очки: " + game.Count.ToString();
            bindingNavigatorMoveNextItem.PerformClick();
            if (game.Finish)
            {
                tbGame.Enabled = bBelieve.Enabled = bNotBelieve.Enabled = false;
                MessageBox.Show($"Очков набрано: {game.Count} ", "Игра закончена!");
            }
        }

        private void tsmiNewGame_Click(object sender, EventArgs e)
        {
            //Начать новую игру
            if (!fileOpen)
            {
                MessageBox.Show("Необходимо открыть файл с вопросами!","Внимание");
                return;
            }
            if (database.List.Count == 0)
            {
                MessageBox.Show("База данных должна содеражать хотя бы один вопрос!","Внимание");
                return;
            }
            game = new Game(database.List.Count);
            label1.Text = "Очки: " + game.Count.ToString();
            tbGame.Enabled = bBelieve.Enabled = bNotBelieve.Enabled = true;
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Удалить строку?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            //Запуск формы "О программе"
            fAbout fAbout = new fAbout();
            fAbout.ShowDialog();
        }

        private void fBelieve_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Сохранить путь открытого файла
            Properties.Settings.Default.LastPath = database?.FileName;
            Properties.Settings.Default.Save();
        }

        private void fBelieve_Load(object sender, EventArgs e)
        {
            //Загрузить последний открытый файл
            if (Properties.Settings.Default.LastPath != string.Empty)
            {
                database = new TrueFalse(Properties.Settings.Default.LastPath);
                database.Load();
                Binding();
                tabPage1.Text = Path.GetFileName(Properties.Settings.Default.LastPath);
                newFile = false;
                changeBase = false;
                fileOpen = true;
            }
        }
    }
}
