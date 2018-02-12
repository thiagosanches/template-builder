using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.IO;
using System.Reflection;

namespace InterfaceBuilder.Engine.Elements
{
    internal class Combobox : IElement
    {
        public string Build(object obj)
        {
            InterfaceBuilder.Model.Element element = (InterfaceBuilder.Model.Element)obj;
            string template = GetTemplate();

            return string.Format(template, element.Label, element.Hint);
        }

        private string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Engine.Elements.Combobox.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}