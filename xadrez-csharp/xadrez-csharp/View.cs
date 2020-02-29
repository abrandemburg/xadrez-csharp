using board;
using chess;
using System;
using System.Collections.Generic;

namespace xadrez_csharp {
  class View {

    public static void printMatch (ChessMatch match) {
      printBoard(match.board);
      Console.WriteLine();
      printCapturedPieces(match);
      Console.WriteLine();
      Console.WriteLine("Turn: " + match.turn);
      Console.WriteLine("Waiting player: " + match.activePlayer);
    }

    private static void printCapturedPieces (ChessMatch match) {
      Console.WriteLine("Captured pieces: ");
      Console.Write("White: ");
      printCollection(match.capturedPiecesByColor(Color.White));
      Console.WriteLine();
      Console.Write("Black: ");
      printCollection(match.capturedPiecesByColor(Color.Black));
    }

    private static void printCollection (HashSet<Piece> collection) {
      Console.Write("[");
      foreach (Piece p in collection) {
        Console.Write(p + " ");
      }
      Console.Write("]");
    }

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
