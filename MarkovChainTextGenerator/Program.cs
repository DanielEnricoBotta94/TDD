using System;
using System.Linq;

namespace MarkovChainTextGenerator
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string path = @"F:\Documenti\CustomProjects\TDD\MarkovChainTextGenerator\dante.cantoprimo.txt";
            var text = System.IO.File.ReadAllText(path);
            var manager = Manager.CreateInstance(text);
            var output = GenerateText(manager);
            Console.WriteLine(output);
        }

        private static string GenerateText(Manager manager)
        {
            var finalString = "";
            var output = manager.GenerateOutput();
            for (var i = 0; i < 300; i++)
            {
                if(output != null && !string.IsNullOrEmpty(output.Trim()))
                    finalString = $"{finalString} {output}";
                output = manager.GenerateOutput(output);
            }

            return finalString;
        }
    }
}