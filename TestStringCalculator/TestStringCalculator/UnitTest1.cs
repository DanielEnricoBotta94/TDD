using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static StringCalculator.StringCalculator;

namespace StringCalculator
{
}

namespace TestStringCalculator
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void TestLessThanTwoNumbers(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("1,2,3,4,5,6,7", 28)]
        public void MoreThan2Numbers(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("1\n2,3", 6)]
        public void SupportDifferentSplitChar(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("//;\n1;2;3", 6)]
        public void SpecificDelimeter(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("-1")]
        [InlineData("-1,-2,-3")]
        public void ThrowOnNegative(string input)
        {
            var exception = Assert.Throws<Exception>(() => CreateInstance().Add(input));
            Assert.NotNull(exception);
            var inputSplit = input.Split(',');
            Assert.Contains(inputSplit, d => exception.Message.Contains(d));
        }
        
        [Theory]
        [InlineData("1001,2", 2)]
        [InlineData("5,100000,1234", 5)]
        public void IgnoreNumbersOver1000(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        public void AnyLengthDelimeter(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void MultipleDelimeter(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
        
        
        [Theory]
        [InlineData("//[**][%%]\n1**2%%3", 6)]
        public void MultipleAnyLengthDelimeter(string input, int expected)
        {
            var value = CreateInstance().Add(input);
            Assert.Equal(expected, value);
        }
    }
}