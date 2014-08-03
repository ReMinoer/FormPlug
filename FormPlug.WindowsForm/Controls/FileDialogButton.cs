using System;
using System.IO;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    // TODO : Check if path is correct
    public partial class FileDialogButton : UserControl
    {
        public string File
        {
            get { return _file; }
            set
            {
                if (value == _file)
                    return;

                if (value != "" && !System.IO.File.Exists(value))
                {
                    MessageBox.Show(value + " doesn't exists !", "File not found !");
                    textBox.Text = _file;
                    return;
                }

                _file = value;
                _dialog.FileName = value;

                textBox.Text = _file;

                if (FileChanged != null)
                    FileChanged(this, EventArgs.Empty);
            }
        }
        public string Filter { set { _dialog.Filter = value; } }
        public string InitialDirectory { set { _dialog.InitialDirectory = value; } }
        private readonly OpenFileDialog _dialog = new OpenFileDialog();
        private string _file;

        public FileDialogButton()
        {
            InitializeComponent();
        }

        public event EventHandler FileChanged;

        private void button_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() != DialogResult.OK)
                return;

            File = _dialog.FileName;
        }

        private void textBox_Validated(object sender, EventArgs e)
        {
            File = textBox.Text;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                File = textBox.Text;
        }
    }
}