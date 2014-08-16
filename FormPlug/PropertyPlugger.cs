using System;
using System.Reflection;
using FormPlug.Annotations;

namespace FormPlug
{
    internal class PropertyPlugger<TValue, TControl> : IPlugger
    {
        private EventInfo _event;
        private Delegate _handler;
        private object _obj;
        private IPlug<TValue, TControl> _plug;
        private PropertyInfo _property;

        public PropertyPlugger(IPlug<TValue, TControl> plug, object obj, PropertyInfo property)
        {
            var attr = property.GetCustomAttribute(typeof(SocketAttribute)) as SocketAttribute;
            //if (attr == null)
            //    throw new ArgumentException(string.Format("{0} doesn't have SocketAttribute !", property.Name));

            CommonConstructor(plug, obj, property, attr);
        }

        public PropertyPlugger(IPlug<TValue, TControl> plug, object obj, PropertyInfo property, SocketAttribute attr)
        {
            CommonConstructor(plug, obj, property, attr);
        }

        public void RemoveEvents()
        {
            _plug.ValueChanged -= OnPlugValueChanged;
            if (_event != null)
                _event.RemoveEventHandler(_obj, _handler);
        }

        private void CommonConstructor(IPlug<TValue, TControl> plug, object obj, PropertyInfo property,
                                       SocketAttribute attr)
        {
            string valueChangedEventName = attr != null
                                               ? attr.CustomValueChangedEventName
                                                 ?? property.Name + SocketAttribute.DefaultValueChangedExtension
                                               : property.Name + SocketAttribute.DefaultValueChangedExtension;

            _event = obj.GetType().GetEvent(valueChangedEventName);
            if (_event != null)
            {
                MethodInfo methodInfo = GetType().
                    GetMethod("OnSocketValueChanged", BindingFlags.NonPublic | BindingFlags.Instance);
                _handler = Delegate.CreateDelegate(_event.EventHandlerType, this, methodInfo);
            }
            else if (attr != null && attr.CustomValueChangedEventName != null)
                throw new ArgumentException(valueChangedEventName + " not found !");

            _plug = plug;
            _obj = obj;
            _property = property;

            _plug.Value = (TValue)_property.GetValue(_obj);

            _plug.ValueChanged += OnPlugValueChanged;
            if (_event != null)
                _event.AddEventHandler(_obj, _handler);
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