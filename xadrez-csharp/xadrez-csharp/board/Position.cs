namespace board {
  class Position {
    public int line { get; set; }
    public int colunm { get; set; }

    public Position (int line, int colunm) {
      this.line = line;
      this.colunm = colunm;
    }

    public void defineValues(int line, int colunm) {
      this.line = line;
      this.colunm = colunm;
    }

    public override string ToString () {
      return line + "," + colunm;
    }

    public void test () {

    }
  }
}
