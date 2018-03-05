using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.IO;
using System.Reflection;

namespace InterfaceBuilder.Engine.Elements
{
    internal class RichText : IElement
    {
        public string Build(object element)
        {
            InterfaceBuilder.Model.Element richtext = (InterfaceBuilder.Model.Element)element;
            string template = GetTemplate();

            return string.Format(template, richtext.Label, richtext.DefaultValue, richtext.Hint);
        }

        private string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Engine.Elements.RichText.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}