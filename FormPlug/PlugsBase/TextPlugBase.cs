using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class TextPlugBase<TControl> : Plug<string, TControl, TextSocketAttribute>
        where TControl : new()
    {
        protected abstract int MaxLenght { set; }
        protected abstract bool Multiline { set; }
        protected abstract int Width { set; }
        protected abstract int Height { set; }
        protected abstract bool Password { set; }

        protected TextPlugBase()
        {
        }

        protected TextPlugBase(TControl control)
            : base(control)
        {
        }

        protected override sealed void UseCustomAttribute(TextSocketAttribute attribute)
        {
            MaxLenght = attribute.MaxLenght;
            Multiline = attribute.Multiline;
            Password = attribute.Password;

            if (!attribute.Multiline)
                return;

            Width = attribute.Width;
            Height = attribute.Height;
        }
    }
}