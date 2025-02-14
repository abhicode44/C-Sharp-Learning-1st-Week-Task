
//internal class Program
//{
//    private int value ;

//    int GetValues (ref int a , out int b)
//    {
//        a = 10;
//        b = 20 ; 
//        return a ;
//    }

//    private static void Main(string[] args)
//    {
//        Program program = new Program();
//        int x = 0; int y;
//        program.GetValues(ref x, out y);
//        Console.WriteLine( $" x : {x} y : {y}");
//    }
//}



// Both using reference
//internal class Program
//{
//    private int value;

//    int GetValues(ref int a, ref int b)
//    {
//        a = 10;
//        b = 20;
//        return a;
//    }

//    private static void Main(string[] args)
//    {
//        Program program = new Program();
//        int x = 0; int y = 0 ;
//        program.GetValues(ref x, ref y);
//        Console.WriteLine($" x : {x} y : {y}");
//    }

//}


//Both with the without reference
//internal class Program
//{
//    private int value;

//    int GetValues(out int a, out int b)
//    {
//        a = 10;
//        b = 20;
//        return a;

//    }

//    private static void Main(string[] args)
//    {
//        Program program = new Program();
//        int x , y;
//        program.GetValues(out x, out y);
//        Console.WriteLine($" x : {x} y : {y}");
//    }
//}


//Multiple parameter using Tuple



using input_and_output_parameter;

internal class Program
{
    private int value;

    (int,string,bool,string,int,bool)  GetValues( int a , int d )  //Tuples 
    {
        a = 10;
        string b = "abhishek";
        string c = "chudasama";
        d = 20;
        bool IsMentee = false;
        bool Isrequired = true;
        return (a, b, IsMentee , c  , d , Isrequired);

    }


    private static void Main(string[] args)
    {
        Program program = new Program();
        int x = 0;
        string name = " ";
        string surename = " ";
        int y = 50;
        
        var values = program.GetValues(x , y );

        //Console.WriteLine($" x : {x} name : {values.Item2}   surename :- {values.Item4} Ismentee : {values.Item3}  y : {values.Item5} Isrequired : {values.Item6} ");

        


        Person person = new ();
        


        Person person2 =  person.GetPerson();

        Console.WriteLine($"name : {person2.Name} Age : {person2.Age}");
    }
}






