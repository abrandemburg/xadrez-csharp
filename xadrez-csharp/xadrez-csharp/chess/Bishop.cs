using board;

namespace chess {
  class Bishop : Piece {

    //constructor
    public Bishop (Board board, Color color) : base(board, color) { 
    }

    public override bool[,] PossibleMoves () {
      bool[,] mat = new bool[Board.Lines, Board.Colunms];

      Position pos = new Position(0,0);

      //NO
      pos.DefineValues(Position.Line -1, Position.Colunm -1);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }

        pos.DefineValues(pos.Line - 1, pos.Colunm - 1);        
      }

      //NE
      pos.DefineValues(Position.Line - 1, Position.Colunm + 1);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }

        pos.DefineValues(pos.Line - 1, pos.Colunm + 1);
      }

      //SO
      pos.DefineValues(Position.Line + 1, Position.Colunm - 1);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }

        pos.DefineValues(pos.Line + 1, pos.Colunm - 1);
      }

      //SE
      pos.DefineValues(Position.Line + 1, Position.Colunm + 1);
      while (Board.ValidPosition(pos) && canMove(pos)) {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
          break;
        }

        pos.DefineValues(pos.Line + 1, pos.Colunm + 1);
      }

      return mat;

    }

    public override string ToString() {
      return "B";
    }

    private bool canMove (Position pos) {
      Piece p = Board.Piece(pos);
      return p == null || p.Color != Color;
    }

    
  }
}
