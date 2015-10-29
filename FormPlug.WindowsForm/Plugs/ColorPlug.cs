using System;
using System.Drawing;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    public class ColorPlug : ColorPlugBase<ColorDialogButton>
    {
        public override Color Value
        {
            get { return Control.Color; }
            set { Control.Color = value; }
        }

        protected override bool ReadOnly
        {
            set { Control.Enabled = !value; }
        }

        public override event EventHandler ValueChanged
        {
            add { Control.ColorChanged += value; }
            remove { Control.ColorChanged -= value; }
        }

        public ColorPlug()
        {
        }

        public ColorPlug(ColorDialogButton control)
            : base(control)
        {
        }

        protected override void InitializeControl()
        {
        }
    }
}