using System;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class BooleanPlug : BooleanPlugBase<CheckBox>
    {
        public override bool Value { get { return Control.Checked; } set { Control.Checked = value; } }
        protected override bool ReadOnly { set { Control.Enabled = !value; } }

        public BooleanPlug() {}

        public BooleanPlug(CheckBox control)
            : base(control) {}

        public override event EventHandler ValueChanged
        {
            add { Control.CheckedChanged += value; }
            remove { Control.CheckedChanged -= value; }
        }

        protected override void InitializeControl() {}
    }
}