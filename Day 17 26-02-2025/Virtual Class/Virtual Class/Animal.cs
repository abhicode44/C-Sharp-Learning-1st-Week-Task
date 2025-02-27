using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Class
{
    internal class Animal
    {
        public virtual void Move()
        {
            Console.WriteLine("Animal is moving.");
        }

        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }

    }
}
