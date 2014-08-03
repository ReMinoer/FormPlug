namespace FormPlug.PlugsBase
{
    public abstract class FolderPlugBase<TControl> : Plug<string, TControl, FolderSocketAttribute>
        where TControl : new()
    {
        protected override FolderSocketAttribute DefaultAttribute { get { return new FolderSocketAttribute(); } }
        protected sealed override void UseAttribute(FolderSocketAttribute attribute) {}
    }
}