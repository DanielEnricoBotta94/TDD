using System;
using Xunit;

namespace TestBrackets
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyInput()
        {
            var output = Brackets.Brackets.IsValid("");
            Assert.True(output);
        }
        
        [Fact]
        public void SimpleBrackets()
        {
            var output = Brackets.Brackets.IsValid("[]");
            Assert.True(output);
        }
        
        [Fact]
        public void DoubleBrackets()
        {
            var output = Brackets.Brackets.IsValid("[][]");
            Assert.True(output);
        }
        
        [Fact]
        public void NestedBrackets()
        {
            var output = Brackets.Brackets.IsValid("[[]]");
            Assert.True(output);
        }
        
        [Fact]
        public void DoubleNestedBrackets()
        {
            var output = Brackets.Brackets.IsValid("[[[]]]");
            Assert.True(output);
        }
        
        [Fact]
        public void CloseOpenBrackets()
        {
            var output = Brackets.Brackets.IsValid("][");
            Assert.False(output);
        }
        
        [Theory]
        [InlineData("][]][")]
        [InlineData("[][]][")]
        public void InvalidBrackets(string input)
        {
            var output = Brackets.Brackets.IsValid(input);
            Assert.False(output);
        }
    }
}