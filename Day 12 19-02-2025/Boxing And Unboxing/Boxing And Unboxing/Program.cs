using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        ArrayList list = new ArrayList();

        Console.WriteLine(list.GetType());
        int x = 40 ; // Converting valuetype to refference type  its called boxing.

        list.Add(x);
        
        int y = (int)list[0] ;   // converting refference type to value type its called unboxing.

        Console.WriteLine(y);
    }
}