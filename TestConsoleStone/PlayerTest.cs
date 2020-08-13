using System;
using System.Linq;
using ConsoleStone;
using Xunit;
using Xunit.Abstractions;

namespace TestConsoleStone
{
    public class PlayerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PlayerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void PlayerId()
        {
            var player = Player.CreateInstance();
            Assert.NotEqual(Guid.Empty, player.Id);
        }
        
        [Fact]
        public void GainManaSlot()
        {
            var player = Player.CreateInstance();
            var mana = player.GainManaSlot();
            Assert.Equal(1, mana);
        }
        
        [Fact]
        public void MaximumManaSlot()
        {
            var player = Player.CreateInstance();
            for (var i = 0; i < 100; i++)
            {
                player.GainManaSlot();
            }
            var mana = player.GainManaSlot();
            Assert.Equal(10, mana);
        }
        
        [Fact]
        public void RefillUsedMana()
        {
            var player = Player.CreateInstance();
            player.GainManaSlot();
            player.RefillMana();
            Assert.Equal(player.TotalMana, player.AvailableMana);
            player.UseMana(1);
            player.RefillMana();
            Assert.Equal(player.TotalMana, player.AvailableMana);
        }
        
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(10, 5, 5)]
        [InlineData(2, 2, 0)]
        public void UseMana(int totalMana, int useMana, int expected)
        {
            var player = Player.CreateInstance();
            for (var i = 0; i < totalMana; i++)
            {
                player.GainManaSlot();
            }
            player.RefillMana();
            var leftOverMana = player.UseMana(useMana);
            Assert.Equal(expected, leftOverMana);
        }
        
        [Fact]
        public void CanUseMana()
        {
            var player = Player.CreateInstance();
            player.GainManaSlot();
            player.RefillMana();
            Assert.Throws<Exception>(() =>  player.UseMana(12));
        }
    }
}