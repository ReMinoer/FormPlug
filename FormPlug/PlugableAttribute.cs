using System;

namespace FormPlug
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class PlugableAttribute : Attribute
    {
        public string ExternalEventName { get; set; }
        public const string DefaultExternalEventExtension = "ExternalChange";
    }

    public class PlugableIntAttribute : PlugableAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
    }
}