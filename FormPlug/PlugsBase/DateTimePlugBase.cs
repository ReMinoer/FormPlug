using System;

namespace FormPlug.PlugsBase
{
    public abstract class DateTimePlugBase<TControl> : Plug<DateTime, TControl, DateTimeSocketAttribute>
        where TControl : new()
    {
        protected DateTimePlugBase() {}

        protected DateTimePlugBase(TControl control)
            : base(control) {}

        protected sealed override void UseAttribute(DateTimeSocketAttribute attribute) {}
    }
}