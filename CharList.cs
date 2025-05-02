using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Клас, що реалізує двозв'язаний список символів
    /// </summary>
    public class CharList : IEnumerable<char>
    {
        /// <summary>
        /// Внутрішній клас вузла списку
        /// </summary>
        private class Node
        {
            public char Value;
            public Node? Next;
            public Node? Prev;

            public Node(char value)
            {
                Value = value;
            }
        }

        private Node? head;
        private Node? tail;
        private int count;

        /// <summary>
        /// Додає символ у кінець списку
        /// </summary>
        public void Add(char value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }

        /// <summary>
        /// Отримати символ за індексом
        /// </summary>
        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();

                Node current = head!;
                for (int i = 0; i < index; i++)
                    current = current.Next!;

                return current.Value;
            }
        }

        /// <summary>
        /// Реалізація підтримки foreach
        /// </summary>
        public IEnumerator<char> GetEnumerator()
        {
            Node? current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Видаляє елемент за індексом
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();

            Node? current = head;
            for (int i = 0; i < index; i++)
                current = current!.Next;

            RemoveNode(current!);
        }

        private void RemoveNode(Node node)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                head = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                tail = node.Prev;

            count--;
        }

        /// <summary>
        /// Знаходить індекс першого входження символу
        /// </summary>
        public int IndexOf(char target)
        {
            int index = 0;
            Node? current = head;
            while (current != null)
            {
                if (current.Value == target) return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Обчислює суму ASCII-кодів символів на непарних позиціях (0 - парна)
        /// </summary>
        public int SumAtOddPositions()
        {
            int sum = 0;
            int index = 0;
            Node? current = head;
            while (current != null)
            {
                if (index % 2 == 1)
                    sum += current.Value;
                current = current.Next;
                index++;
            }
            return sum;
        }

        /// <summary>
        /// Повертає новий список з елементами, які більші за задане значення
        /// </summary>
        public CharList FilterGreaterThan(char threshold)
        {
            CharList newList = new CharList();
            foreach (char c in this)
            {
                if (c > threshold)
                    newList.Add(c);
            }
            return newList;
        }

        /// <summary>
        /// Видаляє всі елементи, які більші за середнє значення
        /// </summary>
        public void RemoveGreaterThanAverage()
        {
            if (count == 0) return;

            int sum = 0;
            Node? current = head;
            while (current != null)
            {
                sum += current.Value;
                current = current.Next;
            }

            double avg = (double)sum / count;

            current = head;
            while (current != null)
            {
                Node? next = current.Next;
                if (current.Value > avg)
                    RemoveNode(current);
                current = next;
            }
        }
    }
}

