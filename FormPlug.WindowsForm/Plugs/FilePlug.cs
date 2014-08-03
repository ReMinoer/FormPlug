using System;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    // TODO : Add a path in the TestObject and unit tests
    public class FilePlug : FilePlugBase<FileDialogButton>
    {
        protected override string Filter { set { Control.Filter = value; } }
        protected override string InitialDirectory { set { Control.InitialDirectory = value; } }

        public override string Value { get { return Control.File; } set { Control.File = value; } }

        public override event EventHandler ValueChanged
        {
            add { Control.FileChanged += value; }
            remove { Control.FileChanged -= value; }
        }

        protected override void InitializeConnection()
        {
            Filter = "*.*|All files (*.*)";
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}