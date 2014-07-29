namespace FormPlug.PlugBase
{
    public abstract class TextPlugBase<TControl> : Plug<string, TControl, TextSocketAttribute>
        where TControl : new()
    {
        protected override void UseSocketAttribute(TextSocketAttribute attribute) {}
    }
}