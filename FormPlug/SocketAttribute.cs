using System;

namespace FormPlug
{
    // TODO : Implements ObjectSocketAttribute
    // TODO : Implements CollectionSocketAttribute
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SocketAttribute : Attribute
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string CustomValueChangedEventName { get; set; }

        public const string DefaultValueChangedExtension = "ValueChanged";
    }

    public class NumericSocketAttribute : SocketAttribute
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double Increment { get; set; }
        public int Decimals { get; set; }

        public NumericSocketAttribute()
        {
            Minimum = 0;
            Maximum = 10;
            Increment = 1;
            Decimals = 0;
        }
    }

    public class TextSocketAttribute : SocketAttribute
    {
        public int MaxLenght { get; set; }
        public bool Multiline { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TextSocketAttribute()
        {
            MaxLenght = int.MaxValue;
            Multiline = false;
            Width = 100;
            Height = 100;
        }
    }

    public class BooleanSocketAttribute : SocketAttribute {}

    public class EnumSocketAttribute : SocketAttribute
    {
        public string[] AlternativeNames { get; set; }
    }

    public class DateTimeSocketAttribute : SocketAttribute {}

    public class ColorSocketAttribute : SocketAttribute {}

    public class FileSocketAttribute : SocketAttribute
    {
        public bool SaveMode { get; set; }
        public string[] Extensions { get; set; }
        public string InitialDirectory { get; set; }

        public FileSocketAttribute()
        {
            SaveMode = false;
            Extensions = new[] {"*"};
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }

    public class FolderSocketAttribute : SocketAttribute {}
}