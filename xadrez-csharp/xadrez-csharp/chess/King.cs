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
      Piece p = board.piece(pos);
      return p == null || p.color != color;
    }

    public override bool[,] possibleMoves() {
      bool[,] mat = new bool[board.lines, board.colunms];

      Position pos = new Position(0, 0);

      //north
      pos.defineValues(position.line - 1, position.colunm);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //northeast
      pos.defineValues(position.line - 1, position.colunm + 1);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //east
      pos.defineValues(position.line, position.colunm + 1);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //southeast
      pos.defineValues(position.line + 1, position.colunm + 1);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //south
      pos.defineValues(position.line + 1, position.colunm);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //southwest
      pos.defineValues(position.line + 1, position.colunm - 1);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //west
      pos.defineValues(position.line, position.colunm - 1);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }

      //northwest
      pos.defineValues(position.line - 1, position.colunm -1);
      if (board.validPosition(pos) && canMove(pos)) {
        mat[pos.line, pos.colunm] = true;
      }
      
      return mat;
    }
  }
}
