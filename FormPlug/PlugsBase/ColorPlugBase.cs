using System.Drawing;

namespace FormPlug.PlugsBase
{
    public abstract class ColorPlugBase<TControl> : Plug<Color, TControl, ColorSocketAttribute>
        where TControl : new()
    {
        protected sealed override void UseAttribute(ColorSocketAttribute attribute) {}
    }
}