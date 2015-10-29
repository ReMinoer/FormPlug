using System;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class DateTimePlug : DateTimePlugBase<DateTimePicker>
    {
        public override DateTime Value
        {
            get { return Control.Value; }
            set { Control.Value = value; }
        }

        protected override bool ReadOnly
        {
            set { Control.Enabled = !value; }
        }

        public override event EventHandler ValueChanged
        {
            add { Control.ValueChanged += value; }
            remove { Control.ValueChanged -= value; }
        }

        public DateTimePlug()
        {
        }

        public DateTimePlug(DateTimePicker control)
            : base(control)
        {
        }

        protected override void InitializeControl()
        {
        }
    }
}