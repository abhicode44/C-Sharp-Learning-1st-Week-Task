internal class Program
{
    private static void Main(string[] args)
    {
        string name = args[0];
        string surname = args[1];
        string organization = args[2];
        int    Age = int.Parse(args[3]);

        Console.WriteLine($"Name :- {args[0]} Surname :- {args[1]} Organization :- {args[2]} Age :- {args[3]}");
  
    }
}

// you can used only arguments inside the Main function 
// and it takes only string 
// it will take multiple arguments 