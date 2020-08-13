using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleStone
{
    public class Game
    {
        public IList<Player> Players { get; private set; }
        public Guid ActivePlayer { get; private set; }

        public static Game CreateInstance()
        {
            var game = new Game {Players = new List<Player>()};
            for (var i = 0; i < 2; i++)
                game.Players.Add(Player.CreateInstance());
            return game;
        }

        private Player SetActive(Player player)
        {
            return SetActive(player.Id);
        }

        private Player SetActive(Guid playerId)
        {
            var player = Players.FirstOrDefault(f => f.Id.Equals(playerId));
            if(player is null)
                throw new Exception("Player not found!");
            ActivePlayer = playerId;
            return player;
        }

        public void StartGame()
        {
            var random = new Random();
            var coinFlip = random.Next(0, Players.Count - 1);
            var firstPlayer = SetActive(Players[coinFlip]);
            firstPlayer.DrawFromDeck(3);
            var secondPlayer = Players.First(p => !p.Id.Equals(ActivePlayer));
            secondPlayer.DrawFromDeck(4);
        }
    }
}