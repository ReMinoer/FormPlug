namespace FormPlug.PlugBase
{
    public abstract class BooleanPlugBase<TControl> : Plug<bool, TControl, BooleanSocketAttribute>
        where TControl : new()
    {
        protected override void UseSocketAttribute(BooleanSocketAttribute attribute) { }
    }
}