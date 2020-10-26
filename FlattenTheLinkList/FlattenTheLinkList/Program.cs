using System;

namespace FlattenTheLinkList
{
    public class Node
    {
        public int data;
        public Node next;
        public Node bottom;
        public Node(int d)
        {
            this.data = d;
            this.next = null;
            this.bottom = null;
        }
    }

    public class MultiLevelLL
    {
        public Node head;    
        public Node AddNode(int d, Node head)
        {
            Node newNode = new Node(d);
            newNode.bottom = head;
            head = newNode;
            return head;
        }

        public void printList()
        {
            Node temp = head;
            Node tempNext = head;
            while(tempNext != null)
            {
                while (temp != null)
                {
                    Console.Write(temp.data + "-->");
                    temp = temp.bottom;
                }
                Console.WriteLine();
                tempNext = tempNext.next;
                temp = tempNext;
            }
            
        }

        public Node Merge(Node a, Node b)
        {
            //Base case to return the other link list if one LL is empty
            if (a == null)
                return b;

            if (b == null)
                return a;
            //Node to store the merged LL
            Node result;

            if(a.data < b.data)
            {
                result = a;
                result.bottom = Merge(a.bottom, b);
            }else
            {
                result = b;
                result.bottom = Merge(a, b.bottom);
            }
            result.next = null;
            return result;
        }

        public Node FlattenTheLL(Node head)
        {
            //Base case to check if list is empty or have only one element.
            if (head == null || head.next == null)
                return head;
            //recursively call the flatten fuction for all the list
            head.next = FlattenTheLL(head.next);

            // Merger the two link list 
            head = Merge(head, head.next);
            return head;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            MultiLevelLL L = new MultiLevelLL();
            L.head = L.AddNode(30, L.head);
            L.head = L.AddNode(8, L.head);
            L.head = L.AddNode(7, L.head);
            L.head = L.AddNode(5, L.head);

            L.head.next = L.AddNode(20, L.head.next);
            L.head.next = L.AddNode(10, L.head.next);

            L.head.next.next = L.AddNode(50, L.head.next.next);
            L.head.next.next = L.AddNode(22, L.head.next.next);
            L.head.next.next = L.AddNode(19, L.head.next.next);

            L.head.next.next.next = L.AddNode(45, L.head.next.next.next);
            L.head.next.next.next = L.AddNode(40, L.head.next.next.next);
            L.head.next.next.next = L.AddNode(35, L.head.next.next.next);
            L.head.next.next.next = L.AddNode(28, L.head.next.next.next);

            L.printList();

            Node newhead = L.FlattenTheLL(L.head);

            L.printList();
        }
    }
}
