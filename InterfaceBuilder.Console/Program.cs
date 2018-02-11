using InterfaceBuilder.Engine;
using InterfaceBuilder.Model;
using Newtonsoft.Json;
using System.IO;

namespace InterfaceBuilder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder();

            Window window = LoadFromFile(@"C:\Users\Thiago\repositories\interfacebuilder\example.json");
            InsertWindowIntoTemplate(builder.Build(window), @"C:\Users\Thiago\Downloads\Starter Template for Bootstrap.html");
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

        private static void InsertWindowIntoTemplate(string window, string filePath)
        {
            try
            {
                string templateContent = File.ReadAllText(filePath);
                File.WriteAllText(@"C:\Users\Thiago\Downloads\testing.html", 
                    templateContent.Replace("[WINDOW]", window, System.StringComparison.InvariantCulture));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}