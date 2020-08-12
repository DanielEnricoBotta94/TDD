using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Enum = Extensions.Enum;

namespace RomanToDecimal
{
    public class RomanNumberCalculator
    {
        public static int Convert(string input)
        {
            var convertedList = input
                .ToList()
                .Select(f => Enum.Parse<int>(typeof(ERomanNumber), f))
                .Reverse()
                .ToList();

            var result = 0;
            for (var i = 0; i < convertedList.Count(); i += 2)
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