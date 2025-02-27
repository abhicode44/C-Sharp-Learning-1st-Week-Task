internal class Program
{
    // This is a Multilevel Inheritance please update 

    class Parent
    {
        public void Welcome()
        {
            Console.WriteLine("Welcome to the parent class");
        }
    }

    class Child : Parent
    {
        public void Hello()
        {
            Console.WriteLine("Welcome to the child class");
        }

    }

    class child1 : Child
    {
        public void Greeting()
        {
            Console.WriteLine("Welcome to the child1 class");
        }

    }

    private static void Main(string[] args)
    {
        Parent parent = new Parent();
        parent.Welcome();

        Child child = new Child();
        child.Hello();

        child1 newchild = new child1();
        newchild.Greeting();


    }
}