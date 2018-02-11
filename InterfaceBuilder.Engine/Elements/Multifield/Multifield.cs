using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.IO;
using System.Reflection;
using System.Text;

namespace InterfaceBuilder.Engine.Elements
{
    internal class Multifield : IElement
    {
        public string Build(object obj)
        {
            Element multifield = (Element)obj;
            string template = GetTemplate();
            template = string.Format(template, multifield.Label);

            StringBuilder stringBuilder = new StringBuilder();

            if(multifield.Elements != null &&
                multifield.Elements.Count > 0)
            {
                foreach (var element in multifield.Elements)
                {
                    stringBuilder.Append(Factory.GetInstance(element.Type).Build(element));
                }
            }

            return template.Replace("#PLACEHOLDER#", stringBuilder.ToString());
        }

        private string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Engine.Elements.Multifield.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}