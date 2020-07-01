using DataStructures.Structures.Elements;
using System.Collections.Generic;

namespace DataStructures.Structures
{
    class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            Edges.Add(new Edge(from, to));
        }

        public int[,] GetMatrix()
        {
            int[,] matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach (var edge in Edges)
            {
                int row = edge.From.Number - 1;
                int column = edge.To.Number - 1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        public List<Vertex> GetVetexLists(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        public bool IsWay(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>();
            list.Add(start);

            for (int i = 0; i < list.Count; i++)
            {
                Vertex vertex = list[i];
                foreach (var v in GetVetexLists(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }

            return list.Contains(finish);
        }
    }
}
