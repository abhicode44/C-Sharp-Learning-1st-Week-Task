using System.Reflection.Metadata.Ecma335;

internal class Program
{

    static int[] Numbers(int[] array)
    {
        int[] modifyArray = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            modifyArray[i] = array[i] + 1;
        }

        return modifyArray;

    }

    static int[] ReverseArray ( int[] modifyArray )
    {
        int [] ReverseModifyArray = new int[modifyArray.Length];
        {   
            int j = modifyArray.Length - 1  ;

            

            
            foreach (int ele in modifyArray) { 

                 
                 ReverseModifyArray[j] = ele;
                 j-- ;
                 
            }

        }

        return ReverseModifyArray;
    }
    

    private static void Main(string[] args)
    {

        int[] array = { 1, 2, 3, 4, 5, 6 };

        int[] newArray = Numbers(array);


        foreach (int i in newArray)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();

        int [] ReversedArrayEle = ReverseArray(newArray);

        foreach (int i in ReversedArrayEle)
        {
            Console.Write(i + " ");
        }



        Console.ReadLine();

    }
}