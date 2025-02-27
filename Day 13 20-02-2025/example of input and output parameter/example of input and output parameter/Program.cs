internal class Program
{   

     int  GetValues (out int a ,out int b , ref int c)
    {
        a = 10;
        b = 11;
        c = 12;
        return a ;
            
    }

    

    private static void Main(string[] args)
    {
        Program program = new Program();
        int x; int y;
        int z = 50 ;
         
     

        program.GetValues(out x, out y , ref z);
        
        Console.WriteLine($"x: {x}, y: {y} , z:{z}");
    }
}