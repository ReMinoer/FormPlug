using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.Test
{
    static public class FormPlugTestHelper
    {
        static public void PlugValueChanged<TPlug, TControl>() where TPlug : IPlug<int, TControl>, new()
        {
            var socket = new Socket<int> {Value = 0};

            var plug = new TPlug();
            plug.Connect(socket);

            plug.Value = 1;

            Assert.AreEqual(socket.Value, 1);
        }
    }
}