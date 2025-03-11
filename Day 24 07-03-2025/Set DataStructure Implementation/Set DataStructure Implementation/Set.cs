using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_DataStructure_Implementation
{
    internal class Set
    {   

         

        public int[]set = new int[100];

        public int pointer = -1;

        public  int SetNumber  ;

        public Set (int setnumber )
        {
            SetNumber = setnumber;
        }


        public void AddElements (int obj)
        {
            pointer = pointer + 1;
            set[pointer] = obj;
        }



        public  void Display ()
        {

            int i;

            Console.Write($"Set {SetNumber} :- ");

            

            for (i= 0; i <= pointer ; i++) 
            {   
                Console.Write( $" [ {set[i]} ]");      
            }

        }

    }
}
