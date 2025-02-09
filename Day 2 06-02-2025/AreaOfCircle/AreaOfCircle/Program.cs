using System.Formats.Asn1;

internal class Program
{
    double radius;

    static double CalculateAreaOfCircle (double radius)
    {
        return 3.14 * radius * radius;
    }

    
    private static void Main(string[] args)
    {
        Console.Write("Enter the radius :- ");
        double radius = Convert.ToDouble(Console.ReadLine());

        double area = CalculateAreaOfCircle(radius);

        Console.WriteLine($"The Area Of Circle With the Radius {radius} is {area}");
        
    }
}