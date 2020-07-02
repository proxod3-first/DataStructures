using DataStructures.Structures.Elements;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T> head, tail;

        public int Сount { get; private set; }

        public DoublyLinkedList() { }

        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            Сount++;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;

            if (Сount == 0)
                tail = head;
            else
                temp.Previous = node;
            Сount++;
        }

        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    break;

                current = current.Next;
            }

            if (current != null)
            {

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                Сount--;
                return true;
            }
            return false;
        }

        public bool IsEmpty => Сount == 0;

        public void Clear()
        {
            head = tail = null;
            Сount = 0;
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

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

    }
}

