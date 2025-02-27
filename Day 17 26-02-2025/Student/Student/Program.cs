
using Student;

internal class Program
{
    private static void Main(string[] args)
    {



        //DetailsOfStudent student1 ;
        DetailsOfStudent[] details =  new DetailsOfStudent[100]; // Define the length of the array


        string response = "yes";
        int index = 0;

        while (response == "yes")
        {   
            Console.Write("Enter the name :- ");
            string name = Console.ReadLine();



            Console.Write("Enter the rollno :- ");
            int rollno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the percentage :- ");
            double percentage = Convert.ToDouble(Console.ReadLine());


            if (index < 100)
            {
                details[index] = new DetailsOfStudent(name, rollno, percentage);
                index++;
            }
            else
            {
                Console.WriteLine("Array is Full");
            }
           


            Console.WriteLine("Do you want to add another student ?  ");
            response = Console.ReadLine();


        }


        foreach (DetailsOfStudent student1 in details)
        { 
            if (student1 != null)
            {
                Console.WriteLine(student1.Name);
                Console.WriteLine(student1.RollNo);
                Console.WriteLine(student1.Percentage);
            }
            
        }





    }  

}