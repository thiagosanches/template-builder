using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.IO;
using System.Reflection;
using System.Text;

namespace InterfaceBuilder.Engine.Elements
{
    internal class Fieldset : IElement
    {
        public string Build(object element)
        {
            InterfaceBuilder.Model.Element fieldset = (InterfaceBuilder.Model.Element)element;
            string template = GetTemplate();
            StringBuilder stringBuilder = new StringBuilder(); 

            foreach (var item in fieldset.Elements)
            {
                stringBuilder.Append(Factory.GetInstance(item.Type).Build(item));
            }

            return string.Format(template, fieldset.Label, stringBuilder.ToString());
        }

        private string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Engine.Elements.Fieldset.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}