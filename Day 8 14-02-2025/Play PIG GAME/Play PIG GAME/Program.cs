using System;
using System.ComponentModel.Design;

internal class Program
{   

    public static void CheckResponseRoll(ref string response , ref Random random , ref string currentplayername , ref int eachroundscore , ref bool player1chance , ref int player1score , ref int player2score , ref bool playGame)
    {
        if (response == "r")
        {
            int dicenumber = random.Next(1, 7);
            Console.WriteLine($"{currentplayername} rolled {dicenumber}");

            if (dicenumber == 1)
            {
                Console.WriteLine("oops rolled 1 you lose the points for this round");
                eachroundscore = 0;
                Console.WriteLine($"your total score till perivious round {(player1chance ? player1score : player2score)}");
                return;
            }

            else
            {
                eachroundscore += dicenumber;

                if ((player1chance ? player1score : player2score) + eachroundscore >= 20)
                {
                    Console.WriteLine($"{currentplayername} wins  score :-  {(player1chance ? player1score : player2score) + eachroundscore}!");
                    return;
                }


                Console.WriteLine($"your round score is : {eachroundscore}");
                Console.WriteLine($"your total score is : {(player1chance ? player1score : player2score)}");
           
            }

        }

        else if (response == "h")

        {
            if (player1chance)
            {
                player1score += eachroundscore;
            }

            else
            {
                player2score += eachroundscore;
            }
           
            Console.WriteLine($"{currentplayername} total score {(player1chance ? player1score : player2score)} ");
            
            playGame = false;


        }

        else
        {
            Console.WriteLine("Invalid Input");
        }

    }

    
    

    public static void PlayGame(ref Random random , ref string currentplayername ,ref int eachroundscore , ref bool player1chance , ref int player1score ,ref int player2score)
    {
        bool playGame = true;

        while (playGame)
        {

            Console.Write("Enter 'r' to roll and 'h' to hold :- ");
            string response = Console.ReadLine();

            CheckResponseRoll(ref response, ref random, ref currentplayername, ref eachroundscore, ref player1chance, ref player1score, ref player2score , ref playGame );

            
        }


    }

    public static void CheckScore (ref int player1score , ref int player2score ,ref string player1name , ref string player2name ,ref bool player1chance  ,ref Random random)
    {

        while (player1score < 20 && player2score < 20)
        {

            int eachroundscore = 0;

            string currentplayername = player1chance ? player1name : player2name;
            Console.WriteLine($"\n{currentplayername}'s Turn ");

            PlayGame( ref random, ref currentplayername, ref eachroundscore, ref player1chance, ref player2score , ref player1score);

            player1chance = !player1chance;

        }

        


    }

    public static  void PigGame()
    {
        Console.Write("Enter the name of Player 1 :- ");
        string player1name = Console.ReadLine();

        Console.WriteLine();

        Console.Write("Enter the name of Player 2 :- ");
        string player2name = Console.ReadLine();


        Random random = new Random();


        int player1score = 0;
        int player2score = 0; 

        bool player1chance = true; 


       
        CheckScore(ref player1score, ref player2score, ref player1name, ref player2name, ref player1chance, ref random);

        

        if (player1score >= 20)
        {

            Console.WriteLine($"{player1name} wins score : {player1score}");

        }

        else {
            Console.WriteLine($"{player2name} wins score : {player2score}");
        }


    }

        
        

    
    


    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Pig Game");

        Console.WriteLine();


        Program program = new Program();

        Program.PigGame();
        

    }
}