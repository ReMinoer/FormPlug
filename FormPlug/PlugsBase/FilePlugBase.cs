namespace FormPlug.PlugsBase
{
    public abstract class FilePlugBase<TControl> : Plug<string, TControl, FileSocketAttribute>
        where TControl : new()
    {
        protected abstract bool SaveMode { set; }
        protected abstract string Filter { set; }
        protected abstract string InitialDirectory { set; }

        protected sealed override void UseSocketAttribute(FileSocketAttribute attribute)
        {
            SaveMode = attribute.SaveMode;
            Filter = attribute.Filter;
            InitialDirectory = attribute.InitialDirectory;
        }
    }
}