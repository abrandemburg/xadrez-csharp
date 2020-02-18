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
      Piece p = board.piece(pos);
      return p == null || p.color != color;
    }

    public override bool[,] possibleMoves () {
      bool[,] mat = new bool[board.lines, board.colunms];

      Position pos = new Position(0, 0);

      //north
      pos.defineValues(position.line - 1, position.colunm);
      while (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
        if (board.piece(pos) != null && board.piece(pos).color != color) {
          break;
        }
        pos.line = pos.line - 1;
      }

      //south
      pos.defineValues(position.line + 1, position.colunm);
      while (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
        if (board.piece(pos) != null && board.piece(pos).color != color) {
          break;
        }
        pos.line = pos.line + 1;
      }

      //east
      pos.defineValues(position.line, position.colunm + 1);
      while (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
        if (board.piece(pos) != null && board.piece(pos).color != color) {
          break;
        }
        pos.colunm = pos.colunm + 1;
      }

      //west
      pos.defineValues(position.line, position.colunm - 1);
      while (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
        if (board.piece(pos) != null && board.piece(pos).color != color) {
          break;
        }
        pos.colunm = pos.colunm - 1;
      }

      return mat;
    }

  }
}
