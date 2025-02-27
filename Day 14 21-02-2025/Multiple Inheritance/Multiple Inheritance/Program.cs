internal class Program
{
    // This is a Multiple Inheritance
    interface Parent1
    {
        public void Welcome()
        {
            Console.WriteLine("Hello Abhishek");
        }

    }

    interface Parent2
    {
        public void Hello();

    }

    class Child : Parent1, Parent2
    {

        public void Welcome()
        {
            Console.WriteLine("Welcome from Parent 1 class ");
        }

        public void Hello()
        {
            Console.WriteLine("Hello from Parent 2 class ");
        }

        public void Greeting()
        {
            Console.WriteLine(" Greeting from child class ");
        }



    }
    private static void Main(string[] args)
    {
        Child child = new Child();

        child.Welcome();
        child.Greeting();
        child.Hello();

        Parent1 parent1 = new Child();
        parent1.Welcome();

    }
}