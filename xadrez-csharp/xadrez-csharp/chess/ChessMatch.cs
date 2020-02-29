using board;
using System.Collections.Generic;

namespace chess {
  class ChessMatch {

    public Board board { get; private set; }
    public int turn { get; private set; }
    public Color activePlayer { get; private set; }
    public bool finished { get; private set; }
    private HashSet<Piece> pieces;
    private HashSet<Piece> capturedPieces;



    public ChessMatch() {
      board = new Board(8, 8);
      turn = 1;
      activePlayer = Color.White;
      finished = false;
      pieces = new HashSet<Piece>();
      capturedPieces = new HashSet<Piece>();
      setPieces();
    }

    public void movePerform (Position origin, Position destination) {
      Piece p = board.removePiece(origin);
      p.moveIncrement();
      Piece capturedPiece = board.removePiece(destination);
      board.setPiece(p, destination);

      if (capturedPiece != null) {
        capturedPieces.Add(capturedPiece);
      }
    }

    public void play(Position origin, Position destination) {
      movePerform(origin, destination);
      turn++;
      changePlayer();
    }

    public void validateOriginPosition(Position pos) {
      if (board.piece(pos) == null) {
        throw new BoardException("Piece not found.");
      }

      if (activePlayer != board.piece(pos).color) {
        throw new BoardException("Piece isn't yours.");
      }

      if (!board.piece(pos).foundPossibleMoves()) {
        throw new BoardException("Stuck piece!");
      }
    }

    public void validateDestinationPosition(Position origin, Position destination) {
      if (!board.piece(origin).canMoveTo(destination)) {
        throw new BoardException("Invalid destination");
      }
    }

    private void changePlayer() {
      if(activePlayer == Color.White) {
        activePlayer = Color.Black;
      } else {
        activePlayer = Color.White;
      }
    }

    public HashSet<Piece> capturedPiecesByColor(Color color) {
      HashSet<Piece> aux = new HashSet<Piece>();
      foreach (Piece p in capturedPieces) {
        if (p.color == color) {
          aux.Add(p);
        }
      }

      return aux;
    }

    public HashSet<Piece> inGamePieces(Color color) {
      HashSet<Piece> aux = new HashSet<Piece>();
      foreach (Piece p in pieces) {
        if (p.color == color) {
          aux.Add(p);
        }
      }
      aux.ExceptWith(capturedPiecesByColor(color));
      return aux;
    }

    public void setNewPiece(char colunm, int line, Piece piece) {
      board.setPiece(piece, new ChessPosition(colunm, line).toPosition());
      pieces.Add(piece);
    }

    private void setPieces() {

      setNewPiece('c', 1, new Tower(board, Color.White));
      setNewPiece('c', 2, new Tower(board, Color.White));
      setNewPiece('d', 2, new Tower(board, Color.White));
      setNewPiece('e', 2, new Tower(board, Color.White));
      setNewPiece('e', 1, new Tower(board, Color.White));
      setNewPiece('d', 1, new King(board, Color.White));

      setNewPiece('c', 8, new Tower(board, Color.Black));
      setNewPiece('c', 7, new Tower(board, Color.Black));
      setNewPiece('d', 7, new Tower(board, Color.Black));
      setNewPiece('e', 7, new Tower(board, Color.Black));
      setNewPiece('e', 8, new Tower(board, Color.Black));
      setNewPiece('d', 8, new King(board, Color.Black));

    }
  }
}
