using board;

namespace chess {
  class ChessMatch {

    public Board board { get; private set; }
    public int turn { get; private set; }
    public Color activePlayer { get; private set; }
    public bool finished { get; private set; }

    public ChessMatch() {
      board = new Board(8, 8);
      turn = 1;
      activePlayer = Color.White;
      setPieces();
    }

    public void movePerform (Position origin, Position destination) {
      Piece p = board.removePiece(origin);
      p.moveIncrement();
      Piece recoveryPiece = board.removePiece(destination);
      board.setPiece(p, destination);
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

    private void setPieces() {
      board.setPiece(new Tower(board, Color.White), new ChessPosition('c', 1).toPosition());
      board.setPiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
      board.setPiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
      board.setPiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
      board.setPiece(new Tower(board, Color.White), new ChessPosition('e', 1).toPosition());
      board.setPiece(new King(board, Color.White), new ChessPosition('d', 1).toPosition());

      board.setPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
      board.setPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
      board.setPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
      board.setPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
      board.setPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
      board.setPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
    }
  }
}
