using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System.Collections.Generic;
using System.Text;

namespace InterfaceBuilder.Engine
{
    public class Builder : IEngine
    {
        public string Build(Window window)
        {
            try
            {
                return RenderWindow(window);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private string RenderWindow(Window window)
        {
            string windowTemplate = string.Empty;
            string tabs = string.Empty;
            string elements = string.Empty;

            windowTemplate = Factory.GetInstance("window").Build(window);

            if (window.Tabs != null &&
                window.Tabs.Count > 0)
            {
                tabs = RenderTabs(window.Tabs);
            }

            if(window.Elements != null &&
                window.Elements.Count > 0)
            {
                foreach (var element in window.Elements)
                {
                    elements += RenderElement(element);
                }
            }

            return windowTemplate.Replace("#PLACEHOLDER#", string.Concat(tabs, elements));
        }

        private string RenderTabs(List<Tab> tabs)
        {
            return Factory.GetInstance("tab").Build(tabs);
        }

        private string RenderElement(Element element)
        {
            return Factory.GetInstance(element.Type).Build(element);
        }
    }
}