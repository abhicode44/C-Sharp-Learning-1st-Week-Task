using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictonary_Operations
{
    internal class Dictonary_method
    {
        public Node Head;

        public void AddElements (object obj1 , object obj2)
        {   
            Node newNode = new Node (obj1 , obj2) ;
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


        public void RemoveElements(object obj1, object obj2)
        {
            if (Head == null)
            {
                Console.WriteLine("Dictionary is Empty");
            }

            else
            {
                Node temp = Head;
                Node temp2 = temp.Next;

            

                if (temp == Head && temp.Key == obj1 && temp.Value == obj2)
                {
                    Head = temp2;
                    temp.Key = null;
                    temp.Value = null;
                    temp.Next = null;
                }
                else
                {
                    while (temp2.Key != obj1 && temp2.Value != obj2)
                    {
                        temp2 = temp2.Next;
                        temp = temp.Next;

                    }
                    temp.Next = temp2.Next;
                    temp2.Key = null;
                    temp2.Value = null;
                }
            }
        }




        public void Disply ()
        {
            if (Head == null)
            {
                Console.WriteLine("Dictonary is Empty");
            }
            else
            {
                Node temp = Head;

                while (true)
                {
                    Console.WriteLine($"{temp.Key.ToString()} : {temp.Value.ToString()}");
                    if (temp.Next == null)
                    {
                        break;
                    }
                    temp = temp.Next;
                    if (temp.Next == null)
                    {
                        Console.WriteLine($"{temp.Key.ToString()} : {temp.Value.ToString()}");
                        break;
                    }
                }
            }   
        }
    }   

}
