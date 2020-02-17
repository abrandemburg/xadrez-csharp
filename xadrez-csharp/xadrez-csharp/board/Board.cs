using System;
using System.Collections.Generic;
using System.Text;

namespace board {
  class Board {
    public int lines { get; set; }
    public int colunms { get; set; }
    private Piece[,] pieces;

    public Board (int lines, int colunms) {
      this.lines = lines;
      this.colunms = colunms;
      pieces = new Piece[lines, lines];
    }

    public Piece piece (int line, int colunm) {
      return pieces[line, colunm];
    }

    public Piece piece (Position pos) {
      return pieces[pos.line, pos.colunm];
    }

    public bool pieceExist (Position pos) {
      validatePosition(pos);
      return piece(pos) != null;
    }

    public void setPiece (Piece p, Position pos) {
      if (pieceExist(pos)) {
        throw new BoardException("Already exist a piece in this position!");
      }
      pieces[pos.line, pos.colunm] = p;
      p.position = pos;
    }

    public bool validPosition (Position pos) {
      if (pos.line < 0 || pos.line >= lines || pos.colunm < 0 || pos.colunm >= colunms) {
        return false;
      }
      return true;
    }

    public void validatePosition (Position pos) {
      if (!validPosition(pos)) {
        throw new BoardException("Invalid Position");
      }
    }
  }
}
