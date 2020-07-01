using System.Collections.Generic;

namespace DataStructures.Structures.Elements
{
    class NodePrefix<T>
    {
        public T Data { get; set; }
        public char Symbol { get; set; }
        public string Prefix { get; set; }
        public bool IsWord { get; set; }

        public Dictionary<char, NodePrefix<T>> SubNodes { get; }

        public NodePrefix(char symbol, T data, string prefix)
        {
            Symbol = symbol;
            Data = data;
            Prefix = prefix;
            SubNodes = new Dictionary<char, NodePrefix<T>>();
        }

        public override string ToString()
        {
            return $"{Data} [{SubNodes.Count}] ({Prefix})";
        }

        public NodePrefix<T> TryFind(char symbol)
        {
            return (SubNodes.TryGetValue(symbol, out NodePrefix<T> value)) ? value : null;
        }

        public override bool Equals(object obj)
        {
            return (obj is Node<T> item) ? Data.Equals(item) : false;
        }
    }
}

