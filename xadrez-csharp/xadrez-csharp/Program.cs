﻿using System;
using board;
using chess;

namespace xadrez_csharp {
  class Program {
    static void Main (string[] args) {

      try {
        ChessMatch match = new ChessMatch();

        while (!match.finished) {

          try {

            Console.Clear();
            View.printMatch(match);            

            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = View.readChessPosition().toPosition();
            match.validateOriginPosition(origin);

            bool[,] possiblePositions = match.board.Piece(origin).PossibleMoves();

            Console.Clear();
            View.printBoard(match.board, possiblePositions);

            Console.WriteLine();
            Console.Write("Destination: ");
            Position destination = View.readChessPosition().toPosition();
            match.validateDestinationPosition(origin, destination);

            match.play(origin, destination);

          } catch (BoardException e) {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          }
        }

      } catch (BoardException e) {
        Console.WriteLine(e.Message);
      }


      Console.ReadLine();
    }
  }
}
