using System;

namespace FormPlug.PlugBase
{
    public abstract class NumericPlugBase<TValue, TControl, TOutput> : Plug<TValue, TControl, NumericSocketAttribute>
        where TControl : new()
    {
        protected abstract int Minimum { set; }
        protected abstract int Maximum { set; }
        protected abstract int Increment { set; }

        protected abstract TOutput Output { get; set; }

        public override TValue Value
        {
            get { return (TValue)Convert.ChangeType(Output, typeof(TValue)); }
            set { Output = (TOutput)Convert.ChangeType(value, typeof(TOutput)); }
        }

        protected override void UseSocketAttribute(NumericSocketAttribute attribute)
        {
            Minimum = attribute.Minimum;
            Maximum = attribute.Maximum;
            Increment = attribute.Increment;
        }
    }
}