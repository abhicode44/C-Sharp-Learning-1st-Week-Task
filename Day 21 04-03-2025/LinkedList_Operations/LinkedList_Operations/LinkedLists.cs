using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Operations
{
    internal class LinkedLists
    {
        public Node Head;
        
        public void AddFirstNode (Object obj)
        {
            Node newNode = new Node (obj);
            if (Head == null) {
                Head = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;

            }
        }

        

        public void AddBetweenNode (Object obj)
        {
            Node newNode = new Node (obj);

            if (Head == null) {
                Head = newNode;
            }
            else
            {
                Node temp = Head;
                int a = 20;
                object o = a;
                while (temp.Data == o)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;

            }
        }

        public void AddLast(Object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
            }
            else {
                Node temp = Head;

                while (true)
                {
                    if (temp.Next == null)
                    {
                        newNode.Next = null;
                        temp.Next = newNode;
                        break;
                    }
                    temp = temp.Next;   

                }
            }
        }

        public void AddLast1(Object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node temp = Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;   
                }
                temp.Next = newNode;
                

            }
        }
        public void Display()
        {
            if (Head == null)
            {
                Console.WriteLine("No LinkedList");
            }
            else
            {
                Node temp = Head;

                while (true)
                {
                    Console.WriteLine(temp.Data);
                    if (temp.Next == null)
                    {
                        break;
                    }
                    temp = temp.Next;
                    if (temp.Next == null)
                    {
                        Console.WriteLine(temp.Data);
                        break;
                    }
                }
            }
        }

    }
}
