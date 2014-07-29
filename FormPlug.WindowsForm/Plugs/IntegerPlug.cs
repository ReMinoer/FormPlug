using System;
using System.Windows.Forms;
using FormPlug.PlugBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class IntegerPlug : IntegerPlugBase<NumericUpDown>
    {
        protected override int Minimum { set { Control.Minimum = value; } }
        protected override int Maximum { set { Control.Maximum = value; } }
        protected override int Increment { set { Control.Increment = value; } }

        public override int Value { get { return (int)Control.Value; } set { Control.Value = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.ValueChanged += value; }
            remove { Control.ValueChanged -= value; }
        }
    }
}