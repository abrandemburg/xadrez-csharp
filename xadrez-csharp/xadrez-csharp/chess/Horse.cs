using board;

namespace chess
{
  class Horse : Piece
  {

    public Horse (Board board, Color color) : base(board, color)
    {

    }

    public override string ToString ()
    {
      return "H";
    }

    private bool CanMove (Position pos)
    {
      Piece p = Board.Piece(pos);
      return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves ()
    {
      bool[,] mat = new bool[Board.Lines, Board.Colunms];
      Position pos = new Position(0, 0);

      pos.DefineValues(Position.Line - 1, Position.Colunm - 2);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line - 1, Position.Colunm + 2);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line + 1, Position.Colunm - 2);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line + 1, Position.Colunm + 2);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line + 2, Position.Colunm + 1);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line + 2, Position.Colunm - 1);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line - 2, Position.Colunm + 1);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      pos.DefineValues(Position.Line - 2, Position.Colunm - 1);
      if (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
      }

      return mat;
    }
  }
}
