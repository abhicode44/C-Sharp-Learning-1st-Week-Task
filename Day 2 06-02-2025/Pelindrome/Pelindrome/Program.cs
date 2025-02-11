internal class Program
{
    static bool IsPalindrome(string str)
    {
        
        str = str.ToLower();

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
                return false;
            left++;
            right--;
        }
        return true;
    }





    private static void Main(string[] args)
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

    
        if (IsPalindrome(input))
            Console.WriteLine("The Given String is pelindrome ");
        else
            Console.WriteLine("The Given String is Not pelindrome ");

        Console.ReadLine();

    }
}