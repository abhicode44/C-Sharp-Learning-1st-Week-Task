internal class Program
{
    class Parent
    {
        public virtual void Welcome()
        {
            Console.WriteLine("Welcome to Parent class");
        }

    }

    class child : Parent
    {
        public override void Welcome()
        {
            Console.WriteLine("Welcome to override Parent class");
        }
    }


    private static void Main(string[] args)
    {
        child child = new child();
        child.Welcome();
        Parent parent = new child();
        parent.Welcome();
    }
}