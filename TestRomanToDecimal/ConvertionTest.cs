using System;
using RomanToDecimal;
using Xunit;

namespace TestRomanToDecimal
{
    public class ConversionTest
    {
        [Theory]
        [InlineData("II", 2)]
        [InlineData("VV", 10)]
        [InlineData("XX", 20)]
        [InlineData("LL", 100)]
        [InlineData("CC", 200)]
        [InlineData("DD", 1000)]
        [InlineData("MM", 2000)]
        public void SameSymbol_I_Add(string input, int expected)
        {
            var calculator = new RomanNumberCalculator();
            var value = RomanNumberCalculator.Convert(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("VI", 6)]
        [InlineData("XV", 15)]
        [InlineData("LX", 60)]
        [InlineData("CL", 150)]
        [InlineData("DC", 600)]
        [InlineData("MD", 1500)]
        [InlineData("MMVI", 2006)]
        [InlineData("MDCLXVI", 1666)]
        public void MixedSymbolAdd(string input, int expected)
        {
            var calculator = new RomanNumberCalculator();
            var value = RomanNumberCalculator.Convert(input);
            Assert.Equal(expected, value);
        }
        
        
        [Theory]
        [InlineData("IV", 4)]
        [InlineData("VX", 5)]
        [InlineData("XL", 40)]
        [InlineData("LC", 50)]
        [InlineData("CD", 400)]
        [InlineData("DM", 500)]
        [InlineData("MCMXLIV", 1944)]
        public void Subtraction(string input, int expected)
        {
            var calculator = new RomanNumberCalculator();
            var value = RomanNumberCalculator.Convert(input);
            Assert.Equal(expected, value);
        }
    }
}