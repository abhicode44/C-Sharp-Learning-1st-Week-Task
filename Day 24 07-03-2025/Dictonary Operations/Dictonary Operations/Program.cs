using System.Collections.Generic;
using Dictonary_Operations;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictonary_method s = new Dictonary_method();

        int a = 1;
        object o = a;


        string b = "Abhishek";
        object p = b;
        s.AddElements(o, p);


        int c = 2;
        object q = c;


        string d = "Aritra";
        object r = d;
        s.AddElements(q, r);

        s.RemoveElements(o , p);


        int e = 3;
        object f = e;

        string m = "Paritosh";
        object g = f;

        s.AddElements(g,m);

        s.Disply();



    }
}