using Circular_Doubly_Linkedlist;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedLists linkedLists = new LinkedLists();

        int a = 10;
        object o = a;
        linkedLists.AddFirst(o);

        int b = 20;
        object p = b;
        linkedLists.AddFirst(p);

        int c = 30;
        object q = c;
        linkedLists.AddFirst(q);

        string d = "hello";
        object r = d;
        linkedLists.AddFirst(r);

        string e = "Abhishek";
        object s = e;
        linkedLists.AddLast(s);

        string f = "Between";
        object t = f;
        linkedLists.AddBetween(t);

        string g = "chudasama";
        object u = g;
        linkedLists.AddLast(g);

        linkedLists.Display();
    }
}