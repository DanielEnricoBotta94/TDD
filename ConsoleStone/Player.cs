using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;

namespace ConsoleStone
{
    public class Player
    {
        public int Health { get; set; } = 30;
        public int Mana { get; set; } = 0;
        public List<Card> Deck { get; private set; }
        public List<Card> Hand { get; private set; }
        public Guid Id { get; } = Guid.NewGuid();

        private static readonly int[] DamageList = new[] {0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8};
        public static Player CreateInstance()
        {
            var player = new Player {Deck = new List<Card>(), Hand = new List<Card>()};
            player.Deck = GetStartingDeck();
            return player;
        }

        public void DrawFromDeck(int quantity)
        {
            Hand.AddRange(Deck.Take(quantity));
            Deck = Deck.Skip(quantity).ToList();
        }

        private static List<Card> GetStartingDeck()
        {
            return DamageList
                .Select(Card.CreateInstance)
                .ToList()
                .Shuffle()
                .ToList();
        }
    }
}