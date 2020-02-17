using board;

namespace chess {
  class ChessPosition {
    public char colunm { get; set; }
    public int line { get; set; }

    public ChessPosition (char colunm, int line) {
      this.colunm = colunm;
      this.line = line;
    }

    public Position toPosition() {
      return new Position(8 - line, colunm - 'a');
    }    

    public override string ToString () {
      return "" + colunm + line;
    }

  }
}



