using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SLLIsPalindrom
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            this.data = d;
            this.next = null;
        }
    }
    public class singleLinkedList
    {
        public Node head;
        public void addNode(int d)
        {
            Node newNode = new Node(d);
            newNode.next = head;
            head = newNode;
        }
        public void addNodeToEnd(int d)
        {
            Node newNode = new Node(d);
            if (head == null)
                head = newNode;
            else
            {
                Node temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newNode;
            }

        }

        public void printList()
        {
            Node temp = head;
            if (temp == null)
                Console.WriteLine("Empty list");

            while (temp != null)
            {
                Console.Write(temp.data + "-->");
                temp = temp.next;
            }
        }

        public bool IsPalindrom(Node head)
        {
            if (head == null)
                return false;
            if (head.next == null)
                return true;
            //Node mid;
            Node slow = head;
            Node fast = head;
            Stack<int> map = new Stack<int>();
            map.Push(slow.data);
            // function to return mid element
            while(fast != null && fast.next != null && fast.next.next != null)
            {
                
                    fast = fast.next.next;
                    slow = slow.next;
                    map.Push(slow.data);
                
            }

            if (fast.next != null)
            {
                while(map.Count > 0)
                {
                    slow = slow.next;
                    if(map.Peek() != slow.data)
                    {
                        return false;
                    }
                    map.Pop();
                }
                return true;
            }
            else if(fast.next == null)
            {
                map.Pop();
                while(map.Count > 0)
                {
                    slow = slow.next;
                    if (map.Peek() != slow.data)
                    {
                        return false;
                    }
                    map.Pop();
                }
                return true;
            }

            return true;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
           singleLinkedList sl = new singleLinkedList();
           sl.addNodeToEnd(1);
           sl.addNodeToEnd(2);
           sl.addNodeToEnd(3);
           sl.addNodeToEnd(3);
           sl.addNodeToEnd(2);
           sl.addNodeToEnd(1);
           Console.WriteLine();
           Console.WriteLine(sl.IsPalindrom(sl.head));
        }
    }
}
