using InterfaceBuilder.Engine;
using InterfaceBuilder.Model;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace InterfaceBuilder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args != null &&
                args.Length != 2)
            {
                System.Console.WriteLine("Hey, you have to pass two parameters: <my_input_json> <my_output_template>");
                return;
            }

            Builder builder = new Builder();

            Window window = LoadFromFile(args[0]);
            string filePath = args[1];

            string windowContent = builder.Build(window);
            string template = GetTemplate();

            InsertIntoTemplate(windowContent, template, filePath);
        }

        private static Window LoadFromFile(string filePath)
        {
            Window window = null;

            try
            {
                string fileContent = File.ReadAllText(filePath);
                window = JsonConvert.DeserializeObject<Window>(fileContent);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return window;
        }

        private static void InsertIntoTemplate(string window, string template, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, template.Replace("[WINDOW]",
                    window, System.StringComparison.InvariantCulture));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private static string GetTemplate()
        {
            string template = null;
            var assembly = typeof(Program).GetTypeInfo().Assembly;

            using (StreamReader streamReader = new StreamReader(assembly.
                GetManifestResourceStream("InterfaceBuilder.Console.Template.Template.html")))
            {
                template = streamReader.ReadToEnd();
            }

            return template;
        }
    }
}