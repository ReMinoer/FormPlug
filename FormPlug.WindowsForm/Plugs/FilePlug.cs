using System;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    public class FilePlug : FilePlugBase<FileDialogButton>
    {
        protected override bool SaveMode { set { Control.SaveMode = value; } }
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
            SaveMode = false;
            Filter = "All files (*.*)|*.*";
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}