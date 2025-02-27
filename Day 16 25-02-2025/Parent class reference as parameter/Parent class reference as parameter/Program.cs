using Parent_class_reference_as_parameter.Model;

internal class Program
{    
    public static void TakeInputAsParameter(New n1) 
    {
        n1.Welcome();
    }
    
    private static void Main(string[] args)
    {

        New newone = new Child();   
        //newone.Welcome();
        New newone2 = new Child2();  
        //newone2.Welcome();

        TakeInputAsParameter(newone);
        TakeInputAsParameter(newone2 );

    }
}