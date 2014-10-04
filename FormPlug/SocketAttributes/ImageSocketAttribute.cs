using System;

namespace FormPlug.SocketAttributes
{
    public class ImageSocketAttribute : SocketAttribute
    {
        public string[] Extensions { get; set; }
        public string InitialDirectory { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ImageSocketAttribute()
        {
            Extensions = new[] {"*"};
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Width = 100;
            Height = 100;
        }
    }
}