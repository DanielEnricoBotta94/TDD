using System;

namespace ConsoleStone
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = Game.CreateInstance();
            game.StartGame();
            Console.WriteLine(game.ToString());
        }
    }
}