using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanToDecimal
{
    public class RomanNumberCalculator
    {
        public static int Convert(string input)
        {
            var convertedList = new List<int>();
            input.ToList().ForEach(f =>
            {
                convertedList.Add((int)Enum.Parse(typeof(ERomanNumber), f.ToString()));
            });

            convertedList.Reverse();

            var result = 0;
            for (var i = 0; i < convertedList.Count; i += 2)
            {
                result += convertedList
                    .Skip(i)
                    .Take(2)
                    .Aggregate((a, b) =>
                        a > b
                            ? a - b
                            : a + b
                    );
            }
            
            return result;
        }
    }
    
    public enum ERomanNumber
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }
}