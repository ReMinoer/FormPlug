using System;
using System.Windows.Forms;
using FormPlug.PlugBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class NumericPlug<TValue> : NumericPlugBase<TValue, NumericUpDown>
    {
        protected override int Minimum { set { Control.Minimum = value; } }
        protected override int Maximum { set { Control.Maximum = value; } }
        protected override int Increment { set { Control.Increment = value; } }

        public override TValue Value
        {
            get { return (TValue)Convert.ChangeType(Control.Value, typeof(TValue)); }
            set { Control.Value = (decimal)Convert.ChangeType(value, typeof(decimal)); }
        }

        public override event EventHandler ValueChanged
        {
            add { Control.ValueChanged += value; }
            remove { Control.ValueChanged -= value; }
        }
    }
}