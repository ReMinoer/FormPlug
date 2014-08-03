using System;
using System.Drawing;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    public class ColorPlug : ColorPlugBase<ColorDialogButton>
    {
        public override Color Value { get { return Control.Color; } set { Control.Color = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.ColorChanged += value; }
            remove { Control.ColorChanged -= value; }
        }

        protected override void InitializeControl() {}
    }
}