using System;
using System.IO;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    public partial class ImageDialogButton : UserControl
    {
        public string Image
        {
            get { return _image; }
            set
            {
                if (value == _image)
                    return;

                if (value != "" && !File.Exists(value))
                    MessageBox.Show(value + " doesn't exists !", "Image not found !");

                _image = value;
                _dialog.FileName = value;

                pictureBox.ImageLocation = _image;

                if (ImageChanged != null)
                    ImageChanged(this, EventArgs.Empty);
            }
        }

        public string Filter { set { _dialog.Filter = value; } }
        public string InitialDirectory { set { _dialog.InitialDirectory = value; } }

        private readonly OpenFileDialog _dialog;
        private string _image;

        public ImageDialogButton()
        {
            InitializeComponent();

            _dialog = new OpenFileDialog();
        }

        public event EventHandler ImageChanged;

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() != DialogResult.OK)
                return;

            Image = _dialog.FileName;
        }
    }
}