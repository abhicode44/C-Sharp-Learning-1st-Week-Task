using System;
using Tostring_Method_Override;

internal class Program
{
    private static void Main(string[] args)
    {
        Person p1 = new Person("Abhishek" , 21);
        Person p2 = new Person("Aritra" , 24);

        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToString());
    }
}