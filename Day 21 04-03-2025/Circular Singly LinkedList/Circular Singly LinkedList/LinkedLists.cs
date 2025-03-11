using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Singly_LinkedList
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
            }
            else
            {
                Node temp = Head;

                while (temp.Next != Head)
                {
                    temp = temp.Next;
                }

                newNode.Next = Head;
                temp.Next = newNode; 
                Head = newNode;
            }

        }

        public void AddBetween (object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;
            }
            else
            {  
                Node temp = Head;
                string a = "Abhishek";
                object o = a;
                
                while (temp.Data == o )
                {
                    temp = temp.Next;
                }

                newNode.Next = temp.Next;
                temp.Next = newNode;
               
            }

        }

        public void AddLast(object obj)
        {
            Node newNode = new Node(obj);

            if (Head == null)
            {
                Head = newNode;
                Head.Next = Head;  
            }
            else
            {
                Node temp = Head;

                
                while (temp.Next != Head)
                {
                    temp = temp.Next;
                }

                
                temp.Next = newNode;
                newNode.Next = Head;  
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
