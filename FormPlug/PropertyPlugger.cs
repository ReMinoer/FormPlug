using System;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    internal class PropertyPlugger<TValue, TControl> : IPlugger
    {
        private readonly EventInfo _event;
        private readonly Delegate _handler;
        private readonly object _obj;
        private readonly IPlug<TValue, TControl> _plug;
        private readonly PropertyInfo _property;

        public PropertyPlugger(IPlug<TValue, TControl> plug, object obj, PropertyInfo property)
        {
            var attr = property.GetCustomAttribute(typeof(SocketAttribute)) as SocketAttribute;
            if (attr == null)
                throw new ArgumentException(string.Format("{0} doesn't have SocketAttribute !", property.Name));

            string valueChangedEventName = attr.CustomValueChangedEventName
                                           ?? property.Name + SocketAttribute.DefaultValueChangedExtension;

            _event = obj.GetType().GetEvent(valueChangedEventName);
            if (_event != null)
            {
                MethodInfo methodInfo = GetType().
                    GetMethod("OnSocketValueChanged", BindingFlags.NonPublic | BindingFlags.Instance);
                _handler = Delegate.CreateDelegate(_event.EventHandlerType, this, methodInfo);
            }
            else if (attr.CustomValueChangedEventName != null)
                throw new ArgumentException(valueChangedEventName + " not found !");

            _plug = plug;
            _obj = obj;
            _property = property;

            _plug.Value = (TValue)_property.GetValue(_obj);

            _plug.ValueChanged += OnPlugValueChanged;
            if (_event != null)
                _event.AddEventHandler(_obj, _handler);
        }

        public void RemoveEvents()
        {
            _plug.ValueChanged -= OnPlugValueChanged;
            if (_event != null)
                _event.RemoveEventHandler(_obj, _handler);
        }

        private void OnPlugValueChanged(object sender, EventArgs eventArgs)
        {
            _property.SetValue(_obj, _plug.Value);
        }

        [UsedImplicitly]
        private void OnSocketValueChanged(object sender, EventArgs eventArgs)
        {
            _plug.Value = (TValue)_property.GetValue(_obj);
        }
    }
}