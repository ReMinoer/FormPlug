using System;
using System.Windows.Forms;
using FormPlug.PlugBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class BooleanPlug : BooleanPlugBase<CheckBox>
    {
        public override bool Value { get { return Control.Checked; } set { Control.Checked = value; } }
        protected override void InitializeConnection() {}

        public override event EventHandler ValueChanged
        {
            add { Control.CheckedChanged += value; }
            remove { Control.CheckedChanged -= value; }
        }
    }
}