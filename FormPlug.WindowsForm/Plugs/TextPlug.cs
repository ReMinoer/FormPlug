using System;
using System.Windows.Forms;
using FormPlug.PlugBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class TextPlug : TextPlugBase<TextBox>
    {
        public override string Value { get { return Control.Text; } set { Control.Text = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.TextChanged += value; }
            remove { Control.TextChanged -= value; }
        }
    }
}