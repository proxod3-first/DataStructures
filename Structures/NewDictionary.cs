using DataStructures.Structures.Elements;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures
{
	class NewDictionary<TKey, TValue> : IEnumerable
	{
		ItemDict<TKey, TValue>[] Items;

		List<TKey> Keys = new List<TKey>();

		public int Size { get; private set; }

		public NewDictionary(int size)
		{
			if (size <= 0)
				throw new ArgumentOutOfRangeException("Size cannot be negative", nameof(size));

			Size = size;
			Items = new ItemDict<TKey, TValue>[Size];
		}

		#region Add
		public void Add(ItemDict<TKey, TValue> item)
		{
			int hashCode = GetHash(item.Key);

			if (Keys.Contains(item.Key))
				return;

			if (Items[hashCode] == null)
			{
				Keys.Add(item.Key);
				Items[hashCode] = item;
			}
			else
			{
				bool IsPlaced = false;

				for (int i = 0; i < Size; i++)
				{
					if (Items[i] == null)
					{
						Keys.Add(item.Key);
						Items[i] = item;
						IsPlaced = true;
						break;
					}

					if (Items[i].Key.Equals(item.Key))
						return;
				}

				if (!IsPlaced)
				{
					for (int i = 0; i < hashCode; i++)
					{
						if (Items[i] == null)
						{
							Keys.Add(item.Key);
							Items[i] = item;
							IsPlaced = true;
							break;
						}

						if (Items[i].Key.Equals(item.Key))
							return;
					}

					if (!IsPlaced)
						throw new Exception("Словарь полон!");
				}

			}

		}
		#endregion

		#region Search
		public TValue Search(TKey key)
		{
			if (Keys.Contains(key))
				return default(TValue);

			int hashCode = GetHash(key);

			if (Items[hashCode] == null)
			{
				foreach (var item in Items)
				{
					if (item.Key.Equals(key))
						return item.Value;
				}

				return default(TValue);
			}


			if (Items[hashCode].Key.Equals(key))
			{
				return Items[hashCode].Value;
			}
			else
			{
				bool IsPlaced = false;

				for (int i = hashCode; i < Size; i++)
				{
					if (Items[i] == null && !Keys.Contains(key))
					{
						break;
					}

					if (Items[i].Key.Equals(key))
					{
						return Items[i].Value;
					}
				}

				if (!IsPlaced)
				{
					for (int i = 0; i < hashCode; i++)
					{
						if (Items[i] == null && !Keys.Contains(key))
						{
							return default(TValue);
						}

						if (Items[i].Key.Equals(key))
						{
							return Items[i].Value;
						}
					}
				}
			}

			return default(TValue);
		}
		#endregion

		#region Remove
		public void Remove(TKey key)
		{
			if (!Keys.Contains(key))
				return;

			var hash = GetHash(key);

			if (Items[hash] == null)
			{
				for (var i = 0; i < Size; i++)
				{
					if (Items[i] != null && Items[i].Key.Equals(key))
					{
						Items[i] = null;
						Keys.Remove(key);
						return;
					}
				}

				return;
			}

			if (Items[hash].Key.Equals(key))
			{
				Items[hash] = null;
				Keys.Remove(key);
			}
			else
			{
				var IsPlaced = false;

				for (var i = hash; i < Size; i++)
				{
					if (Items[i] == null && !Keys.Contains(key))
						return;

					if (Items[i].Key.Equals(key))
					{
						Items[i] = null;
						Keys.Remove(key);
						return;
					}
				}

				if (!IsPlaced)
				{
					for (var i = 0; i < hash; i++)
					{
						if (Items[i] == null && !Keys.Contains(key))
							return;

						if (Items[i].Key.Equals(key))
						{
							Items[i] = null;
							Keys.Remove(key);
							return;
						}
					}
				}
			}
		}
		#endregion

		public IEnumerator GetEnumerator()
		{
			foreach (var item in Items)
			{
				if (item != null)
				{
					yield return item;
				}
			}
		}

		private int GetHash(TKey key) => key.GetHashCode() % Size;
	}

}
