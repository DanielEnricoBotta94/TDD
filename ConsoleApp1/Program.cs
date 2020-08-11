using System;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var input = "//[***]\n1***2***3";
            var outpit = StringCalculator.StringCalculator.CreateInstance().Add(input);
        }
    }
}