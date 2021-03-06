﻿using FormPlug.SocketAttributes;

namespace FormPlug.PlugsBase
{
    public abstract class FolderPlugBase<TControl> : Plug<string, TControl, FolderSocketAttribute>
        where TControl : new()
    {
        protected FolderPlugBase()
        {
        }

        protected FolderPlugBase(TControl control)
            : base(control)
        {
        }

        protected override sealed void UseCustomAttribute(FolderSocketAttribute attribute)
        {
        }
    }
}