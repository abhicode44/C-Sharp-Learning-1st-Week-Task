internal class Program
{
    private static void Main(string[] args)
    {
        Stack<int> s = new Stack<int>();

        s.Push(1);
        s.Push(2);
        s.Push(3);
        s.Push(4);
        s.Push(5);

        Console.WriteLine("Initial Stack After Push Elements :- ");
        foreach (var ele in s)
        {
            Console.WriteLine(ele);
        }

        Console.WriteLine();

        s.Pop();
        s.Pop();
        Console.WriteLine("Stack After Pop Element from the Top :- ");
        foreach (var ele in s)
        {
            Console.WriteLine(ele);
        }

       Console.WriteLine();
       Console.WriteLine($"Chcek The Avalibility of the element 1 in the Stack :- " + s.Contains(1) );

        Console.WriteLine();
        Console.WriteLine($"Chcek The Avalibility of the element 100 in the Stack :- " + s.Contains(100));
        
        Console.WriteLine();
        s.Clear();
        if (s.Count == 0)
        {
            Console.WriteLine("The Stack is Empty");
        }
        
    }
}