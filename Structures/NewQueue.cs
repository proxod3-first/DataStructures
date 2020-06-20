using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures
{
    class NewQueue<T> : IEnumerable<T>
    {
        Node<T> head, tail;

        public int Count { get; private set; }

        public NewQueue()
        {
            head = tail = null;
            Count = 0;
        }

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;

            if (Count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            Count--;
            return output;
        }

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }

        public bool IsEmpty { get { return Count == 0; } }

        public void Clear()
        {
            head = tail = null;
            Count = 0;
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

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}

