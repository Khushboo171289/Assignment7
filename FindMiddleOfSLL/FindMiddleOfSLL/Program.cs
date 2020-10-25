using System;

namespace FindMiddleOfSLL
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
        public singleLinkedList()
        {
            head = null;
        }

        public void addNode(Node head, int d)
        {
            Node newNode = new Node(d);
            if (head == null)
                head = newNode;
            while(head.next != null)
            {
                head = head.next;
            }
            head.next = newNode;
        }
        public Node FindMidNode(Node head)
        {
            Node slow = head;
            Node fast = head;
            if (head == null)
                return null;
            if (head.next == null)
                return head;
            if(head != null)
            {
                while(fast != null && fast.next != null)
                {
                    fast = fast.next.next;
                    slow = slow.next;
                }

                return slow;
            }

            return slow;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            singleLinkedList sl = new singleLinkedList();
            sl.head = new Node(1);
            sl.addNode(sl.head, 2);
            sl.addNode(sl.head, 3);
            sl.addNode(sl.head, 4);
            sl.addNode(sl.head, 5);
            sl.addNode(sl.head, 6);
            //sl.addNode(sl.head, 7);
            Node mid = sl.FindMidNode(sl.head);
            Console.WriteLine(mid.data);

        }
    }
}
