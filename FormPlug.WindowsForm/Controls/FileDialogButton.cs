using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    public partial class FileDialogButton : UserControl
    {
        private FileDialog _dialog;
        private string _file;
        private bool _saveMode;

        public string File
        {
            get { return _file; }
            set
            {
                if (value == _file)
                    return;

                if (!CheckFilename(value))
                    return;

                _file = value;
                _dialog.FileName = value;

                textBox.Text = _file;
                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;

                if (FileChanged != null)
                    FileChanged(this, EventArgs.Empty);
            }
        }

        public string Filter
        {
            set { _dialog.Filter = value; }
        }

        public string InitialDirectory
        {
            set { _dialog.InitialDirectory = value; }
        }

        public bool SaveMode
        {
            private get { return _saveMode; }
            set
            {
                if (_saveMode == value && _dialog != null)
                    return;

                if (value)
                {
                    _dialog = new SaveFileDialog();
                    (_dialog as SaveFileDialog).OverwritePrompt = false;
                }
                else
                    _dialog = new OpenFileDialog();

                _saveMode = value;
            }
        }

        public event EventHandler FileChanged;

        public FileDialogButton()
        {
            InitializeComponent();

            _dialog = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*"
            };
        }

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

        private bool CheckFilename(string value)
        {
            if (value == "")
                return true;

            if (SaveMode)
            {
                string directory = Path.GetDirectoryName(value);
                if (directory == null || !Directory.Exists(directory))
                {
                    MessageBox.Show(directory + " doesn't exists !", "Folder not found !");
                    textBox.Text = _file;
                    return false;
                }

                if (System.IO.File.Exists(value))
                    if (MessageBox.Show(Path.GetFileName(value) + " already exists. Are you sure to replace it ?",
                        "File already exists !", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        textBox.Text = _file;
                        return false;
                    }
            }
            else if (!System.IO.File.Exists(value))
            {
                MessageBox.Show(Path.GetFileName(value) + " doesn't exists !", "File not found !");
                textBox.Text = _file;
                return false;
            }

            bool isValidExtension = false;
            var extensions = new List<string>();

            string[] dialogFilters = _dialog.Filter.Split('|');
            for (int i = 1; i < dialogFilters.Length; i += 2)
                extensions.Add(dialogFilters[i].Replace("*", ""));

            foreach (string e in extensions)
            {
                if (e != "." && !value.EndsWith(e, StringComparison.Ordinal))
                    continue;

                isValidExtension = true;
                break;
            }

            if (!isValidExtension)
            {
                var message = new StringBuilder();
                message.AppendLine(value + " doesn't have a correct extension !");
                message.AppendLine("Correct extensions are :");
                foreach (string f in extensions)
                    message.AppendLine(f);
                MessageBox.Show(message.ToString(), "Extension unvalid !");

                textBox.Text = _file;
                return false;
            }

            return true;
        }
    }
}