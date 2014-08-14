namespace FormPlug.PlugsBase
{
    public abstract class FilePlugBase<TControl> : Plug<string, TControl, FileSocketAttribute>
        where TControl : new()
    {
        protected abstract bool SaveMode { set; }
        protected abstract string[] Extensions { set; }
        protected abstract string InitialDirectory { set; }

        protected FilePlugBase() {}

        protected FilePlugBase(TControl control)
            : base(control) {}

        protected sealed override void UseAttribute(FileSocketAttribute attribute)
        {
            SaveMode = attribute.SaveMode;
            Extensions = attribute.Extensions;
            InitialDirectory = attribute.InitialDirectory;
        }
    }
}