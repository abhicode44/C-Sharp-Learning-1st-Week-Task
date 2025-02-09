internal class Program
{

    int n;
    

    static void FibonacciSeries (int n)
    {
        int a = 0; int b = 1;
        int c ;
        for (int i = 0; i < n; i++) {
            Console.Write($"{a}");
            c = a + b;
            a = b;
            b = c;
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("\nFiboncci Series Generation");
        Console.Write("Enter the no of term :- ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Fiboncci Series :- ");
        FibonacciSeries(n);
        
    }
}