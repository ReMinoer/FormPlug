using System;

namespace FormPlug.PlugsBase
{
    public abstract class FilePlugBase<TControl> : Plug<string, TControl, FileSocketAttribute>
        where TControl : new()
    {
        protected abstract bool SaveMode { set; }
        protected abstract string Filter { set; }
        protected abstract string InitialDirectory { set; }

        protected override FileSocketAttribute DefaultAttribute
        {
            get
            {
                return new FileSocketAttribute
                {
                    SaveMode = false,
                    Filter = "All files (*.*)|*.*",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
            }
        }

        protected sealed override void UseAttribute(FileSocketAttribute attribute)
        {
            SaveMode = attribute.SaveMode;
            Filter = attribute.Filter;
            InitialDirectory = attribute.InitialDirectory;
        }
    }
}