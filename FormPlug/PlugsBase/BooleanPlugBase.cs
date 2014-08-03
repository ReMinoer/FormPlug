namespace FormPlug.PlugsBase
{
    public abstract class BooleanPlugBase<TControl> : Plug<bool, TControl, BooleanSocketAttribute>
        where TControl : new()
    {
        protected override BooleanSocketAttribute DefaultAttribute { get { return new BooleanSocketAttribute(); } }
        protected sealed override void UseAttribute(BooleanSocketAttribute attribute) {}
    }
}