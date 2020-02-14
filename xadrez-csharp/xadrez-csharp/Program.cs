using System;
using board;

namespace xadrez_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            View.printBoard(board);

            Console.ReadLine();
        }
    }
}
