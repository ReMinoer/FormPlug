using System;
using System.Linq;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    public class Plug<T>
    {
        private readonly object _obj;
        private readonly PropertyInfo _property;
        private readonly ISocket<T> _socket;

        public Plug(ISocket<T> socket, ref object obj, PropertyInfo property)
        {
            _socket = socket;
            _obj = obj;
            _property = property;

            var attr = property.GetCustomAttribute(typeof(PlugableAttribute)) as PlugableAttribute;

            string externalEventName = attr != null && attr.ExternalEventName != null
                                           ? attr.ExternalEventName
                                           : property.Name + PlugableAttribute.DefaultExternalEventExtension;

            if (obj.GetType().GetEvents().Any(e => e.Name == externalEventName))
            {
                EventInfo eventInfo = obj.GetType().GetEvent(externalEventName);
                MethodInfo methodInfo = GetType().
                    GetMethod("OnExternalChange", BindingFlags.NonPublic | BindingFlags.Instance);
                Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
                eventInfo.AddEventHandler(_obj, handler);
            }

            _socket.PluggedValue = (T)_property.GetValue(_obj);
            _socket.InternalChange += OnInternalChange;
        }

        private void OnInternalChange(object sender, EventArgs eventArgs)
        {
            _property.SetValue(_obj, _socket.PluggedValue);
        }

        [UsedImplicitly]
        private void OnExternalChange(object sender, EventArgs eventArgs)
        {
            _socket.PluggedValue = (T)_property.GetValue(_obj);
        }
    }
}