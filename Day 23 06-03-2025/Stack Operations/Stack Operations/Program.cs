using Stack_Operations;

internal class Program
{
    private static void Main(string[] args)
    {
        Stack s = new Stack();

        int a = 10;
        Object o = a;
        s.PushElement(o);

        int b = 20;
        o = b;
        s.PushElement(o);

        s.PopElements();

        string c = "Abhishek";
        o = c;
        s.PushElement(o);

        s.DisplyElements();
    }
}