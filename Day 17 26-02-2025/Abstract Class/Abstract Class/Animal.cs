using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class
{
    internal abstract class Animal
    {
        public abstract void Move();

        public void Eat ()      // Regular Method 
        {
            Console.WriteLine("Animal is eating.");
        }

    }
}

// Abstract method: can only be used in an abstract class, and it does not have a body.
// The body is provided by the derived class (inherited from).