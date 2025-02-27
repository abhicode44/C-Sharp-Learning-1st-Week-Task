using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string response = "yes";

        Console.WriteLine("Welcome to Currency Note Calculator");

        while (response == "yes")
        {
            Console.Write("Enter The Amount :- ");
            string amount = Console.ReadLine();

            
            string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            bool isInvalid = false;

            foreach (char c in amount)
            {
                bool found = false;
                foreach (string num in number)
                {
                    if (num == c.ToString())
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    isInvalid = true;
                    break;
                }
            }

            if (isInvalid)
            {
                Console.WriteLine("Invalid Input! Please enter a valid numeric amount.");
                continue; 
            }

            int current_amount = Convert.ToInt32(amount);

            if (current_amount > 50000 || current_amount % 100 != 0)
            {
                Console.WriteLine("Invalid Amount! It should be less than 50,000 and a multiple of 100.");
                continue; 
            }

            
            int note_2000 = 0, note_500 = 0, note_200 = 0, note_100 = 0;

            if (current_amount >= 2000)
            {
                note_2000 = current_amount / 2000;
                Console.WriteLine($"2000 : {note_2000}");
                current_amount %= 2000;
            }

            if (current_amount >= 500)
            {
                note_500 = current_amount / 500;
                Console.WriteLine($"500 : {note_500}");
                current_amount %= 500;
            }

            if (current_amount >= 200)
            {
                note_200 = current_amount / 200;
                Console.WriteLine($"200 : {note_200}");
                current_amount %= 200;
            }

            if (current_amount >= 100)
            {
                note_100 = current_amount / 100;
                Console.WriteLine($"100 : {note_100}");
                current_amount %= 100;
            }

           
            Console.Write("Do you want to calculate again? (yes/no): ");
            response = Console.ReadLine();

            while (response != "yes" && response != "no")
            {
                Console.WriteLine("Please enter a valid response (yes or no): ");
                response = Console.ReadLine();
            }
        }
    }
}
