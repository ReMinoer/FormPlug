using System;

namespace FormPlug.PlugsBase
{
    public abstract class DateTimePlugBase<TControl> : Plug<DateTime, TControl, DateTimeSocketAttribute>
        where TControl : new()
    {
        protected sealed override void UseSocketAttribute(DateTimeSocketAttribute attribute) {}
    }
}