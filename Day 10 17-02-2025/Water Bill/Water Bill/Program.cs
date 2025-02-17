internal class Program
{   


    public static void WaterBill()
    {
        Console.Write("Enter the Units Consumed :- ");

        int noofunitsconsumed = Convert.ToInt32(Console.ReadLine());


        int Meter_Charge = 75;

        int Water_Billcharge;

        if (noofunitsconsumed <= 100)
        {
            Water_Billcharge = noofunitsconsumed * 5;
            Console.WriteLine($"The Water Bill Charge :- {Water_Billcharge}");
        }

        else if (noofunitsconsumed <= 250 ) 
        {
            
                Water_Billcharge = noofunitsconsumed * 10;
                Console.WriteLine($"The Water Bill Charge :- {Water_Billcharge}");
       
        }

        else
        {
                Water_Billcharge = noofunitsconsumed * 20;
                Console.WriteLine($"The Water Bill Charge :- {Water_Billcharge}");
        }

        int  Total_Water_Bill_Charge = Water_Billcharge + Meter_Charge ;
        Console.WriteLine($"The Total Water Bill :- {Total_Water_Bill_Charge}");

    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Water Billing System");

        Console.WriteLine();

        WaterBill();

    }
}