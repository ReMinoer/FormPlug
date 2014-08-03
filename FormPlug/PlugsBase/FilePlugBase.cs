namespace FormPlug.PlugsBase
{
    public abstract class FilePlugBase<TControl> : Plug<string, TControl, FileSocketAttribute>
        where TControl : new()
    {
        protected abstract string Filter { set; }
        protected abstract string InitialDirectory { set; }

        protected sealed override void UseSocketAttribute(FileSocketAttribute attribute)
        {
            Filter = attribute.Filter;
            InitialDirectory = attribute.InitialDirectory;
        }
    }
}