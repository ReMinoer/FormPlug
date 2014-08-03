using System;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    public class FolderPlug : FolderPlugBase<FolderDialogButton>
    {
        public override string Value { get { return Control.Folder; } set { Control.Folder = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.FolderChanged += value; }
            remove { Control.FolderChanged -= value; }
        }

        protected override void InitializeConnection() {}
    }
}