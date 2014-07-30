using System;
using System.Windows.Forms;
using FormPlug.PlugBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class DateTimePlug : DateTimePlugBase<DateTimePicker>
    {
        public override DateTime Value { get { return Control.Value; } set { Control.Value = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.ValueChanged += value; }
            remove { Control.ValueChanged -= value; }
        }
    }
}