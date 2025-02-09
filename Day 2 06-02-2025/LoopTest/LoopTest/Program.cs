internal class Program


{

    string name;

    static void PrintNameUsingForLoop(string name)
    {
        for (int i = 0; i < name.Length; i++)
        {
            Console.WriteLine(name[i]);
        }

    }

    static void PrintNameUsingWhileLoop(string name)
    {
        int i = 0;
        while (i < name.Length)
        {
            Console.WriteLine($"{name[i]}");
            i++;
        }

    }

    private static void Main(string[] args)
    {
        Console.Write("Enter the Name :- ");
        string name = Console.ReadLine(); ;

        Console.WriteLine();
        Console.WriteLine("Print the Name Using For Loop ");

        
        PrintNameUsingForLoop(name);

        Console.WriteLine();
        Console.WriteLine("Print the Name Using While Loop ");


        PrintNameUsingWhileLoop(name);


    }
}