using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormPlug.WindowsForm.Controls
{
    // TODO : Dynamic size for ColorDialogButton
    public partial class ColorDialogButton : UserControl
    {
        public Color Color
        {
            get { return _color; }
            set
            {
                if (value == _color)
                    return;

                _color = value;
                _dialog.Color = value;

                button.BackColor = _color;
                button.Text = string.Format("{0}, {1}, {2}", _color.R, _color.G, _color.B);
                button.ForeColor = _color.GetBrightness() < 0.5f ? Color.White : Color.Black;

                if (ColorChanged != null)
                    ColorChanged(this, EventArgs.Empty);
            }
        }
        private readonly ColorDialog _dialog = new ColorDialog();
        private Color _color;

        public ColorDialogButton()
        {
            InitializeComponent();
        }

        public event EventHandler ColorChanged;

        private void button_Click(object sender, EventArgs e)
        {
            if (_dialog.ShowDialog() != DialogResult.OK)
                return;

            Color = _dialog.Color;
        }
    }
}