internal class Program
{

    public static void StartGame(ref int noofguess, ref int generatenumber)
    {
        for (int i = 1; i <= noofguess; i++)
        {
            Console.Write("Guess the number between 1 to 10: ");
            int inputnumber = Convert.ToInt32(Console.ReadLine());

            if (inputnumber == generatenumber)
            {
                Console.WriteLine("You Won The Game!");
                return;
            }
            else
            {
                Console.WriteLine("Try Again.");
            }

            if (i == noofguess)
            {
                Console.WriteLine($"The Actual Number was: {generatenumber}");
            }
        }
    }

    public static void GuessingNumber()
    {
        Random Guess = new Random();
        int noofguess = 3;
        bool playnewgame = true;

        while (playnewgame)
        {
            int generatenumber = Guess.Next(1, 11); 
            StartGame(ref noofguess, ref generatenumber);

            Console.Write("Do you want to play again? (yes/no): ");
            string playagain = Console.ReadLine();

            if (playagain != "yes")
            {
                playnewgame = false;
            }
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Number Guessing Game!");
        Program program = new Program();
        Program.GuessingNumber();
    }
}