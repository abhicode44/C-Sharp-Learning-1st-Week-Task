using Visitor_Method_Desing_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        School school = new School();

        var visitor1 = new Doctor("James");
        school.PerformOperation(visitor1);
        Console.WriteLine();

        var visitor2 = new Doctor("John");
        school.PerformOperation(visitor2);
        Console.WriteLine();

    }
}