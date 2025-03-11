using Set_DataStructure_Implementation;

internal class Program
{
    private static void Main(string[] args)
    {
        Set s = new Set(1);
        Set s1 = new Set(2);

        Set_Operations set_Operations = new Set_Operations();

        s.AddElements(1);
        s.AddElements(2);
        s.AddElements(3);
        s.AddElements(4);


        s1.AddElements(4);
        s1.AddElements(5);
        s1.AddElements(6);


        s.Display();
        
        Console.WriteLine("");

        s1.Display();


        Console.WriteLine();
        set_Operations.Union_Method(s, s1);
        set_Operations.Intersection_Method(s, s1);

    }
}