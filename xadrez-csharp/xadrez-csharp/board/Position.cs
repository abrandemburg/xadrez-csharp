namespace board
{
  class Position
  {
    public int Line { get; set; }
    public int Colunm { get; set; }

    public Position (int line, int colunm)
    {
      this.Line = line;
      this.Colunm = colunm;
    }

    public void DefineValues (int line, int colunm)
    {
      this.Line = line;
      this.Colunm = colunm;
    }

    public override string ToString ()
    {
      return Line + "," + Colunm;
    }

    public void Test ()
    {

    }
  }
}
