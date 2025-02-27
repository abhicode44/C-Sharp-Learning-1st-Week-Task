// See https://aka.ms/new-console-template for more information

using Virtual_Class;

internal class Program

    // This is a virtual class 
{
    private static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.Move();
        dog.Bark();
        Animal animal = new Animal();
        animal.Move();
        animal.Eat();
    }
}