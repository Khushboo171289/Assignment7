using System;

namespace MergerTwoLLInPlace
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
        public void addNodeAtEnd(int d)
        {
            Node newNode = new Node(d);
            if (head == null)
            {
                head = newNode;
            }
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

        public void addNodeAtStart(int d)
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
    }
    class Program
    {
        public static Node MergeTwoLL(Node h1, Node h2, singleLinkedList output)
        {
            if (h1 == null)
                return h2;
            if (h2 == null)
                return h1;



            while (h1 != null || h2 != null)
            {
                if(h1 != null && h2 != null)
                {
                    if (h1.data < h2.data)
                    {
                        output.addNodeAtEnd(h1.data);
                        h1 = h1.next;
                    }
                    else if (h2.data < h1.data)
                    {
                        output.addNodeAtEnd(h2.data);
                        h2 = h2.next;
                    }
                }
                if (h1 != null && h2 == null)
                {
                    output.addNodeAtEnd(h1.data);
                    h1 = h1.next;
                }
                if (h1 == null && h2 != null)
                {
                    output.addNodeAtEnd(h2.data);
                    h2 = h2.next;
                }
            }

            return output.head;
        }

        static void Main(string[] args)
        {
            singleLinkedList input1 = new singleLinkedList();
            singleLinkedList input2 = new singleLinkedList();
            singleLinkedList output = new singleLinkedList();
            
            input1.addNodeAtEnd(10);
            input1.addNodeAtEnd(20);
            input1.addNodeAtEnd(30);
            input2.addNodeAtEnd(15);
            input2.addNodeAtEnd(17);

            input1.printList(input1.head);

            Console.WriteLine();
            input2.printList(input2.head);
            Console.WriteLine();
            Node headnew = MergeTwoLL(input1.head, input2.head, output);
            output.printList(headnew);

        }
    }
}
