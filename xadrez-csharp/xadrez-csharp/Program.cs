using System;
using board;
using chess;

namespace xadrez_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.setPiece(new Tower(board, Color.Azul), new Position(1, 4));
            board.setPiece(new King(board, Color.Vermelha), new Position(2, 7));

            View.printBoard(board);

            Console.ReadLine();
        }
    }
}
