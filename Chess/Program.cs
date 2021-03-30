using System;

namespace Chess
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);

            char[] inputDelimiters = { ' ', ',', '.', '\t' };
            Board board = new Board();

            GameManager game = new GameManager(board, inputDelimiters );

            game.Run();

            Console.ReadLine();
        }
    }
}
