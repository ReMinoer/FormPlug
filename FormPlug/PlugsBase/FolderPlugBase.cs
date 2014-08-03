namespace FormPlug.PlugsBase
{
    public abstract class FolderPlugBase<TControl> : Plug<string, TControl, FolderSocketAttribute>
        where TControl : new()
    {
        protected sealed override void UseSocketAttribute(FolderSocketAttribute attribute) {}
    }
}