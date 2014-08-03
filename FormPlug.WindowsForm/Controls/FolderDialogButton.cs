using System;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    // TODO : Implements folder and file creation
    public partial class FolderDialogButton : UserControl
    {
        public string Folder
        {
            get { return _folder; }
            set
            {
                if (value == _folder)
                    return;

                if (value != "" && !System.IO.Directory.Exists(value))
                {
                    MessageBox.Show(value + " doesn't exists !", "Folder not found !");
                    textBox.Text = _folder;
                    return;
                }

                _folder = value;
                _dialog.SelectedPath = value;

                textBox.Text = _folder;

                if (FolderChanged != null)
                    FolderChanged(this, EventArgs.Empty);
            }
        }
        private readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private string _folder;

        public FolderDialogButton()
        {
            InitializeComponent();
        }

        public event EventHandler FolderChanged;

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