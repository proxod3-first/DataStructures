using DataStructures.Structures.Elements;

namespace DataStructures.Structures
{
    // Another name: Trie
    public class PrefixTree<T>
    {
        NodePrefix<T> root;
        public int Count { get; set; }

        public PrefixTree()
        {
            root = new NodePrefix<T>('\0', default(T), "");
            Count = 1;
        }

        public void Add(string key, T data) => AddNode(key, data, root);

        private void AddNode(string key, T data, NodePrefix<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                }
            }
            else
            {
                char symbol = key[0];
                var subNode = node.TryFind(symbol);
                if (subNode == null)
                {
                    var newNode = new NodePrefix<T>(key[0], data, node.Prefix + key[0]);
                    node.SubNodes.Add(key[0], newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
                else
                {
                    AddNode(key.Substring(1), data, subNode);
                }
            }

        }

        public void Remove(string key) => RemoveNode(key, root);

        private void RemoveNode(string key, NodePrefix<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                node.IsWord = false;
            }
            else
            {
                var subNode = node.TryFind(key[0]);
                if (subNode != null)
                {
                    RemoveNode(key.Substring(1), subNode);
                }
            }
        }

        public bool TrySearch(string key, out T value) => SearchNode(key, root, out value);

        private bool SearchNode(string key, NodePrefix<T> node, out T value)
        {
            value = default(T);
            bool result = false;

            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    result = true;
                }
            }
            else
            {
                var subNode = node.TryFind(key[0]);
                if (subNode != null)
                {
                    result = SearchNode(key.Substring(1), subNode, out value);
                }
            }

            return result;
        }

    }
}

