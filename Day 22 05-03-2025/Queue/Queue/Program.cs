using Queue;

internal class Program
{
    private static void Main(string[] args)
    {
        Queue_operations queue = new Queue_operations();

        

        string b = "Abhishek";
        object o = b;
        queue.AddElement(o);

        int a = 10;
        object p = a;
        queue.AddElement(p);

        int c = 20;
        object d = c;
        queue.AddElement(d);

        int e = 30;
        object f = e;
        queue.AddElement(f);

        queue.RemoveElement();
        queue.DisplayElement();
    }
}