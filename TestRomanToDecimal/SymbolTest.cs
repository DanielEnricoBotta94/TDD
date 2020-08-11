using System;
using RomanToDecimal;
using Xunit;

namespace TestRomanToDecimal
{
    public class SymbolTest{
        
        [Fact]
        public void Symbol_I()
        {
            const int value = (int) ERomanNumber.I;
            Assert.Equal(1, value);
        }
        
        [Fact]
        public void Symbol_V()
        {
            const int value = (int) ERomanNumber.V;
            Assert.Equal(5, value);
        }
        
        [Fact]
        public void Symbol_X()
        {
            const int value = (int) ERomanNumber.X;
            Assert.Equal(10, value);
        }
        
        [Fact]
        public void Symbol_L()
        {
            const int value = (int) ERomanNumber.L;
            Assert.Equal(50, value);
        }
        
        [Fact]
        public void Symbol_C()
        {
            const int value = (int) ERomanNumber.C;
            Assert.Equal(100, value);
        }
        
        [Fact]
        public void Symbol_D()
        {
            const int value = (int) ERomanNumber.D;
            Assert.Equal(500, value);
        }
        
        [Fact]
        public void Symbol_M()
        {
            const int value = (int) ERomanNumber.M;
            Assert.Equal(1000, value);
        }
        
        [Theory]
        [InlineData(ERomanNumber.M, ERomanNumber.D)]
        [InlineData(ERomanNumber.D, ERomanNumber.C)]
        [InlineData(ERomanNumber.C, ERomanNumber.L)]
        [InlineData(ERomanNumber.L, ERomanNumber.X)]
        [InlineData(ERomanNumber.X, ERomanNumber.V)]
        [InlineData(ERomanNumber.V, ERomanNumber.I)]
        public void GreaterThan(ERomanNumber greater, ERomanNumber smaller)
        {
            Assert.True(greater > smaller);
        }
    }
}