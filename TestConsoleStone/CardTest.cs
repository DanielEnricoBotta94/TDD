using System;
using System.Linq;
using ConsoleStone;
using Xunit;

namespace TestConsoleStone
{
    public class CardTest
    {
        [Theory]
        [InlineData(5)]
        public void NewGamePlayerCount(int expected)
        {
            var card = Card.CreateInstance(expected);
            Assert.Equal(expected, card.Damage);
        }
    }
}