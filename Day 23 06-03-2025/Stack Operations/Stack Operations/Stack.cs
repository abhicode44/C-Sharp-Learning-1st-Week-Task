using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Operations
{
    internal class Stack
    {
        
        public Plate Top ;
        Plate []stack = new Plate [100];

        public void PushElement(object obj)
        {   
            Plate newPlate = new Plate(obj);
            int i = 0 ;
            while (stack[i] != null)
            {
                i++;
            }
            stack[i] = newPlate;
            Top = newPlate;

        }

        public void PopElements() {
            if (Top == null)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                int i = 0;
                while (stack[i] != null)
                {
                    Top = stack[i];
                    i++;
                }
                if (i == 0)
                {
                    Top = null;
                    stack[0] = null;
                }
                else
                {
                    Top = stack[i - 2];
                    stack[i - 1] = null;
                }

            }
        }

        public void DisplyElements() {
            if (Top == null)
            {
                Console.WriteLine("Stack is empty");
            }
            else 
            {
                int i = 0;
                while (stack[i] != null)
                {
                    i++;
                }
                i = i - 1;
                while (i >= 0)
                {
                    Console.WriteLine(stack[i].Data);
                    i--;    
                }
            }
        }
    }
}
