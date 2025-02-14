internal class Program

    
{
    class ImmutablePerson
    {
        public string Name { get; }
        public int Age { get; }

        public ImmutablePerson(string name, int age) // Constructor
        {
            Name = name;
            Age = age;
        }
    }

    private static void Main(string[] args)
    {
        ImmutablePerson p = new ImmutablePerson("Abhishek" , 21 );
        Console.WriteLine($"Befor :- {p.Name} {p.Age}");

    }
}

// 	Properties are read-only (get;) and set only via constructor.
