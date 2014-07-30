namespace FormPlug.PlugBase
{
    // TODO : Add multiline property for textplug
    public abstract class TextPlugBase<TControl> : Plug<string, TControl, TextSocketAttribute>
        where TControl : new()
    {
        protected override void UseSocketAttribute(TextSocketAttribute attribute) {}
    }
}