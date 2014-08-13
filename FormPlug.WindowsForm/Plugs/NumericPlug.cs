using System;
using System.Windows.Forms;
using FormPlug.PlugsBase;

namespace FormPlug.WindowsForm.Plugs
{
    public class NumericPlug<T> : NumericPlugBase<T, NumericUpDown, decimal>
    {
        protected override double Minimum { set { Control.Minimum = (decimal)value; } }
        protected override double Maximum { set { Control.Maximum = (decimal)value; } }
        protected override double Increment { set { Control.Increment = (decimal)value; } }
        protected override int Decimals { set { Control.DecimalPlaces = value; } }

        public NumericPlug()
        {
        }

        public NumericPlug(NumericUpDown control)
            : base(control)
        {
        }

        protected override decimal Output { get { return Control.Value; } set { Control.Value = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.ValueChanged += value; }
            remove { Control.ValueChanged -= value; }
        }

        protected override void InitializeControl() {}
    }
}