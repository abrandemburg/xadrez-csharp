using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess {
  class King : Piece {
    public King (Board board, Color color) : base(board, color) {
    }

    public override string ToString () {
      return "R";
    }

    private bool canMove(Position pos) {
      Piece p = Board.Piece(pos);
      return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves() {
      bool[,] mat = new bool[Board.Lines, Board.Colunms];

      Position pos = new Position(0, 0);

      //north
      pos.DefineValues(Position.Line - 1, Position.Colunm);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //northeast
      pos.DefineValues(Position.Line - 1, Position.Colunm + 1);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //east
      pos.DefineValues(Position.Line, Position.Colunm + 1);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //southeast
      pos.DefineValues(Position.Line + 1, Position.Colunm + 1);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //south
      pos.DefineValues(Position.Line + 1, Position.Colunm);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //southwest
      pos.DefineValues(Position.Line + 1, Position.Colunm - 1);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //west
      pos.DefineValues(Position.Line, Position.Colunm - 1);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }

      //northwest
      pos.DefineValues(Position.Line - 1, Position.Colunm -1);
      if (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
      }
      
      return mat;
    }
  }
}
