using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
  class Board
  {
    public int Lines { get; set; }
    public int Colunms { get; set; }
    private Piece[,] pieces;

    public Board (int lines, int colunms)
    {
      this.Lines = lines;
      this.Colunms = colunms;
      pieces = new Piece[lines, lines];
    }

    public Piece Piece (int line, int colunm)
    {
      return pieces[line, colunm];
    }

    public Piece Piece (Position pos)
    {
      return pieces[pos.Line, pos.Colunm];
    }

    public bool PieceExist (Position pos)
    {
      ValidatePosition(pos);
      return Piece(pos) != null;
    }

    public void SetPiece (Piece p, Position pos)
    {
      if (PieceExist(pos))
      {
        throw new BoardException("Already exist a piece in this position!");
      }
      pieces[pos.Line, pos.Colunm] = p;
      p.Position = pos;
    }

    public Piece RemovePiece (Position pos)
    {
      if (Piece(pos) == null)
      {
        return null;
      }

      Piece aux = Piece(pos);
      aux.Position = null;
      pieces[pos.Line, pos.Colunm] = null;
      return aux;
    }

    public bool ValidPosition (Position pos)
    {
      if (pos.Line < 0 || pos.Line >= Lines || pos.Colunm < 0 || pos.Colunm >= Colunms)
      {
        return false;
      }
      return true;
    }

    public void ValidatePosition (Position pos)
    {
      if (!ValidPosition(pos))
      {
        throw new BoardException("Invalid Position");
      }
    }
  }
}
