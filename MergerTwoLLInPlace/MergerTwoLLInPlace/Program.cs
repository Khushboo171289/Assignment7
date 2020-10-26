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
        public static Node MergerInPlace(Node h1, Node h2)
        {
            if (h1 == null)
                return h2;
            if (h2 == null)
                return h1;
            // start with the linked list whose head data is the smaller 
            if (h1.data < h2.data)
                return mergeUtil(h1, h2);
            else
                return mergeUtil(h2, h1);
        }

        private static Node mergeUtil(Node h1, Node h2)
        {
            //if list one have only one element
            if (h1.next == null)
            {
                h1.next = h2;
                return h1;
            }
            Node curr1 = h1;
            Node next1 = h1.next;
            Node curr2 = h2;
            Node next2 = h2.next;
            while(next1 != null && curr2 != null)
            {
                if (curr2.data >= curr1.data && curr2.data <= next1.data)
                {
                    next2 = curr2.next;
                    curr1.next = curr2;
                    curr2.next = next1;

                    curr1 = curr2;
                    curr2 = next2;
                }
                else if (next1.next != null)
                {
                    next1 = next1.next;
                    curr1 = curr1.next;
                }
                else
                {
                    next1.next = curr2;
                    return h1;
                }
            }
            return h1;     
        }

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
            //singleLinkedList output = new singleLinkedList();
            
            input1.addNodeAtEnd(10);
            input1.addNodeAtEnd(20);
            input1.addNodeAtEnd(30);
            input2.addNodeAtEnd(15);
            input2.addNodeAtEnd(17);

            input1.printList(input1.head);

            Console.WriteLine();
            input2.printList(input2.head);
            Console.WriteLine();

            Node headnew = MergerInPlace(input1.head, input2.head);
            Console.WriteLine("Mergerd list is");
            input1.printList(headnew);
            //Node headnew = MergeTwoLL(input1.head, input2.head, output);
            //output.printList(headnew);

        }
    }
}
