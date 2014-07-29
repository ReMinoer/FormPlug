namespace FormPlug.PlugBase
{
    public abstract class IntegerPlugBase<TControl> : Plug<int, IntegerSocketAttribute, TControl>
        where TControl : new()
    {
        protected abstract int Minimum { set; }
        protected abstract int Maximum { set; }
        protected abstract int Increment { set; }

        protected override void UseSocketAttribute(IntegerSocketAttribute attribute)
        {
            Minimum = attribute.Minimum;
            Maximum = attribute.Maximum;
            Increment = attribute.Increment;
        }
    }
}