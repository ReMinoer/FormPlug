using System;

namespace FormPlug.PlugsBase
{
    public abstract class DateTimePlugBase<TControl> : Plug<DateTime, TControl, DateTimeSocketAttribute>
        where TControl : new()
    {
        protected override DateTimeSocketAttribute DefaultAttribute { get { return new DateTimeSocketAttribute(); } }
        protected sealed override void UseAttribute(DateTimeSocketAttribute attribute) {}
    }
}