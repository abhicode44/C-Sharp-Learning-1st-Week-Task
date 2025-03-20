using Abstract_Factory_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(CarFactory.BuildCar(CarType.MICRO));
        Console.WriteLine(CarFactory.BuildCar(CarType.LUXURY));
        Console.WriteLine(CarFactory.BuildCar(CarType.MINI));
    }
}