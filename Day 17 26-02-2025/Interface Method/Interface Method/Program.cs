using Interface_Method;

internal class Program
{
    private static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.Move();
        Animal animal = new Dog();
        animal.Move();
    }
}