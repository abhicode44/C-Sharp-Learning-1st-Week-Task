using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Class
{
    internal class Dog : Animal
    {
        public override void Move()
        {
            
            Console.WriteLine("Dog is running.");

        }

        public void Bark()
        {
            Console.WriteLine("Dog is barking.");
        }


    }
}
