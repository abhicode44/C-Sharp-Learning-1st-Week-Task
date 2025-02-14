internal class Program
{
    class Person
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


    }

    private static void Main(string[] args)
    {
        Person p = new Person("Abhishek",21);
        Console.WriteLine( $"Before :-  { p.Name} , {p.Age }");

        //Modify the object properties
        p.Name = "Alice";
        p.Age = 30;
        Console.WriteLine($"After :-  {p.Name} , {p.Age}");

    }
}