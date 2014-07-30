using System.Windows.Forms;
using FormPlug.Test;
using FormPlug.WindowsForm.Plugs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.WindowsForm.Test
{
    [TestClass]
    public class WindowsFormTest
    {
        [TestMethod]
        public void PlugValueChanged()
        {
            FormPlugTestHelper.PlugValueChanged<NumericPlug<int>, NumericUpDown>();
        }
    }
}