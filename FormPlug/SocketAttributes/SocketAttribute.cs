using System;

namespace FormPlug.SocketAttributes
{
    // TODO : Implements ObjectSocketAttribute
    // TODO : Implements CollectionSocketAttribute
    // TODO : Implements IndexSocketAttribute
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SocketAttribute : Attribute
    {
        public const string DefaultValueChangedExtension = "ValueChanged";
        public string Name { get; set; }
        public string Group { get; set; }
        public bool ReadOnly { get; set; }
        public string CustomValueChangedEventName { get; set; }
    }
}