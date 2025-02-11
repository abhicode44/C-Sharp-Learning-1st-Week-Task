internal class Program
{
    int number;
    static bool IsAmstrong(int number)
    {
        int orignalNum = number;

        int sum = 0;

        int digits = number.ToString().Length;     // Count the Total Digits in the number

        while (number > 0)
        {
            int digit = number % 10;               // it gives last digit 
            sum += (int)Math.Pow(digit, digits);   // its strore the cube of the digit and update
            number /= 10;                          // it removes last digit and update

        }

        return sum == orignalNum;

    }

    

    private static void Main(string[] args)
    {
        Console.Write("Enter the number :- ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (IsAmstrong(number)) {
            Console.WriteLine($"The Given Number {number}  is Amstrong Number");
        }
        else
        {
            Console.WriteLine($"The Given Number {number}  is Not Amstrong Number");
        }

        Console.ReadLine();
        

        
        

    }
}