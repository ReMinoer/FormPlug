using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace FormPlug
{
    // TODO : Implements PlugablePanel
    public abstract class PlugablePanel<TPanel, TControl, TObject>
    {
        public TPanel Panel { get; private set; }
        protected List<IPlug<TControl>> Plugs { get; private set; }

        protected PlugablePanel(TPanel panel)
        {
            Panel = panel;
            Plugs = new List<IPlug<TControl>>();
        }

        public void Connect(TObject obj)
        {
            PropertyInfo[] propertyInfos =
                obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var dictionary = new ReadOnlyDictionary<string, PropertyInfo>(propertyInfos.ToDictionary(p => p.Name));

            CreatePlugs(Panel, obj, dictionary);
        }

        public void Connect<T>(SocketAdapter<T> socketAdapter)
        {
            throw new NotImplementedException();
        }

        protected abstract void CreatePlugs(TPanel panel, TObject obj, ReadOnlyDictionary<string, PropertyInfo> properties);
    }
}
