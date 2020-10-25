using System;

namespace RotateSLLByKshift
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
        public void KRotation(int k)
        {
            if (k == 0)
                return;

            Node curr = head;
            int count = 1;
            while(count < k && curr !=null)
            {
                curr = curr.next;
                count++;
            }

            if (curr == null)
                return;

            Node KthNode = curr;
            while(curr.next!=null)
            {
                curr = curr.next;
            }

            curr.next = head;
            head = KthNode.next;
            KthNode.next = null;

        }

        public void printList()
        {
            Node temp = head;
            if (temp == null)
                Console.WriteLine("Empty list");

            while(temp!= null)
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
            for(int i =60; i >= 10; i=i-10)
            {
                sl.addNode(i);
            }
            int k = 4;
            sl.printList();
            Console.WriteLine();
            Console.WriteLine($"Rotate the Single linked list by {k} shfts counter clockwise");
            sl.KRotation(k);
            sl.printList();
           
        }
    }
    
}
