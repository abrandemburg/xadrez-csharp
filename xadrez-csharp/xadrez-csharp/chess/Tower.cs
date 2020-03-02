using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess {
  class Tower : Piece {
    public Tower (Board board, Color color) : base(board, color) {
    }

    public override string ToString () {
      return "T";
    }

    private bool canMove (Position pos) {
      Piece p = Board.Piece(pos);
      return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves () {
      bool[,] mat = new bool[Board.Lines, Board.Colunms];

      Position pos = new Position(0, 0);

      //north
      pos.DefineValues(Position.Line - 1, Position.Colunm);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }
        pos.Line = pos.Line - 1;
      }

      //south
      pos.DefineValues(Position.Line + 1, Position.Colunm);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }
        pos.Line = pos.Line + 1;
      }

      //east
      pos.DefineValues(Position.Line, Position.Colunm + 1);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }
        pos.Colunm = pos.Colunm + 1;
      }

      //west
      pos.DefineValues(Position.Line, Position.Colunm - 1);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }
        pos.Colunm = pos.Colunm - 1;
      }

      return mat;
    }

  }
}
