using System;
using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class DateTimePlugBase<TControl> : Plug<DateTime, TControl, DateTimeSocketAttribute>
        where TControl : new()
    {
        protected DateTimePlugBase()
        {
        }

        protected DateTimePlugBase(TControl control)
            : base(control)
        {
        }

        protected override sealed void UseCustomAttribute(DateTimeSocketAttribute attribute)
        {
        }
    }
}