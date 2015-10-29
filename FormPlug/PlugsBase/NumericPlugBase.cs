using System;
using FormPlug.SocketAttributes;

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

        public override sealed TValue Value
        {
            get { return (TValue)Convert.ChangeType(Output, typeof(TValue)); }
            set { Output = (TOutput)Convert.ChangeType(value, typeof(TOutput)); }
        }

        protected NumericPlugBase()
        {
        }

        protected NumericPlugBase(TControl control)
            : base(control)
        {
        }

        protected override bool IsTypeValid(Type type)
        {
            try
            {
                // ReSharper disable once UnusedVariable
                object result = Convert.ChangeType(default(TValue), typeof(decimal));
            }
            catch
            {
                return false;
            }

            return true;
        }

        protected override sealed void UseCustomAttribute(NumericSocketAttribute attribute)
        {
            Minimum = attribute.Minimum;
            Maximum = attribute.Maximum;
            Increment = attribute.Increment;
            Decimals = attribute.Decimals;
        }
    }
}