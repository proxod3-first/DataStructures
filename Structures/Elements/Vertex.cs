namespace DataStructures.Structures.Elements
{
    class Vertex
    {
        public int Number { get; }

        public Vertex(int number)
        {
            Number = number;
        }

        public override string ToString() => Number.ToString();
    }
}
