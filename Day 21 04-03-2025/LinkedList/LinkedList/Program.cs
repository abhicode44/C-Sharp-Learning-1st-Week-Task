using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();

        // Add Elements in the Linkedlist 
        list.AddFirst(10);
        list.AddLast(20);
        list.AddLast(30);
        list.AddLast(40);
        list.AddLast(50);
        list.AddLast(60);
        list.AddLast(70);

        Console.WriteLine($"Linkedlist Elements :- ");

        foreach (int i in list)
        {
            Console.WriteLine(i);
        }


        //To check if the element is present in the LinkedList or not.

        Console.WriteLine();
        Console.WriteLine("The element 20 is present in the LinkedList: "
                        + list.Contains(20));



        // To remove specific node from the linked list 
        Console.WriteLine();

        list.Remove(list.First);
        Console.WriteLine("Linked List After Removing First Node :- ");
        foreach (int i in list)
        {
            Console.WriteLine(i);
        }

        // To remove specific element from the linked list 

        Console.WriteLine();

        list.Remove(40);
        Console.WriteLine("Linked List After Removing Specific Elements 40  :- ");
        foreach (int i in list)
        {
            Console.WriteLine(i);
        }

        // To Remove Element Using FirstRemove Method 

        Console.WriteLine();

        list.RemoveFirst();
        Console.WriteLine("Remove Element Using FirstRemove Method");
        foreach (int i in list)
        {
            Console.WriteLine(i);
        }

        //To Remove Element using RemoveLast Method
        Console.WriteLine();

        list.RemoveLast();
        Console.WriteLine("Remove Element using RemoveLast Method");
        foreach (int i in list)
        {
            Console.WriteLine(i);
        }

        // To clear all the nodes using clear method
        Console.WriteLine();

        list.Clear();
        Console.WriteLine("clear all the nodes using clear method");

        Console.WriteLine(
            "\nNumber of elements in the list after clearing: "
            + list.Count);


    }
}