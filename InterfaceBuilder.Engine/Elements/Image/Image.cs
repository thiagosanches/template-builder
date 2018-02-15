using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.IO;
using System.Reflection;

namespace InterfaceBuilder.Engine.Elements
{
    internal class Image : IElement
    {
        public string Build(object element)
        {
            Element textbox = (Element)element;
            string template = GetTemplate();

            return string.Format(template, textbox.Label,
                textbox.DefaultValue, textbox.Hint);
        }

        private string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Engine.Elements.Image.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}