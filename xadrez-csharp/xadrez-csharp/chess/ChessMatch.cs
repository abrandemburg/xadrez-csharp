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
    public bool check { get; private set; }



    public ChessMatch() {
      board = new Board(8, 8);
      turn = 1;
      activePlayer = Color.White;
      finished = false;
      pieces = new HashSet<Piece>();
      capturedPieces = new HashSet<Piece>();
      setPieces();
    }

    public Piece movePerform (Position origin, Position destination) {
      Piece p = board.removePiece(origin);
      p.moveIncrement();
      Piece capturedPiece = board.removePiece(destination);
      board.setPiece(p, destination);

      if (capturedPiece != null) {
        capturedPieces.Add(capturedPiece);
      }

      return capturedPiece;
    }

    public void undoPerform(Position origin, Position destination, Piece capturedPiece) {
      Piece p = board.removePiece(destination);
      p.moveDecrement();
      if(capturedPiece != null) {
        board.setPiece(capturedPiece, destination);
        capturedPieces.Remove(capturedPiece);
      }
      board.setPiece(p, origin);
    }

    public void play(Position origin, Position destination) {
      Piece capturedPiece = movePerform(origin, destination);

      if (inCheck(activePlayer)) {
        undoPerform(origin, destination, capturedPiece);
        throw new BoardException("You can't check your king!");
      }

      if (inCheck(rival(activePlayer))) {
        check = true;
      } else {
        check = false;
      }

      if (testCheckmate(rival(activePlayer))) {
        finished = true;
      }

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

    private Color rival (Color color) {
      if (color == Color.White) {
        return Color.Black;
      } else {
        return Color.White;
        ;
      }
    }

    private Piece king (Color color) {
      foreach (Piece p in inGamePieces(color)) {
        if (p is King) {
          return p;
        }
      }
      return null;
    }

    public bool inCheck(Color color) {
      Piece R = king(color);
      if (R == null) {
        throw new BoardException("No king of " + color + " in board");
      }

      foreach (Piece p in inGamePieces(rival(color))) {
        bool[,] mat = p.possibleMoves();
        if (mat[R.position.line, R.position.colunm]) {
          return true;
        }
      }
      return false;
    }

    public bool testCheckmate(Color color) {
      if (!inCheck(color)) {
        return false;
      }

      foreach (Piece p in inGamePieces(color)) {
        bool[,] mat = p.possibleMoves();
        for (int i = 0; i < board.lines; i++) {
          for (int j = 0; j < board.colunms; j++) {
            if (mat[i, j]) {
              Position origin = p.position;
              Position destination = new Position(i, j);
              Piece capturedPiece = movePerform(origin, destination);
              bool testCheck = inCheck(color);
              undoPerform(origin, destination, capturedPiece);
              if (!testCheck) {
                return false;
              }
            }
          }
        }
      }
      return true;
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
