internal class Program

{

     static public void GuessingNumber()
    {
        Random Guess = new Random();
 
        int noofguess = 3;

        bool playnewgame = true;

        while (playnewgame)
        {

            int generatenumber = Guess.Next(1, 10);


            for (int i = 1; i <= noofguess; i++)
            {
                Console.Write("Guess the number between 1 to 10 :- ");
                int inputnumber = Convert.ToInt32(Console.ReadLine());


                if (inputnumber == generatenumber)
                {
                    Console.WriteLine("You Won The Game");
                    return;
                }
                else
                {
                    Console.WriteLine("Try Again");
                }

                if (i == noofguess)
                {
                    Console.WriteLine($"The Actual Number is :- {generatenumber}");
                }


            }

            Console.WriteLine("Do want to play again ? ");
            string playagain = Console.ReadLine();


            if (playagain != "yes")
            {
                playnewgame = false;
            }

        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Number Guessing Game");

        Program obj = new Program();

        Program.GuessingNumber();
        

    }
}