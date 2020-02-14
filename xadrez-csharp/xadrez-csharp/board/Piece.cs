using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveCounter { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position position, Board board, Color color)
        {
            this.position = position;
            this.color = color;
            this.board = board;
            this.moveCounter = 0;
        }
    }
}
