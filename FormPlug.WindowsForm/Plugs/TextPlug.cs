using System;
using System.Drawing;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class TextPlug : TextPlugBase<TextBox>
    {
        protected override int MaxLenght
        {
            set { Control.MaxLength = value; }
        }

        protected override bool Multiline
        {
            set { Control.Multiline = value; }
        }

        protected override int Width
        {
            set { Control.Size = new Size(value, Control.Size.Height); }
        }

        protected override int Height
        {
            set { Control.Size = new Size(Control.Size.Width, value); }
        }

        protected override bool Password
        {
            set { Control.UseSystemPasswordChar = value; }
        }

        public override string Value
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        protected override bool ReadOnly
        {
            set { Control.Enabled = !value; }
        }

        public override event EventHandler ValueChanged
        {
            add { Control.TextChanged += value; }
            remove { Control.TextChanged -= value; }
        }

        public TextPlug()
        {
        }

        public TextPlug(TextBox control)
            : base(control)
        {
        }

        protected override void InitializeControl()
        {
        }
    }
}