using System;
using System.Linq;

namespace FizzBuzz
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Enumerable.Range(1, 12400).ToList().ForEach(Iterate);
        }

        private static void Iterate(int i)
        {
            var output = FizzBuzz.Convert(i);
            Console.WriteLine(output);
        }
    }
}