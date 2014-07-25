using System;
using System.Linq;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    public class PropertyPlugger<T>
    {
        private readonly object _obj;
        private readonly IPlug<T> _plug;
        private readonly PropertyInfo _property;

        public PropertyPlugger(IPlug<T> plug, object obj, PropertyInfo property)
        {
            var attr = property.GetCustomAttribute(typeof(SocketAttribute)) as SocketAttribute;
            if (attr == null)
                throw new ArgumentException(string.Format("{0} doesn't have SocketAttribute !", property.Name));

            _plug = plug;
            _obj = obj;
            _property = property;

            _plug.PluggedValue = (T)_property.GetValue(_obj);
            _plug.PlugValueChanged += OnPlugValueChanged;

            string valueChangedEventName = attr.ValueChangedEventName
                                           ?? property.Name + SocketAttribute.DefaultExternalEventExtension;

            if (obj.GetType().GetEvents().Any(e => e.Name == valueChangedEventName))
            {
                EventInfo eventInfo = obj.GetType().GetEvent(valueChangedEventName);
                MethodInfo methodInfo = GetType().
                    GetMethod("OnSocketValueChanged", BindingFlags.NonPublic | BindingFlags.Instance);
                Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
                eventInfo.AddEventHandler(_obj, handler);
            }
            else if (attr.ValueChangedEventName != null)
                throw new ArgumentException(valueChangedEventName + " not found !");
        }

        private void OnPlugValueChanged(object sender, EventArgs eventArgs)
        {
            _property.SetValue(_obj, _plug.PluggedValue);
        }

        [UsedImplicitly]
        private void OnSocketValueChanged(object sender, EventArgs eventArgs)
        {
            _plug.PluggedValue = (T)_property.GetValue(_obj);
        }
    }
}