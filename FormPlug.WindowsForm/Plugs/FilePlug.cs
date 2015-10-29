using System;
using FormPlug.PlugsBase;
using FormPlug.WindowsForm.Controls;

namespace FormPlug.WindowsForm.Plugs
{
    public class FilePlug : FilePlugBase<FileDialogButton>
    {
        protected override bool SaveMode
        {
            set { Control.SaveMode = value; }
        }

        protected override string[] Extensions
        {
            set
            {
                var filter = new string[value.Length];
                for (int i = 0; i < value.Length; i++)
                    filter[i] = string.Format("{1} files (*.{0})|*.{0}", value[i],
                        value[i] != "*" ? value[i].ToUpper() : "All");
                Control.Filter = string.Join("|", filter);
            }
        }

        protected override string InitialDirectory
        {
            set { Control.InitialDirectory = value; }
        }

        public override string Value
        {
            get { return Control.File; }
            set { Control.File = value; }
        }

        protected override bool ReadOnly
        {
            set { Control.Enabled = !value; }
        }

        public override event EventHandler ValueChanged
        {
            add { Control.FileChanged += value; }
            remove { Control.FileChanged -= value; }
        }

        public FilePlug()
        {
        }

        public FilePlug(FileDialogButton control)
            : base(control)
        {
        }

        protected override void InitializeControl()
        {
        }
    }
}