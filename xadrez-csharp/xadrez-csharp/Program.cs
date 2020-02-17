using System;
using board;
using chess;

namespace xadrez_csharp {
  class Program {
    static void Main (string[] args) {

      try {
        ChessMatch match = new ChessMatch();

        while (!match.finished) {
          Console.Clear();
          View.printBoard(match.board);
          
          Console.Write("Origin: ");
          Position origin = View.readChessPosition().toPosition();
          Console.Write("Destination: ");
          Position destination = View.readChessPosition().toPosition();

          match.movePerform(origin, destination);
        }

      } catch (BoardException e) {
        Console.WriteLine(e.Message);
      }


      Console.ReadLine();
    }
  }
}
