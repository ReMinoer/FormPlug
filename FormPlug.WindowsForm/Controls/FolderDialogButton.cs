using System;
using System.IO;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    public partial class FolderDialogButton : UserControl
    {
        private readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private string _folder;

        public string Folder
        {
            get { return _folder; }
            set
            {
                if (value == _folder)
                    return;

                if (value != "" && !Directory.Exists(value))
                {
                    MessageBox.Show(value + " doesn't exists !", "Folder not found !");
                    textBox.Text = _folder;
                    return;
                }

                _folder = value;
                _dialog.SelectedPath = value;

                textBox.Text = _folder;
                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;

                if (FolderChanged != null)
                    FolderChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler FolderChanged;

        public FolderDialogButton()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() != DialogResult.OK)
                return;

            Folder = _dialog.SelectedPath;
        }

        private void textBox_Validated(object sender, EventArgs e)
        {
            Folder = textBox.Text;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Folder = textBox.Text;
        }
    }
}