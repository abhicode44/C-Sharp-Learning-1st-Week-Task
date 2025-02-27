using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using StudentApp.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welocme To Student App");

        string response = "yes";
        string user_rollno;
        int rollno = 0 ;
        string name = "";
        double cgpa = 0 ;

        while (response == "yes")
        {
           


            Console.Write($"Enter Roll No :-  ");

            user_rollno = (Console.ReadLine());

            string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            bool isInvalid = false;

            foreach (char c in user_rollno)
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
                Console.WriteLine("Invalid Input! Please enter a valid and Positive Roll No.");
                continue;
            }

            rollno = Convert.ToInt32(user_rollno);

            string user_name = "";

            string[] alphabet_verify = {"A" , "B" , "C" , "D" , "E" , "F" ,  "G" , "H" , "I" ,
                                          "J" , "K" , "L" , "M" , "N" , "O" , "P" , "Q" , "R" ,
                                          "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z"   };

            bool isNameInvalid = true;

            while (isNameInvalid == true) 
                 
            {
                Console.Write($"Enter The Name :-  ");
                user_name = Console.ReadLine().ToUpper();

                foreach (char c in user_name)
                {
                    
                    foreach (string num in alphabet_verify)
                    {
                        if (c.ToString() ==  num )
                        {
                            isNameInvalid = false;
                            break;
                            
                        }
                        else
                        {
                            isNameInvalid = true;
                            
                        }
                        
                    }
                    if (isNameInvalid)
                    {
                        Console.WriteLine("Invalid Name");
                        break;
                    }
                }

                
                
            }


            if (user_name.Length < 5)
            {
                user_name = "";
            }

             name = (user_name);

            string user_cgpa = "";

            string[] cgpa_verify = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" , "." };

            bool isCgpaInvalid = true;

             cgpa = 0;

            
            
            while (isCgpaInvalid == true)

            {   

                Console.Write($"Enter The CGPA :-  ");
                user_cgpa = Console.ReadLine();

                if ('.' != user_cgpa[0])
                {

                    foreach (char c in user_cgpa)
                    {

                        foreach (string num in cgpa_verify)
                        {
                            if (c.ToString() == num)
                            {
                                isCgpaInvalid = false;
                                break;

                            }
                            else
                            {
                                isCgpaInvalid = true;

                            }
                        }

                    }

                }

                if (isCgpaInvalid)
                {
                    Console.WriteLine("Invalid CGPA");
                }

                else
                {
                     cgpa = Convert.ToDouble(user_cgpa);
                }

                


                if (cgpa <= 1 || cgpa >= 10)
                {
                    Console.WriteLine("Invalid CGPA 1 to 10");
                    isCgpaInvalid = true;
                }

                else
                {
                    isCgpaInvalid = false;
                   
                }

            }


            Student student = new Student(rollno, name, cgpa);


            Console.WriteLine($"Roll No :- {student.RollNo}");
            Console.WriteLine($"Name :- {student.Name}");
            Console.WriteLine($"Cgpa :- {student.CGPA}");
            Console.WriteLine($"Percentage :- {student.Percentage}");


            Console.Write("Do you want to calculate percentage again? (yes/no): ");
            response = Console.ReadLine();

            while (response != "yes" && response != "no")
            {
                Console.WriteLine("Please enter a valid response (yes or no): ");
                response = Console.ReadLine();
            }
        }


 
  
    }
}