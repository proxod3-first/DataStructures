using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
	public class NewStack<T> : IEnumerable<T>
	{
		Node<T> head;
		public int Count { get; private set; }

		public NewStack()
		{
			head = null;
			Count = 0;
		}

		public bool IsEmpty => Count == 0;

		public T Peek()
		{
			return !IsEmpty ? head.Data : throw new NullReferenceException();
		}

		public void Push(T data)
		{
			Node<T> node = new Node<T>(data);
			node.Next = head;
			head = node;
			Count++;
		}

		public T Pop()
		{
			if (IsEmpty)
				throw new InvalidOperationException();

			Node<T> node = head;
			head = head.Next;
			Count--;
			return node.Data;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			Node<T> current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}

		}

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();


		public override string ToString()
		{
			return base.ToString();
		}
	}
}
