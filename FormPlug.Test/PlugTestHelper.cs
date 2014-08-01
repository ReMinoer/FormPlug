using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.Test
{
    static public class PlugTestHelper
    {
        static public void PlugTest<TObject, TPlug, TValue, TControl>(TValue initValue, TValue newValue)
            where TPlug : IPlug<TValue, TControl>, new()
            where TObject : new()
        {
            if (initValue.Equals(newValue))
                Assert.Inconclusive("initValue & newValue can't be equals !");

            var obj = new TObject();

            PropertyInfo[] tab = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (PropertyInfo propertyType in tab)
                if (propertyType.PropertyType == typeof(TValue))
                {
                    PlugValueChangedWithSocket<TPlug, TValue, TControl>(initValue, newValue);
                    PlugValueChangedWithAttribute<TPlug, TValue, TControl>(obj, propertyType, initValue, newValue);
                    SocketValueChangedWithSocket<TPlug, TValue, TControl>(initValue, newValue);
                    SocketValueChangedWithAttribute<TPlug, TValue, TControl>(obj, propertyType, initValue, newValue);
                    return;
                }

            Assert.Inconclusive("{0} doesn't contains property of this type {1}", typeof(TObject).Name, typeof(TValue).Name);
        }

        static public void PlugValueChangedWithSocket<TPlug, TValue, TControl>(TValue initValue, TValue newValue)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            var socket = new Socket<TValue>{Value = initValue};

            var plug = new TPlug();
            plug.Connect(socket);

            plug.Value = newValue;

            Assert.AreEqual(socket.Value, newValue);
        }

        static public void PlugValueChangedWithAttribute<TPlug, TValue, TControl>(object obj, PropertyInfo propertyInfo, TValue initValue, TValue newValue)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            propertyInfo.SetValue(obj, initValue);

            var plug = new TPlug();
            plug.Connect(obj, propertyInfo);

            plug.Value = newValue;

            Assert.AreEqual(propertyInfo.GetValue(obj), newValue);
        }

        static public void SocketValueChangedWithSocket<TPlug, TValue, TControl>(TValue initValue, TValue newValue)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            var socket = new Socket<TValue> { Value = initValue };

            var plug = new TPlug();
            plug.Connect(socket);

            socket.Value = newValue;

            Assert.AreEqual(plug.Value, newValue);
        }

        static public void SocketValueChangedWithAttribute<TPlug, TValue, TControl>(object obj, PropertyInfo propertyInfo, TValue initValue, TValue newValue)
            where TPlug : IPlug<TValue, TControl>, new()
        {
            propertyInfo.SetValue(obj, initValue);

            var plug = new TPlug();
            plug.Connect(obj, propertyInfo);

            propertyInfo.SetValue(obj, newValue);

            Assert.AreEqual(plug.Value, newValue);
        }
    }
}