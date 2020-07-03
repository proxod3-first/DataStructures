using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Structures
{
	public class SimpleSet<T> : IEnumerable
	{
		private readonly List<T> items;

		public int Count => items.Count;

		public bool IsEmpty => Count == 0;

		public SimpleSet()
		{
			items = new List<T>();
		}

		public SimpleSet(T item) : this()
		{
			items.Add(item);
		}

		public SimpleSet(IEnumerable<T> items)
		{
			this.items = items.ToList();
		}

		public bool Contains(T item) => items.Contains(item);

		public void Add(T item)
		{
			if (!Contains(item))
				items.Add(item);
		}

		public void Remove(T item)
		{
			// TODO: А если его нет без проверки?
			if (Contains(item))
				items.Remove(item);
		}

		public SimpleSet<T> Union(SimpleSet<T> otherSet)
		{
			// [1,2,3] union [2,4] = [1,2,3,4]

			//return new SimpleSet<T>(items.Union(otherSet.items));

			SimpleSet<T> newSetResult = new SimpleSet<T>();

			foreach (var item in otherSet.items)
			{
				if (!Contains(item))
				{
					newSetResult.Add(item);
				}
			}

			return newSetResult;
		}

		public SimpleSet<T> Difference(SimpleSet<T> otherSet)
		{
			// [1,2,3] difference [2,4] = [1,3] 
			// [2,4] difference [1,2,3] = [4] 

			// return new SimpleSet<T>(items.Except(otherSet.items));

			SimpleSet<T> newSetResult = new SimpleSet<T>(items);

			foreach (var item in otherSet.items)
			{
				newSetResult.Remove(item);
			}

			return newSetResult;
		}

		public SimpleSet<T> Intersection(SimpleSet<T> otherSet)
		{
			// [1,2,3] intersection [2,4] = [2]

			// return new SimpleSet<T>(items.Intersect(otherSet.items));

			SimpleSet<T> newSetResult = new SimpleSet<T>();
			SimpleSet<T> bigSet, smallSet;

			if (Count >= otherSet.Count)
			{
				bigSet = this;
				smallSet = otherSet;
			}
			else
			{
				smallSet = this;
				bigSet = otherSet;
			}

			foreach (var itemSmall in smallSet.items)
			{
				foreach (var itemBig in bigSet.items)
				{
					if (itemSmall.Equals(itemBig))
					{
						newSetResult.Add(itemSmall);
						break;
					}
				}
			}

			return newSetResult;
		}

		public SimpleSet<T> SymmetricDifference(SimpleSet<T> otherSet)
		{
			// symmetricDifference = union-intersection
			// [1,2,3] symmetricDifference [1,2,4] = [3,4]

			SimpleSet<T> newSetResult = new SimpleSet<T>();

			foreach (var item in items)
			{
				bool isEqual = false;

				foreach (var itemSet in otherSet.items)
				{
					if (item.Equals(itemSet))
					{
						isEqual = true;
						break;
					}
				}

				if (!isEqual)
				{
					newSetResult.Add(item);
				}
			}

			foreach (var itemSet in otherSet.items)
			{
				bool isEqual = false;

				foreach (var item in items)
				{
					if (itemSet.Equals(item))
					{
						isEqual = true;
						break;
					}
				}

				if (!isEqual)
				{
					newSetResult.Add(itemSet);
				}
			}

			return newSetResult;
		}

		public bool IsSubSet(SimpleSet<T> otherSet)
		{
			// [1,2,3] isSubSet [1,2] = true

			return items.All(item => otherSet.items.Contains(item));
		}

		IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

	}
}
