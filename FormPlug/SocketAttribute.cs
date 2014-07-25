﻿using System;

namespace FormPlug
{
    // TODO : Name, group in attribute
    [AttributeUsage(AttributeTargets.Property)]
    public class SocketAttribute : Attribute
    {
        public string ValueChangedEventName { get; set; }
        public const string DefaultExternalEventExtension = "ValueChanged";
    }

    public class IntegerSocketAttribute : SocketAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Increment { get; set; }
    }
}