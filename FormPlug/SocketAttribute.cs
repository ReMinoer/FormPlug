using System;

namespace FormPlug
{
    // TODO : Name, group in attribute
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SocketAttribute : Attribute
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string CustomValueChangedEventName { get; set; }
        public const string DefaultValueChangedExtension = "ValueChanged";
    }

    public class IntegerSocketAttribute : SocketAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
    }

    public class TextSocketAttribute : SocketAttribute {}
}