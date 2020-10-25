using System;

namespace FindNthNodeFromEnd
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

        public Node findNthFromEnd(Node head, int k)
        {
            Node temp = head;
            if (temp == null)
                return null;

            Node slow = head;
            Node fast = head;
            while(k > 0)
            {
                slow = slow.next;
                k--;
            }
            while (slow != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return fast;
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
            int k = 4;
            sl.printList(sl.head);
            Console.WriteLine();
            Console.WriteLine($"{k}th Node from end : ");
            Node nth = sl.findNthFromEnd(sl.head, k);
            Console.WriteLine(nth.data);
           
        }
    }
}
