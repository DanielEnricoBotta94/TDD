using System;
using Xunit;

namespace TestFizzBuzz
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(6, "Fizz")]
        [InlineData(9, "Fizz")]
        [InlineData(12, "Fizz")]
        [InlineData(33, "Fizz")]
        [InlineData(66, "Fizz")]
        [InlineData(12342, "Fizz")]
        public void Fizz(int input, string expected)
        {
            var output = FizzBuzz.FizzBuzz.Convert(input);
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        [InlineData(13, "13")]
        [InlineData(44, "44")]
        [InlineData(67, "67")]
        [InlineData(12346, "12346")]
        public void NotFizzNotBuzz(int input, string expected)
        {
            var output = FizzBuzz.FizzBuzz.Convert(input);
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(5, "Buzz")]
        [InlineData(10, "Buzz")]
        [InlineData(20, "Buzz")]
        [InlineData(200, "Buzz")]
        [InlineData(3005, "Buzz")]
        [InlineData(61235, "Buzz")]
        public void Buzz(int input, string expected)
        {
            var output = FizzBuzz.FizzBuzz.Convert(input);
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        [InlineData(60, "FizzBuzz")]
        [InlineData(120, "FizzBuzz")]
        [InlineData(1545, "FizzBuzz")]
        public void FizzBuzzFinal(int input, string expected)
        {
            var output = FizzBuzz.FizzBuzz.Convert(input);
            Assert.Equal(expected, output);
        }
    }
}