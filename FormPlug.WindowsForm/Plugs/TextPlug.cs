using System;
using System.Drawing;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class TextPlug : TextPlugBase<TextBox>
    {
        protected override bool Multiline { set { Control.Multiline = value; } }
        protected override int Width { set { Control.Size = new Size(value, Control.Size.Height); } }
        protected override int Height { set { Control.Size = new Size(Control.Size.Width, value); } }

        public override string Value { get { return Control.Text; } set { Control.Text = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.TextChanged += value; }
            remove { Control.TextChanged -= value; }
        }

        protected override void InitializeConnection()
        {
            Multiline = false;
            Width = 100;
            Height = 150;
        }
    }
}