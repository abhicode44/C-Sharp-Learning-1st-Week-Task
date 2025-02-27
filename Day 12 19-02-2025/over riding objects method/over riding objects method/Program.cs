using over_riding_objects_method;

internal class Program
{
    private static void Main(string[] args)
    {
        Person p1 = new Person("Abhishek" , 20);
        Person p2 = new Person("Abhishek" , 20);

        

        
        Console.WriteLine(p1.Equals(p2));

        

    }
}