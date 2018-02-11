using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.IO;
using System.Reflection;

namespace InterfaceBuilder.Engine.Elements
{
    internal class Window : IElement
    {
        public string Build(object element)
        {
            InterfaceBuilder.Model.Window window = (InterfaceBuilder.Model.Window)element;
            string template = GetTemplate();

            return string.Format(template, window.Title);
        }

        private string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Engine.Elements.Window.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}