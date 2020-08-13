using System;
using System.Linq;
using ConsoleStone;
using Xunit;

namespace TestConsoleStone
{
    public class PlayerTest
    {
        
        [Theory]
        [InlineData(3)]
        public void PlayerDrawQuantity(int quantity)
        {
            var player = Player.CreateInstance();
            player.DrawFromDeck(quantity);
            Assert.Equal(quantity, player.Hand.Count);
        }
        
        [Fact]
        public void PlayerDeck()
        {
            var player = Player.CreateInstance();
            Assert.Equal(20, player.Deck.Count);
        }
        
        [Fact]
        public void PlayerId()
        {
            var player = Player.CreateInstance();
            Assert.NotEqual(Guid.Empty, player.Id);
        }
    }
}