internal class Program
{

    int number ;
    static void CallbyValue (int number)
    {
        Console.WriteLine(" Inside call by value :- " + number);
        number = 7;
        Console.WriteLine( " Inside call by value modify :- " + number);

    }

    static void CallbyReference(ref int number)
    {
        Console.WriteLine(" Inside Call By Reference :- " + number);
        number = 6;
        Console.WriteLine(" Inside Call By Reference modify :- " + number);
    }

    private static void Main(string[] args)
    {
        Console.Write("Enter the number :- ");
        int number = Convert.ToInt32(Console.ReadLine());

        number = 0;

        Console.WriteLine("The Call By Value");
        CallbyValue(number);
        Console.WriteLine(" After a call by value :- " + number);

        Console.WriteLine();

        Console.WriteLine("The Call By Reference");
        CallbyReference(ref number);
        Console.WriteLine(" After a call by reference :- " + number);
        
    }
}