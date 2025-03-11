using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_DataStructure_Implementation
{
    internal class Set_Operations
    {

        int[] unionarray = new int[100];
        int[] intersectionarray = new int[100];
        public int pointer;

        public void Union_Method(Set set1, Set set2)
        {
            int i = 0;
            int j = 0;

            
            while (i <= set1.pointer)
            {
                unionarray[j] = set1.set[i];
                j++;
                i++;
            }


            i = 0;

            
            while (i <= set2.pointer)
            {
                bool found = false;

                for (int k = 0; k <= set1.pointer; k++)
                {
                    if (set2.set[i] == set1.set[k])  
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    unionarray[j] = set2.set[i];
                    j++;
                }

                i++;
            }

           
            Console.Write($"Union: ");
            for (int p = 0; p < j; p++)
            {
                Console.Write($"[{unionarray[p]}] ");
            }

            Console.WriteLine();
        }

        public void Intersection_Method(Set set1, Set set2)
        {
            int i = 0;
            int j = 0;

            while (i <= set1.pointer)
            {
                for (int k = 0; k <= set2.pointer; k++)
                {
                    if (set1.set[i] == set2.set[k])
                    {
                        
                        intersectionarray[j] = set1.set[i];
                        j++;
                        break;
                    }
                }
                i++;
            }

            Console.Write($"Intersection: ");
            for (int p = 0; p < j; p++)
            {
                Console.Write($"[{intersectionarray[p]}] ");
            }

            Console.WriteLine();

        
        }
    }

}
