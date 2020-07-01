namespace DataStructures.Structures.Elements
{
    class Edge
    {
        public Vertex From { get; }
        public Vertex To { get; }
        public int Weight { get; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight; //default: 1
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }

    }
}
