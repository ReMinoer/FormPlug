namespace FormPlug
{
    public interface IPlugablePanel<TObject>
    {
        void Connect(TObject obj);
        void Connect(SocketAdapter<TObject> socketAdapter);
    }
}