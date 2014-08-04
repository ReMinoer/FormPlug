using System;

namespace FormPlug.PlugsBase
{
    public abstract class EnumPlugBase<TValue, TControl> : Plug<TValue, TControl, EnumSocketAttribute>
        where TControl : new()
    {
        protected abstract string Output { get; set; }

        public sealed override TValue Value
        {
            get { return (TValue)Enum.Parse(typeof(TValue), Output); }
            set { Output = Enum.GetName(typeof(TValue), value); }
        }

        protected override EnumSocketAttribute DefaultAttribute { get { return new EnumSocketAttribute(); } }

        protected override bool IsTypeValid(Type type)
        {
            return type.IsEnum;
        }

        protected sealed override void UseAttribute(EnumSocketAttribute attribute) {}
    }
}