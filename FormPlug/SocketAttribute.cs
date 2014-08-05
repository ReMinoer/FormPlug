using System;

namespace FormPlug
{
    // TODO : bool Label property for SocketAttribute
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
    }

    public class TextSocketAttribute : SocketAttribute
    {
        public int MaxLenght { get; set; }
        public bool Multiline { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class BooleanSocketAttribute : SocketAttribute {}

    public class EnumSocketAttribute : SocketAttribute {}

    public class DateTimeSocketAttribute : SocketAttribute {}

    public class ColorSocketAttribute : SocketAttribute {}

    public class FileSocketAttribute : SocketAttribute
    {
        public bool SaveMode { get; set; }
        public string Filter { get; set; }
        public string InitialDirectory { get; set; }
    }

    public class FolderSocketAttribute : SocketAttribute {}
}