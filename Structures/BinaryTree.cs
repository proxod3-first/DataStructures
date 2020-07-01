using DataStructures.Structures.Elements;
using System;
using System.Collections.Generic;

namespace DataStructures.Structures
{
    public class BinaryTree<T> where T : IComparable, IComparable<T>
    {
        NodeBin<T> Root { get; set; }
        public int Count { get; private set; }

        public BinaryTree() { }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new NodeBin<T>(data);
                Count = 1;
            }
            else
            {
                Root.Add(data);
                Count++;
            }
        }

        public List<T> Preorder()
        {
            return Root == null ? new List<T>() : Preorder(Root);
        }

        public List<T> Postorder()
        {
            return Root == null ? new List<T>() : Postorder(Root);
        }

        public List<T> Inorder()
        {
            return Root == null ? new List<T>() : Inorder(Root);
        }

        private List<T> Preorder(NodeBin<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }

            return list;
        }

        private List<T> Postorder(NodeBin<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Postorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Postorder(node.Right));
                }

                list.Add(node.Data);
            }

            return list;
        }

        private List<T> Inorder(NodeBin<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(Inorder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(Inorder(node.Right));
                }
            }

            return list;
        }
    }
}

