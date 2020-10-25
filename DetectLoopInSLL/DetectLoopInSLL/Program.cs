using System;
using System.Collections.Generic;

namespace DetectLoopInSLL
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
        public bool DetectLoopNoExtraSpace(Node head)
        {
            Node slow = head;
            Node fast = head;
            if (slow == null)
                return false;

            while (slow != null && fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
               if(slow == fast)
                {
                    return true;
                }
            }
            return false;

        }

        public bool DetectLoop(Node head)
        {
            Node temp = head;
            if (temp == null)
                return false;

            HashSet<Node> map = new HashSet<Node>();
            while(temp != null)
            {
                if (map.Contains(temp))
                {
                    return true;
                }
                
                map.Add(temp);
                temp = temp.next;
            }
            return false;

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

            //sl.head.next.next.next.next.next.next = sl.head.next.next;
            //sl.printList(sl.head);
            Console.WriteLine();
           // bool loop = sl.DetectLoop(sl.head);
            bool loop = sl.DetectLoopNoExtraSpace(sl.head);
            if (loop)
            {
                Console.WriteLine("List contains the loop");
            }
            else
            {
                Console.WriteLine("List do not contain the loop");
            }
        }
            
      }
    }
