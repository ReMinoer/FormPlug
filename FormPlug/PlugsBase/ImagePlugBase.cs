using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class ImagePlugBase<TControl> : Plug<string, TControl, ImageSocketAttribute>
        where TControl : new()
    {
        protected abstract string[] Extensions { set; }
        protected abstract string InitialDirectory { set; }
        protected abstract int Width { set; }
        protected abstract int Height { set; }

        protected ImagePlugBase()
        {
        }

        protected ImagePlugBase(TControl control)
            : base(control)
        {
        }

        protected override sealed void UseCustomAttribute(ImageSocketAttribute attribute)
        {
            Extensions = attribute.Extensions;
            InitialDirectory = attribute.InitialDirectory;
            Width = attribute.Width;
            Height = attribute.Height;
        }
    }
}