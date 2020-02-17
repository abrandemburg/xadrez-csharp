using System;
using System.Collections.Generic;
using System.Text;

namespace board {
  class Piece {
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

    public void moveIncrement() {
      moveCounter++;
    }
  }
}
