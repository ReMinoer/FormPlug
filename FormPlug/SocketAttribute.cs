using System;

namespace FormPlug
{
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
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
        public int Decimals { get; set; }
    }

    public class TextSocketAttribute : SocketAttribute
    {
        public bool Multiline { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class BooleanSocketAttribute : SocketAttribute {}

    public class EnumSocketAttribute : SocketAttribute {}

    public class DateTimeSocketAttribute : SocketAttribute {}
}