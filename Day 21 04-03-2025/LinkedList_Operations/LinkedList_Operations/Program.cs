using LinkedList_Operations;

internal class Program
{   


    private static void Main(string[] args)
    {
        LinkedLists linklistobj = new LinkedLists() ;

        int a = 10;
        Object o = a ;
        linklistobj.AddFirstNode(o) ;

        int d = 20;
        o = d;
        linklistobj.AddFirstNode(o);


        string b = "Abhishek";
        o = b;
        linklistobj.AddFirstNode(o);

        

        int c = 500;
        o = c;
        linklistobj.AddBetweenNode(o);


        int e = 5100;
        o = e;
        linklistobj.AddLast(o);


        int h = 6000;
        o = h;
        linklistobj.AddLast1(o);

        linklistobj.Display();

    }
}