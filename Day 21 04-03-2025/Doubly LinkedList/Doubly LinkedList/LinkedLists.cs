using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_LinkedList
{
    internal class LinkedLists
    {
        public Node Head;

        public void AddFirst(Object obj)
        {
            Node newNode = new Node(obj);
            if (Head == null)
            {
                Head = newNode;
            }
            else {

                newNode.Next = Head; 
                Head.Prev = newNode;
                Head = newNode;

            }
        }

        public void AddBetween (Object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
            }
            else 
            {
                Node temp = Head;
                Node temp2 = temp.Next; 

                int a = 2;
                object o = a;
                while (temp.Data == o)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Prev = temp;
                newNode.Next = temp2;
                temp2.Prev = newNode;

            }

        }


        public void AddLast(Object obj)
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
                newNode.Prev = temp;
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
