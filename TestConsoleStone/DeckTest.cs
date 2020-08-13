using ConsoleStone;
using Xunit;

namespace TestConsoleStone
{
    public class DeckTest
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
        public void DrawCardFromDeck()
        {
            var player = Player.CreateInstance();
            player.DrawFromDeck(1);
            Assert.Single(player.Hand);
        }
    }
}