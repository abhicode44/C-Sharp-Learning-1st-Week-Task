internal class Program
{
    // this is a hierarchical inheritance 

    class Parent  // parent class is a base class 
    {
        public void Welcome()
        {
            Console.WriteLine("Welcome to parent class");
        }

    }

    class child : Parent    // inherit properties from parent
    {
        public void Hello()
        {
            base.Welcome();  // using base class
            Console.WriteLine("Hello to child class");
        }

    }

    class child1 : Parent      // inherit properties from parent
    {
        public void Greeting()
        {
            base.Welcome();
            Console.WriteLine("Hello from child1 class");
        }
    }

    private static void Main(string[] args)
    {
        child child = new child();
        child.Hello();

        child1 child1 = new child1();
        child1.Greeting();
    }
}