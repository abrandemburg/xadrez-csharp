using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int colunms { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int colunms)
        {
            this.lines = lines;
            this.colunms = colunms;
            pieces = new Piece[lines, lines];
        }

        public Piece piece(int line, int colunm)
        {
            return pieces[line, colunm];
        }

        public void setPiece(Piece p, Position pos)
        {
            pieces[pos.line, pos.colunm] = p;
            p.position = pos;
        }
    }
}
