using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
	public class LinkedList<T> : IEnumerable<T>
	{
		Node<T> head;
		Node<T> tail;
		public int Count { get; private set; }

		public LinkedList()
		{
			head = tail = null;
			Count = 0;
		}
		public void Add(T data)
		{
			Node<T> note = new Node<T>(data);

			if (head == null)
				head = note;
			else
				tail.Next = note;

			tail = note;
			Count++;
		}

		public void AppendFirst(T data)
		{
			Node<T> node = new Node<T>(data);
			node.Next = head;
			head = node;
			if (Count == 0)
				tail = head;
			Count++;
		}

		public bool Contains(T data)
		{
			Node<T> current = head;
			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;
				current = current.Next;
			}
			return false;
		}

		public void Clear()
		{
			head = tail = null;
			Count = 0;
		}

		public bool Remove(T data)
		{
			Node<T> current = head;
			Node<T> previous = null;
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					if (previous != null)
					{
						if (current.Next == null)
							tail = previous;

						previous.Next = current.Next;
					}
					else
					{
						head = head.Next;
						if (head == null)
							tail = null;
					}

					Count--;
					return true;
				}
				previous = current;
				current = current.Next;
			}
			return false;
		}

		public T this[int index]
		{
			get
			{
				if (index < Count)
				{
					Node<T> current = head;
					int i = 0;
					while (current != null)
					{
						if (i == index)
							return current.Data;
						current = current.Next;
						i++;
					}
				}

				throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsEmpty() => Count == 0;

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
