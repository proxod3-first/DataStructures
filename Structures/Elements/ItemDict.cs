namespace DataStructures.Structures.Elements
{
	class ItemDict<TKey, TValue>
	{
		public TKey Key { get; }
		public TValue Value { get; }

		public ItemDict(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}

		public override int GetHashCode() => Key.GetHashCode();

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
