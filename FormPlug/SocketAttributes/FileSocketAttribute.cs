namespace FormPlug.SocketAttributes
{
    public class FileSocketAttribute : SocketAttribute
    {
        public bool SaveMode { get; set; }
        public string[] Extensions { get; set; }
        public string InitialDirectory { get; set; }

        public FileSocketAttribute()
        {
            SaveMode = false;
        }
    }
}