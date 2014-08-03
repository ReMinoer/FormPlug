using System.Drawing;

namespace FormPlug.PlugsBase
{
    public abstract class ColorPlugBase<TControl> : Plug<Color, TControl, ColorSocketAttribute>
        where TControl : new()
    {
        protected override ColorSocketAttribute DefaultAttribute { get { return new ColorSocketAttribute(); } }
        protected sealed override void UseAttribute(ColorSocketAttribute attribute) {}
    }
}