internal class Program
{
    class Person
    {
        public string Name;
        public int Age;

        public Person() : this("Unknown", 0) { }

        public Person(string name) : this(name, 18){}

        public Person(string name, int age) 
        { 
            Name = name; 
            Age = age; 
        }

        public Person ( Person other)
        {
            Name = other.Name;
            Age = other.Age;
        }

    }
    private static void Main(string[] args)
    {
        Person p1 = new Person();
        Person p2 = new Person("Abhishek");
        Person p3 = new Person("Bob", 20);
        Person copy = new Person(p3);

        Console.WriteLine($"{p1.Name} {p1.Age}");
        Console.WriteLine($"{p2.Name}  {p2.Age} ");
        Console.WriteLine($"{p3.Name} {p3.Age}");
        Console.WriteLine($" {copy.Name} {copy.Age}");
    }
}