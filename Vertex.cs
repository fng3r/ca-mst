namespace ca
{
    public class Vertex
    {
        public readonly int Number;
        public readonly int X;
        public readonly int Y;
        public Vertex(int number, int x, int y)
        {
            Number = number;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("V{0} ({1}, {2})", Number, X, Y);
        }
    }
}