using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FormPlug.TestHelper;
using FormPlug.WindowsForm.Controls;
using FormPlug.WindowsForm.Plugs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FormPlug.WindowsForm.Test
{
    [TestClass]
    public class WindowsFormPlugTest
    {
        [TestMethod]
        public void NumericPlug()
        {
            PlugTestHelper.PlugTest<TestObject, NumericPlug<int>, int, NumericSocketAttribute, NumericUpDown>(0, 1);
        }

        [TestMethod]
        public void TextPlug()
        {
            PlugTestHelper.PlugTest<TestObject, TextPlug, string, TextSocketAttribute, TextBox>("", "text");
        }

        [TestMethod]
        public void BooleanPlug()
        {
            PlugTestHelper.PlugTest<TestObject, BooleanPlug, bool, BooleanSocketAttribute, CheckBox>(false, true);
        }

        [TestMethod]
        public void EnumPlug()
        {
            PlugTestHelper.PlugTest<TestObject, EnumPlug<TestEnum>, TestEnum, EnumSocketAttribute, ComboBox>(
                TestEnum.No, TestEnum.Yes);
        }

        [TestMethod]
        public void ColorPlug()
        {
            PlugTestHelper.PlugTest<TestObject, ColorPlug, Color, ColorSocketAttribute, ColorDialogButton>(Color.White,
                Color.Black);
        }

        [TestMethod]
        public void DateTimePlug()
        {
            PlugTestHelper.PlugTest<TestObject, DateTimePlug, DateTime, DateTimeSocketAttribute, DateTimePicker>(
                DateTime.Now, DateTime.Today);
        }

        [TestMethod]
        public void FilePlug()
        {
            string tempFile1 = Path.Combine(Environment.CurrentDirectory, "temp1.txt");
            string tempFile2 = Path.Combine(Environment.CurrentDirectory, "temp2.txt");

            Action init = () =>
            {
                File.Create(tempFile1).Close();
                File.Create(tempFile2).Close();
            };

            Action end = () =>
            {
                File.Delete(tempFile1);
                File.Delete(tempFile2);
            };

            PlugTestHelper.PlugTest<TestObject, FilePlug, string, FileSocketAttribute, FileDialogButton>(tempFile1,
                tempFile2, init, end);
        }

        [TestMethod]
        public void FolderPlug()
        {
            PlugTestHelper.PlugTest<TestObject, FolderPlug, string, FolderSocketAttribute, FolderDialogButton>(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}