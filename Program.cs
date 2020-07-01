using DataStructures.Structures;
using System;

namespace DataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			// LinkedList<int> list = new LinkedList<int>();
			// NewStack<int> stack = new NewStack<int>();
			// HashTable<int> hashTable = new HashTable<int>(size);
			// NewDictionary<int, string> dict = new NewDictionary<int, string>(100);
			// NewQueue<int> queue = new NewQueue<int>();
			// NewQueueArray<int> queueArray = new NewQueueArray<int>(100);
			// BinaryTree<int> binaryTree = new BinaryTree<int>();
			// PrefixTree<int> prefixTree = new PrefixTree<int>();


		}

		#region Print HashTable
		public static void PrintHashTable<t>(HashTable<t> hashTable)
		{
			foreach (var item in hashTable.Items)
			{
				if (item.Nodes.Count != 0)
				{
					Console.Write(item.Key + ": ");

					foreach (var value in item.Nodes)
					{
						Console.Write(value + " ");
					}
					Console.WriteLine();
				}
			}
		}
		#endregion

	}
}
