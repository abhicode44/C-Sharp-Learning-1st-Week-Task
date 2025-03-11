using Circular_Singly_LinkedList;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedLists linkedLists = new LinkedLists();

        int p = 20;
        object r = p;
        linkedLists.AddFirst(r);

        

        string a = "Abhishek";
        object o = a;
        linkedLists.AddFirst(o);



        string b = "Chudasama";
        object m = b;
        linkedLists.AddFirst(m);

        string c = "Dinesh";
        object n = c;
        linkedLists.AddLast(n);

        string q = "Welcome";
        object u = q;
        linkedLists.AddBetween(u);

        linkedLists.Display();
    }
}