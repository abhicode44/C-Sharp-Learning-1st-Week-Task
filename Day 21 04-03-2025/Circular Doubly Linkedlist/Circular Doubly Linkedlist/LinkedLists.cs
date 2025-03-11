using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Doubly_Linkedlist
{
    internal class LinkedLists
    {
        public Node Head;

        public void AddFirst(object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
                Head.Prev = Head;

            }
            else
            {
                Node temp = Head;
                while (temp.Next != Head )
                {
                    temp = temp.Next;
                }

                newNode.Next = Head; 
                newNode.Prev = temp;
                temp.Next = newNode;
                Head.Prev = newNode;

                Head = newNode;

            }
        }

        public void AddBetween(object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
                Head.Prev = Head;

            }

            else
            {
                Node temp = Head;
                

                string k = "Abhishek";
                object o = k;

                while (temp.Data != o && temp.Next != Head)
                {
                    temp = temp.Next;
                }

                if (temp.Data == o)
                {
                    Node temp2 = temp.Next;

                    newNode.Next = temp2;
                    newNode.Prev = temp;
                    temp.Next = newNode;
                    temp2.Prev = newNode;
                }
                

            }
        }
        
        public void AddLast (object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null) 
            {
                Head = newNode;
                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                Node temp = Head;

                
                while (temp.Next != Head)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
                newNode.Prev = temp;
                newNode.Next = Head;
                Head.Prev = newNode;
            }

        }


        public void Display()
        {
            Node temp = Head;

            if (Head == null)
            {
                Console.WriteLine("The list is empty.");

            }

            while (true)
            {
                Console.Write($" {temp.Data}");
                temp = temp.Next;

                if (temp == Head)
                {
                    break;
                }

            }

          }

    }
}

