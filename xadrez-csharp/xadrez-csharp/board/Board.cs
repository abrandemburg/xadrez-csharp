using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Board
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Piece[,] pieces;

        public Board(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pieces = new Piece[linhas, colunas];
        }
    }
}
