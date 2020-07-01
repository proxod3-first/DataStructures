using System;

namespace DataStructures.Structures.Elements
{
    class NodeBin<T> : IComparable<T>, IComparable
        where T : IComparable, IComparable<T>
    {
        public T Data { get; private set; }
        public NodeBin<T> Left { get; private set; }
        public NodeBin<T> Right { get; private set; }

        public NodeBin(T data)
        {
            Data = data;
        }

        public NodeBin(T data, NodeBin<T> left, NodeBin<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public void Add(T data)
        {
            var node = new NodeBin<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.Add(data);
            }
            else
            {
                if (Right == null)
                    Right = node;
                else
                    Right.Add(data);
            }
        }

        public int CompareTo(object obj)
        {
            return (obj is Node<T> item) ? Data.CompareTo(item) : throw new ArgumentException("Types aren't equals");
        }

        public int CompareTo(T other) => Data.CompareTo(other);

        public override string ToString() => Data.ToString();
    }
}
