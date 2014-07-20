using System.Reflection;
using System.Windows.Forms;
using FormPlug.WindowsForm.Sockets;

namespace FormPlug.WindowsForm
{
    static public class PanelGenerator
    {
        static public void Create(Control parent, object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
                foreach (object attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (!(attribute is PlugableAttribute))
                        continue;

                    parent.Controls.Add(new Label {Text = propertyInfo.Name});

                    if (attribute is PlugableIntAttribute)
                        parent.Controls.Add(new IntegerSocket(ref obj, propertyInfo, attribute as PlugableIntAttribute));
                }
        }
    }
}