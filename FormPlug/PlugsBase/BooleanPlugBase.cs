﻿using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class BooleanPlugBase<TControl> : Plug<bool, TControl, BooleanSocketAttribute>
        where TControl : new()
    {
        protected BooleanPlugBase() {}

        protected BooleanPlugBase(TControl control)
            : base(control) {}

        protected sealed override void UseCustomAttribute(BooleanSocketAttribute attribute) {}
    }
}