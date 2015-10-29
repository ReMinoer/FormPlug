using System.Drawing;
using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class ColorPlugBase<TControl> : Plug<Color, TControl, ColorSocketAttribute>
        where TControl : new()
    {
        protected ColorPlugBase()
        {
        }

        protected ColorPlugBase(TControl control)
            : base(control)
        {
        }

        protected override sealed void UseCustomAttribute(ColorSocketAttribute attribute)
        {
        }
    }
}