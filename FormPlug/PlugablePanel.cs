using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace FormPlug
{
    // TODO : Choice to connect a PlugablePanel without SocketAttribute
    public abstract class PlugablePanel<TPanel, TObject, TControl>
    {
        public TPanel Panel { get; private set; }
        protected List<IPlug> Plugs { get; private set; }

        private SocketAdapter<TObject> _adapter;
        private bool _isAdapter;
        private TObject _obj;
        private ReadOnlyDictionary<string, PropertyInfo> _properties;

        protected PlugablePanel(TPanel panel)
        {
            Panel = panel;
            Plugs = new List<IPlug>();
        }

        public void Connect(TObject obj)
        {
            PropertyInfo[] propertyInfos =
                obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var dictionary = new ReadOnlyDictionary<string, PropertyInfo>(propertyInfos.ToDictionary(p => p.Name));

            _obj = obj;
            _properties = dictionary;
            _isAdapter = false;

            CreatePlugs(Panel);
        }

        public void Connect(SocketAdapter<TObject> socketAdapter)
        {
            PropertyInfo[] propertyInfos = socketAdapter.SocketAttributes.Keys.ToArray();

            var dictionary = new ReadOnlyDictionary<string, PropertyInfo>(propertyInfos.ToDictionary(p => p.Name));

            _adapter = socketAdapter;
            _obj = socketAdapter.Object;
            _properties = dictionary;
            _isAdapter = true;

            CreatePlugs(Panel);
        }

        protected abstract void CreatePlugs(TPanel panel);

        protected void AddPlug<TPlug>(TControl control, string propertyName) where TPlug : IPlug<TControl>, new()
        {
            Type controlType = new TPlug().Control.GetType();
            ConstructorInfo constructor = typeof(TPlug).GetConstructor(new[] {controlType});

            if (constructor == null)
                throw new InvalidOperationException(
                    string.Format("{0} doesn't implements constructor who takes {1} as parameter", typeof(TPlug).Name,
                        controlType.Name));

            var plug = (TPlug)constructor.Invoke(new object[] {control});

            PropertyInfo property = _properties[propertyName];

            if (_isAdapter)
                plug.Connect(_adapter.Object, property, _adapter.SocketAttributes[property]);
            else
                plug.Connect(_obj, property);

            Plugs.Add(plug);
        }

        protected void AddPlug<TPlug>(TControl control, string propertyName, SocketAttribute attribute)
            where TPlug : IPlug<TControl>, new()
        {
            Type controlType = new TPlug().Control.GetType();
            ConstructorInfo constructor = typeof(TPlug).GetConstructor(new[] {controlType});

            if (constructor == null)
                throw new InvalidOperationException(
                    string.Format("{0} doesn't implements constructor who takes {1} as parameter", typeof(TPlug).Name,
                        controlType.Name));

            var plug = (TPlug)constructor.Invoke(new object[] {control});
            plug.Connect(_obj, _properties[propertyName], attribute);
            Plugs.Add(plug);
        }
    }
}