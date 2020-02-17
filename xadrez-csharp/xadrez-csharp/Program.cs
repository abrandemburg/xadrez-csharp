using System;
using board;
using chess;

namespace xadrez_csharp {
  class Program {
    static void Main (string[] args) {
      try {

        Board board = new Board(8, 8);
        board.setPiece(new Tower(board, Color.Azul), new Position(1, 4));
        board.setPiece(new King(board, Color.Vermelha), new Position(2, 7));
        board.setPiece(new Tower(board, Color.Branca), new Position(3, 6));
        board.setPiece(new King(board, Color.Branca), new Position(1, 3));
        View.printBoard(board);

      } catch (BoardException e) {
        Console.WriteLine(e.Message);
      }


      Console.ReadLine();
    }
  }
}
