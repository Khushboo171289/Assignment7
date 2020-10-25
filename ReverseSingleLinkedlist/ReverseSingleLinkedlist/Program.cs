using System;
using System.Security.Cryptography;

namespace ReverseSingleLinkedlist
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
        public void Reverse()
        {
            Node prev = null;
            Node curr = head;
            Node next = null;

            while(curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }

        public Node ReverseEveryKNodes(Node head, int k)
        {
            int count = 0;
            Node prev = null;
            Node curr = head;
            Node next = null;

            //reverse first k nodes
            while (count < k && curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                count++;
            }

            if (next != null)
                
                head.next = ReverseEveryKNodes(next, k);

            //head = prev;

            return prev;
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

        public void printList(Node head)
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            singleLinkedList sl = new singleLinkedList();
            for (int i = 60; i >= 10; i = i - 10)
            {
                sl.addNode(i);
            }
            int k = 3;
            sl.printList();
            Console.WriteLine();
            //Console.WriteLine($"Rotate the Single linked list by {k} shfts counter clockwise");
            sl.head = sl.ReverseEveryKNodes(sl.head, k);
            sl.printList(sl.head);

        }
    }
}
