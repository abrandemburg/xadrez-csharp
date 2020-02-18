using board;
using chess;
using System;


namespace xadrez_csharp {
  class View {
    public static void printBoard (Board board) {

      for (int i = 0; i < board.lines; i++) {
        Console.Write(8 - i + " ");
        for (int j = 0; j < board.colunms; j++) {
          printPiece(board.piece(i, j));
        }
        Console.WriteLine();
      }
      Console.WriteLine("  a b c d e f g h");
    }
    internal static void printBoard (Board board, bool[,] possiblePositions) {

      ConsoleColor originalBackgroundColor = Console.BackgroundColor;
      ConsoleColor newBackgroundColor = ConsoleColor.DarkCyan;

      for (int i = 0; i < board.lines; i++) {
        Console.Write(8 - i + " ");
        for (int j = 0; j < board.colunms; j++) {
          if (possiblePositions[i, j]) {
            Console.BackgroundColor = newBackgroundColor;
          } else {
            Console.BackgroundColor = originalBackgroundColor;
          }
          printPiece(board.piece(i, j));
          Console.BackgroundColor = originalBackgroundColor;
        }
        Console.WriteLine();
      }
      Console.WriteLine("  a b c d e f g h");
      Console.BackgroundColor = originalBackgroundColor;
    }

    public static ChessPosition readChessPosition () {
      string s = Console.ReadLine();
      char colunm = s[0];
      int line = int.Parse(s[1] + "");

      return new ChessPosition(colunm, line);
    }


    public static void printPiece (Piece piece) {

      if (piece == null) {
        Console.Write("- ");
      } else {
        if (piece.color == Color.White) {
          Console.Write(piece);
        } else {
          ConsoleColor aux = Console.ForegroundColor;
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.Write(piece);
          Console.ForegroundColor = aux;
        }
        Console.Write(" ");
      }
    }
  }
}
