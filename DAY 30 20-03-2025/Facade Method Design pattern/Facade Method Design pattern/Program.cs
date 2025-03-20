using Facade_Method_Design_pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Car car = new Car();    
        car.StartCar();
        car.StopCar();
    }
}