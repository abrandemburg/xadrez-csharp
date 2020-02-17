using board;

namespace chess {
  class ChessMatch {

    public Board board { get; private set; }
    private int turn;
    private Color activePlayer;

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

    private void setPieces() {
      board.setPiece(new Tower(board, Color.White), new ChessPosition('c',1).toPosition());
      board.setPiece(new Tower(board, Color.White), new ChessPosition('c',2).toPosition());      
    }
  }
}
