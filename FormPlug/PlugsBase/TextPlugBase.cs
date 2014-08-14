namespace FormPlug.PlugsBase
{
    public abstract class TextPlugBase<TControl> : Plug<string, TControl, TextSocketAttribute>
        where TControl : new()
    {
        protected abstract int MaxLenght { set; }
        protected abstract bool Multiline { set; }
        protected abstract int Width { set; }
        protected abstract int Height { set; }

        protected TextPlugBase() {}

        protected TextPlugBase(TControl control)
            : base(control) {}

        protected sealed override void UseAttribute(TextSocketAttribute attribute)
        {
            MaxLenght = attribute.MaxLenght;
            Multiline = attribute.Multiline;

            if (!attribute.Multiline)
                return;

            Width = attribute.Width;
            Height = attribute.Height;
        }
    }
}