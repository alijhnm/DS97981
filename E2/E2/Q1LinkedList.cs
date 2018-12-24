using System;
using System.Collections;
using System.Collections.Generic;

namespace E2
{

    public class Q1LinkedList
    {
        public class Node
        {
            public Node(int key) { this.Key = key;  }
            public int Key;
            public Node Next = null;
            public Node Prev = null;
            public override string ToString() => ToString(4);

            public string ToString(int maxDepth)
            {
                return maxDepth == 1 || Next == null ?
                    $"{Key.ToString()}" + (Next != null ? "..." : string.Empty) :
                    $"{Key.ToString()} {Next.ToString(maxDepth - 1)}";
            }
        }

        private Node Head = null;
        private Node Tail = null;

        public void Insert(int key)
        {
            if (Head == null)
            {
                Head = Tail = new Node(key);
            }
            else
            {
                var newNode = new Node(key);
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public override string ToString() => Head.ToString();

        public void Reverse()
        {
            if (Head.Equals(Tail))
            {
                return;
            }

            else if (Head.Next.Equals(Tail))
            {
                Node tmp = Head;
                tmp.Next = null;
                tmp.Prev = null;
                Head = Tail;
                Head.Prev = null;
                Head.Next = tmp;
                tmp.Prev = Head;
                tmp.Next = null;
                Tail = tmp;
                return;
            }

            int head = Head.Key;
            Node tail = new Node(Tail.Key);

            Head = Head.Next;
            Head.Prev = null;

            Tail = Tail.Prev;
            Tail.Next = null;

            Reverse();

            Head.Prev = tail;
            tail.Next = Head;
            Head = tail;

            Insert(head);

        }

        public void DeepReverse()
        {

            Node newHead;
            Node newTail;

            while (true)
            {
                if (Head.Equals(Tail))
                {
                    break;
                }
                else if (Head.Next.Equals(Tail))
                {
                    Node tmp = Head;
                    tmp.Next = null;
                    tmp.Prev = null;

                    Head = Tail;
                    Head.Prev = null;
                    Head.Next = tmp;

                    tmp.Prev = Head;
                    tmp.Next = null;
                    Tail = tmp;

                    break;
                }
                newHead = Tail;
                Tail = Tail.Prev;
                newHead.Prev = null;

                newTail = Head;
                Head = Head.Next;
                newTail.Prev = null;

                Head.Prev = newHead;
                Tail.Next = newTail;
            }
            Head = Head.Prev;
            Tail = Tail.Next;
        }

        public IEnumerable<int> GetForwardEnumerator()
        {
            var it = this.Head;
            while (it != null)
            {
                yield return it.Key;
                it = it.Next;
            }
        }

        public IEnumerable<int> GetReverseEnumerator()
        {
            var it = this.Tail;
            while (it != null)
            {
                yield return it.Key;
                it = it.Prev;
            }
        }
    }
}