using System;
using System.Collections;

namespace DataStructures.Structures
{
	class NewQueueArray<T> : IEnumerable
	{
		T[] items;

		private T Head => items[Count <= 0 ? 0 : Count - 1];
		private T Tail => items[0];
		private int Size => items.Length;

		public int Count { get; private set; }

		public bool IsEmpty => Count == 0;

		public NewQueueArray(int size)
		{
			if (size <= 0)
				throw new ArgumentOutOfRangeException("Size cannot be negative", nameof(size));

			items = new T[size];
			Count = 0;
		}

		public void Enqueue(T data)
		{
			if (Count < Size)
			{
				var buffer = new T[Size];
				buffer[0] = data;
				for (int i = 0; i < Count; i++)
				{
					buffer[i + 1] = items[i];
				}

				items = buffer;
				Count++;
			}
			else
			{
				throw new IndexOutOfRangeException();
			}
		}

		public T Dequeue()
		{
			T item = Head;
			Count--;
			return item;
		}

		public T Peek() => !IsEmpty ? Head : throw new InvalidOperationException();

		public IEnumerator GetEnumerator()
		{
			foreach (var item in items)
			{
				if (default(T).Equals(item))
					yield return item;
			}
		}

	}
}
