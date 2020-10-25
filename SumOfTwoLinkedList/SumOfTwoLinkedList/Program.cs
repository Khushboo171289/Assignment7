using System;

namespace SumOfTwoLinkedList
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
                while(temp.next != null)
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
      
    }
    class Program
    {
        public static singleLinkedList SumOfLL(singleLinkedList s1, singleLinkedList s2)
        {
            if (s1.head == null)
                return s2;
            if (s2.head == null)
                return s1;

            Node h1 = s1.head;
            Node h2 = s2.head;

            singleLinkedList result = new singleLinkedList();

            int carry = 0;
            int sum = 0;
            while (h1 != null || h2 != null)
            {
                if (h1 != null && h2 != null)
                {                    
                    sum = h1.data + h2.data + carry;
                    carry = 0;
                    if(sum >= 10)
                    {
                        result.addNodeToEnd(sum % 10);
                        carry = sum / 10;
                    }
                    else if(sum < 10)
                    {
                        result.addNodeToEnd(sum);
                    }
                    h1 = h1.next;
                    h2 = h2.next;

                }

                if (h1 != null && h2 == null)
                {
                    sum = h1.data + carry;
                    carry = 0;
                    if (sum >= 10)
                    {
                        result.addNodeToEnd(sum % 10);
                        carry = sum / 10;
                    }
                    else if (sum < 10)
                    {
                        result.addNodeToEnd(sum);
                    }
                    h1 = h1.next;

                }

                if (h1 == null && h2 != null)
                {
                    sum = h2.data + carry;
                    carry = 0;
                    if (sum >= 10)
                    {
                        result.addNodeToEnd(sum % 10);
                        carry = sum / 10;
                    }
                    else if (sum < 10)
                    {
                        result.addNodeToEnd(sum);
                    }
                    h2 = h2.next;
                }                
            }

            if (carry > 0 )
            {
                result.addNodeToEnd(carry);
            }

            return result;
        }


        static void Main(string[] args)
        {
            singleLinkedList s1 = new singleLinkedList();
            singleLinkedList s2 = new singleLinkedList();

            s1.addNode(5);
            s1.addNode(9);
            s1.addNode(9);

            s2.addNode(2);
            s2.addNode(9);
            s2.addNode(9);

            s1.printList();
            Console.WriteLine();
            s2.printList();
            Console.WriteLine();
            singleLinkedList result = SumOfLL(s1, s2);
            result.printList();
        }
    }
}
