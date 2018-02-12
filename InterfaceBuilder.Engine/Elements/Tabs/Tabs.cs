using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace InterfaceBuilder.Engine.Elements
{
    internal class Tabs : IElement
    {
        public string Build(object elements)
        {
            List<Tab> tabs = (List<Tab>)elements;

            string template = GetTemplate("Template");
            string navItemTemplate = GetTemplate("TemplateNavItem");

            StringBuilder navItems = new StringBuilder();
            StringBuilder tabsContent = new StringBuilder();
            bool firstItem = true;

            foreach (var tab in tabs)
            {
                string tabId = tab.Title.Replace(" ", "_");
                navItems.AppendFormat(navItemTemplate, tab.Title, tabId);
                string tabContent = string.Format(GetTemplate("TemplateTabContent"), tabId);

                foreach (var element in tab.Elements)
                {
                    tabContent = tabContent.Replace("#PLACEHOLDER#", 
                        Factory.GetInstance(element.Type).Build(element));

                    tabContent = tabContent.Insert(tabContent.Length - 26, "#PLACEHOLDER#"); //TODO: PLEASE REFACTOR THIS!!!
                }

                if (firstItem)
                {
                    tabContent = tabContent.Replace("tab-pane active", "tab-pane");
                    navItemTemplate = navItemTemplate.Replace("nav-item active", "nav-item");
                    firstItem = false;
                }

                tabsContent.Append(tabContent);
            }

            //TODO: REFACTOR THIS NAME!
            template = template.Replace("#NAVPLACEHOLDER#", navItems.ToString());
            template = template.Replace("#TABPLACEHOLDER#", tabsContent.ToString());
            template = template.Replace("#PLACEHOLDER#", string.Empty);

            return template;
        }

        private string GetTemplate(string resourceName)
        {
            string template = null;
            var assembly = typeof(Builder).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream(string.Format("InterfaceBuilder.Engine.Elements.Tabs.{0}.html", resourceName))))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}