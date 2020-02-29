using System;
using System.Collections.Generic;
using System.Text;

namespace board {
  abstract class Piece {
    public Position position { get; set; }
    public Color color { get; protected set; }
    public int moveCounter { get; protected set; }
    public Board board { get; protected set; }

    public Piece (Board board, Color color) {
      this.position = null;
      this.color = color;
      this.board = board;
      this.moveCounter = 0;
    }

    public abstract bool[,] possibleMoves();

    public bool foundPossibleMoves() {
      bool[,] mat = possibleMoves();
      for (int i = 0; i < board.lines; i++) {
        for (int j = 0; j < board.colunms; j++) {
          if (mat[i,j]) {
            return true;
          }
        }
      }
      return false;
    }

    public bool canMoveTo(Position pos) {
      return possibleMoves()[pos.line, pos.colunm];
    }

    public void moveIncrement() {
      moveCounter++;
    }
  }
}
