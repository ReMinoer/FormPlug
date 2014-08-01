namespace FormPlug.PlugsBase
{
    public abstract class TextPlugBase<TControl> : Plug<string, TControl, TextSocketAttribute>
        where TControl : new()
    {
        protected abstract bool Multiline { set; }
        protected abstract int Width { set; }
        protected abstract int Height { set; }

        protected override void UseSocketAttribute(TextSocketAttribute attribute)
        {
            Multiline = attribute.Multiline;

            if (!attribute.Multiline)
                return;

            Width = attribute.Width;
            Height = attribute.Height;
        }
    }
}