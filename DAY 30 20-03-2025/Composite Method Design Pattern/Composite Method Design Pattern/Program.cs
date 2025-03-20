using Composite_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Parents head = new Parents(60);
        
   

        Parents parent1 = new Parents(40);
        Parents parent2 = new Parents(30);

        head.AddFamilyMember(parent1);
        head.AddFamilyMember(parent2);

        parent1.AddFamilyMember(new Child(20));
        parent1.AddFamilyMember(new Child(18));

        parent2.AddFamilyMember(new Child(10));
        parent1.AddFamilyMember(new Child(5));

        Console.WriteLine(head.GetAge());

    }
}