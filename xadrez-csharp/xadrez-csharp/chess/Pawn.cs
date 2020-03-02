using board;

namespace chess
{
  class Pawn : Piece
  {

    public Pawn (Board board, Color color) : base(board, color)
    {

    }

    public override string ToString ()
    {
      return "P";
    }

    private bool hasRival (Position pos)
    {
      Piece p = Board.Piece(pos);
      return p != null && p.Color != Color;
    }

    private bool freeCell (Position pos)
    {
      return Board.Piece(pos) == null;
    }

    public override bool[,] PossibleMoves ()
    {
      bool[,] mat = new bool[Board.Lines, Board.Colunms];

      Position pos = new Position(0, 0);

      if (Color == Color.White)
      {
        pos.DefineValues(Position.Line - 2, Position.Colunm);
        if (Board.ValidPosition(pos) && MoveCounter == 0 && freeCell(pos))
        {
          mat[pos.Line, pos.Colunm] = true;
        }

        pos.DefineValues(Position.Line - 1, Position.Colunm);
        if (Board.ValidPosition(pos) && freeCell(pos))
        {
          mat[pos.Line, pos.Colunm] = true;
        }

        pos.DefineValues(Position.Line - 1, Position.Colunm - 1);
        if (Board.ValidPosition(pos) && hasRival(pos))
        {
          mat[pos.Line, pos.Colunm] = true;
        }
      }

      return mat;
    }
  }
}
