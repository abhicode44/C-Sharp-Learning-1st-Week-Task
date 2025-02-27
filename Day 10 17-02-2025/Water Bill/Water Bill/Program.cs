using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Water Billing System");

        Console.WriteLine();

        int Meter_Charge = 75;

        int Water_Billcharge;

        string response = "yes";


        while (response == "yes")

        {

            Console.Write("Enter the Units Consumed :- ");

            string  noofunits = (Console.ReadLine());

            string [] number = { "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" , "0" };

            bool isInvalid = false;


            foreach (char c in noofunits)
            {    
                isInvalid = false;
                for (int i = 0; i < number.Length ; i++) {
                
                    if (number[i] == c.ToString())   
                    {
                        isInvalid = false;
                        break;
                    }
                    else
                    {   
                        isInvalid = true;                        
                    }
                }

            }

            if (isInvalid)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {



                int noofunitsconsumed = Convert.ToInt32(noofunits);

                if (noofunitsconsumed <= 100)
                {
                    Water_Billcharge = noofunitsconsumed * 5;
                    Console.WriteLine($"The Water Bill Charge :- {Water_Billcharge}");
                }


                else if (noofunitsconsumed <= 250)
                {
                    Water_Billcharge = noofunitsconsumed * 10;
                    Console.WriteLine($"The Water Bill Charge :- {Water_Billcharge}");
                }

                else
                {
                    Water_Billcharge = noofunitsconsumed * 20;
                    Console.WriteLine($"The Water Bill Charge :- {Water_Billcharge}");
                }





                int Total_Water_Bill_Charge = Water_Billcharge + Meter_Charge;
                Console.WriteLine($"The Total Water Bill :- {Total_Water_Bill_Charge}");



                Console.WriteLine("Do You Want To Print Another Bill :- ");


                response = Console.ReadLine();


                while (response != "yes" && response != "no")
                {


                    Console.WriteLine("Please Enter Valid Input yes or no");
                    response = Console.ReadLine();
                }
            } 
            
         


        }


        


    }
}