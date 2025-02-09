internal class Program
{


    int number;

    static void ForLoop(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Console.WriteLine(i);
        }

    }

    static void WhileLoop(int number)
    {
        int i = 0;
        while (i < number) {
            Console.WriteLine(i);
            i++;
        }
    }


    static void DoWhileLoop (int number)
    {
        int i = 0;

        do
        {
            Console.WriteLine(i);
            i++;
        }
        while (i > number);
    }



    private static void Main(string[] args)
    {
        Console.Write("Enter the numbe :- ");
        int number = Convert.ToInt32(Console.ReadLine());   

        Console.WriteLine("Using For Loop");
        ForLoop(number);

        Console.WriteLine("Using While Loop");
        WhileLoop(number);

        Console.WriteLine("Using Do While Loop");
        DoWhileLoop(number);
    }
}