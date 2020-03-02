using board;

namespace chess
{
  class Queen : Piece
  {

    public Queen (Board board, Color color) : base (board, color)
    {

    }

    public override string ToString ()
    {
      return "Q";
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

      pos.DefineValues(Position.Line + 1, Position.Colunm);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null || Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.Line = pos.Line + 1;
      }

      pos.DefineValues(Position.Line - 1, Position.Colunm);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null || Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.Line = pos.Line - 1;
      }

      pos.DefineValues(Position.Line, Position.Colunm + 1);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null || Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.Colunm = pos.Colunm + 1;
      }

      pos.DefineValues(Position.Line, Position.Colunm - 1);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null || Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.Line = pos.Line - 1;
      }

      pos.DefineValues(Position.Line - 1, Position.Colunm - 1);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
        {
          break;
        }

        pos.DefineValues(pos.Line - 1, pos.Colunm - 1);
      }

      pos.DefineValues(Position.Line + 1, Position.Colunm + 1);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Line + 1, pos.Colunm + 1);
      }

      pos.DefineValues(Position.Line - 1, Position.Colunm + 1);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Line - 1, pos.Colunm + 1);
      }

      pos.DefineValues(Position.Line + 1, Position.Colunm - 1);
      while (Board.ValidPosition(pos) && CanMove(pos))
      {
        mat[pos.Line, pos.Colunm] = true;
        if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
        {
          break;
        }
        pos.DefineValues(pos.Line + 1, pos.Colunm - 1);
      }

      return mat;
    }
  }
}
