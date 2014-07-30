using System;

namespace FormPlug.PlugBase
{
    public abstract class EnumPlugBase<TValue, TControl> : Plug<TValue, TControl, EnumSocketAttribute>
        where TControl : new()
    {
        protected abstract string Output { get; set; }

        public override TValue Value
        {
            get { return (TValue)Enum.Parse(typeof(TValue), Output); }
            set { Output = Enum.GetName(typeof(TValue), value); }
        }

        protected override void UseSocketAttribute(EnumSocketAttribute attribute) {}
    }
}