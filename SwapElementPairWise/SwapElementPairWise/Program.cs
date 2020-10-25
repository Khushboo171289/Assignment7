using System;

namespace SwapElementPairWise
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

        public void SwapPairwise(Node head)
        {
            Node temp = head;
            if (temp == null)
            {
                return;
            }

            while (temp != null && temp.next!= null)
            {
                int k = temp.data;
                temp.data = temp.next.data;
                temp.next.data = k;
                temp = temp.next.next;
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
            int k = 2;
            sl.printList();
            Console.WriteLine();
            //Console.WriteLine($"Rotate the Single linked list by {k} shfts counter clockwise");
            sl.SwapPairwise(sl.head);
            //sl.head = sl.ReverseEveryKNodes(sl.head, k);
            sl.printList();
        }
    }
}
