
public class Person
{
    public string Name;
    public int Age;


    public Person (string name , int age)
    {
        Name = name; 
        Age = age;
    }

}

     public struct PersonStruct
       {
          public string Name;
          public int Age;

          public PersonStruct(string name, int age)
           {
             Name = name;
             Age = age;
             }
      }


internal class Program
{   

    private static void Main(string[] args)
    {
        Person person1 = new Person("Abhishek",21);
        Person person2 = person1;


        
        person2.Age = 19;
        Console.WriteLine(person1.Age);

        PersonStruct person3 = new PersonStruct("Aritra", 24);
        PersonStruct person4 = person3;

        person4.Age = 20;
        Console.WriteLine(person3.Age);

    }
}