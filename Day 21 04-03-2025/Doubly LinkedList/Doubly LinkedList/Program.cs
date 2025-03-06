using Doubly_LinkedList;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedLists doubly_LinkedList = new LinkedLists();

        int a = 1;
        Object o = a;
        doubly_LinkedList.AddFirst(o);

        int b = 2;
        o = b; 
        doubly_LinkedList.AddFirst(o);

        string d = "Abhishek";
        o = d;
        doubly_LinkedList.AddBetween(o);

        int c = 50;
        o = c;
        doubly_LinkedList.AddLast(o);

        doubly_LinkedList.Display();
    }
}