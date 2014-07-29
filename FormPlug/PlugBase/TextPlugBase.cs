namespace FormPlug.PlugBase
{
    public abstract class TextPlugBase<TControl> : Plug<string, TextSocketAttribute, TControl>
        where TControl : new()
    {
        protected override void UseSocketAttribute(TextSocketAttribute attribute) {}
    }
}