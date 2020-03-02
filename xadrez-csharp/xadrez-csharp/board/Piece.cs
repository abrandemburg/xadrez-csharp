using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
  abstract class Piece
  {
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int MoveCounter { get; protected set; }
    public Board Board { get; protected set; }

    public Piece (Board board, Color color)
    {
      this.Position = null;
      this.Color = color;
      this.Board = board;
      this.MoveCounter = 0;
    }

    public abstract bool[,] PossibleMoves ();

    public bool FoundPossibleMoves ()
    {
      bool[,] mat = PossibleMoves();
      for (int i = 0; i < Board.Lines; i++)
      {
        for (int j = 0; j < Board.Colunms; j++)
        {
          if (mat[i, j])
          {
            return true;
          }
        }
      }
      return false;
    }

    public bool CanMoveTo (Position pos)
    {
      return PossibleMoves()[pos.Line, pos.Colunm];
    }

    public void MoveIncrement ()
    {
      MoveCounter++;
    }

    public void MoveDecrement ()
    {
      MoveCounter--;
    }
  }
}
