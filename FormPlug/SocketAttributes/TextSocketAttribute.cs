namespace FormPlug.SocketAttributes
{
    public class TextSocketAttribute : SocketAttribute
    {
        public int MaxLenght { get; set; }
        public bool Multiline { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Password { get; set; }

        public TextSocketAttribute()
        {
            MaxLenght = int.MaxValue;
            Multiline = false;
            Width = 100;
            Height = 100;
            Password = false;
        }
    }
}