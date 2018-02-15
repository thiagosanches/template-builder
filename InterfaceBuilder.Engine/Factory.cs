using InterfaceBuilder.Engine.Elements;
using InterfaceBuilder.Engine.Interface;
using InterfaceBuilder.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceBuilder.Engine
{
    //A very simple factory.
    public static class Factory
    {
        private static List<IElement> Elements { get; set; }

        static Factory()
        {
            Elements = new List<IElement>();
        }

        public static IElement GetInstance(string type)
        {
            IElement control = null;

            switch (type)
            {
                case "textbox":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Textbox();
                        Elements.Add(control);
                    }
                    break;
                case "window":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Window();
                        Elements.Add(control);
                    }
                    break;
                case "tab":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Tabs();
                        Elements.Add(control);
                    }
                    break;
                case "multifield":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Multifield();
                        Elements.Add(control);
                    }
                    break;
                case "combobox":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Combobox();
                        Elements.Add(control);
                    }
                    break;
                case "checkbox":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Checkbox();
                        Elements.Add(control);
                    }
                    break;
                case "colorpicker":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.ColorPicker();
                        Elements.Add(control);
                    }
                    break;
                case "image":
                    if (Elements.Exists(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase)))
                        control = Elements.Find(t => t.GetType().Name.Equals(type, StringComparison.CurrentCultureIgnoreCase));
                    else
                    {
                        control = new Elements.Image();
                        Elements.Add(control);
                    }
                    break;
                default:
                    break;
            }

            return control;
        }
    }
}