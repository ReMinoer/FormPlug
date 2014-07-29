namespace FormPlug.PlugBase
{
    public abstract class NumericPlugBase<TValue, TControl> : Plug<TValue, TControl, NumericSocketAttribute>
        where TControl : new()
    {
        protected abstract int Minimum { set; }
        protected abstract int Maximum { set; }
        protected abstract int Increment { set; }

        protected override void UseSocketAttribute(NumericSocketAttribute attribute)
        {
            Minimum = attribute.Minimum;
            Maximum = attribute.Maximum;
            Increment = attribute.Increment;
        }
    }
}