using DataStructures.Structures.Elements;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures
{
    public class Deque<T> : IEnumerable<T>
    {
        DoublyNode<T> head, tail;

        public int Count { get; private set; }

        public Deque() { }

        public Deque(T data)
        {
            SetHead(data);
        }

        public T First => IsEmpty ? head.Data : throw new InvalidOperationException();

        public T Last => IsEmpty ? tail.Data : throw new InvalidOperationException();

        private void SetHead(T data)
        {
            var item = new DoublyNode<T>(data);
            head = item;
            tail = item;
            Count = 1;
        }

        public bool IsEmpty => Count == 0;

        public void Clear()
        {
            head = tail = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void PushBack(T data)
        {
            if (Count == 0)
            {
                SetHead(data);
                return;
            }

            var item = new DoublyNode<T>(data);
            item.Next = tail;
            tail.Previous = item;
            tail = item;
            Count++;
        }

        public void PushFront(T data)
        {
            if (Count == 0)
            {
                SetHead(data);
                return;
            }

            var item = new DoublyNode<T>(data);
            item.Previous = head;
            head.Next = item;
            head = item;
            Count++;
        }

        public T PopBack()
        {
            if (Count > 0)
            {
                var result = tail.Data;
                var current = tail.Next;
                current.Previous = null;
                tail = current;
                Count--;
                return result;
            }
            return default(T);
        }

        public T PopFront()
        {
            if (Count > 0)
            {
                var result = head.Data;
                var current = head.Previous;
                current.Next = null;
                head = current;
                Count--;
                return result;
            }
            return default(T);
        }

        public T PeekBack() => tail.Data;

        public T PeekFront() => head.Data;

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

    }
}

