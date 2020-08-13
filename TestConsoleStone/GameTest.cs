using System;
using System.Linq;
using ConsoleStone;
using Xunit;

namespace TestConsoleStone
{
    public class GameTest
    {
        
        [Fact]
        public void NewGamePlayerCount()
        {
            var game = Game.CreateInstance();
            Assert.True(game.Players.Count == 2);

        }
        
        [Fact]
        public void NewGamePlayerMana()
        {
            var game = Game.CreateInstance();
            Assert.True(game.Players.All(a => a.Mana == 0));

        }
        
        [Fact]
        public void NewGamePlayerHealth()
        {
            var game = Game.CreateInstance();
            Assert.True(game.Players.All(a => a.Health == 30));

        }
        
        [Fact]
        public void NewGamePlayerDeck()
        {
            var game = Game.CreateInstance();
            Assert.True(game.Players.All(a => a.Deck.Count == 20));

        }
        
        [Fact]
        public void NewGamePlayerHand()
        {
            var game = Game.CreateInstance();
            Assert.True(game.Players.All(a => a.Hand.Count == 0));
        }
        
        [Fact]
        public void ChooseFirstPlayer()
        {
            var game = Game.CreateInstance();
            game.StartGame();
            var idList = game.Players.Select(p => p.Id);
            Assert.Contains(game.ActivePlayer, idList);
        }
        
        [Fact]
        public void StartingHandTest()
        {
            var game = Game.CreateInstance();
            game.StartGame();
            var firstPlayer = game.Players.First(f => f.Id.Equals(game.ActivePlayer));
            var secondPlayer = game.Players.First(f => !f.Id.Equals(game.ActivePlayer));
            Assert.Equal(3, firstPlayer.Hand.Count);
            Assert.Equal(4, secondPlayer.Hand.Count);
        }
    }
}