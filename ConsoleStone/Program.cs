using System;

namespace ConsoleStone
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var game = Game.CreateInstance();
            game.StartGame();
            Console.WriteLine(game.ToString());
        }
    }
}