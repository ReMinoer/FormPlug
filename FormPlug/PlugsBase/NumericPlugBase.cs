using System;

namespace FormPlug.PlugsBase
{
    public abstract class NumericPlugBase<TValue, TControl, TOutput> : Plug<TValue, TControl, NumericSocketAttribute>
        where TControl : new()
    {
        protected abstract double Minimum { set; }
        protected abstract double Maximum { set; }
        protected abstract double Increment { set; }
        protected abstract int Decimals { set; }

        protected abstract TOutput Output { get; set; }

        public sealed override TValue Value
        {
            get { return (TValue)Convert.ChangeType(Output, typeof(TValue)); }
            set { Output = (TOutput)Convert.ChangeType(value, typeof(TOutput)); }
        }

        protected sealed override void UseSocketAttribute(NumericSocketAttribute attribute)
        {
            Minimum = attribute.Minimum;
            Maximum = attribute.Maximum;
            Increment = attribute.Increment;
            Decimals = attribute.Decimals;
        }
    }
}