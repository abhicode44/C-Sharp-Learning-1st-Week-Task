using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class;


internal class Dog : Animal
{
    public override void Move()    
    {
        Console.WriteLine("Dog is Moving ");
    }

    public void Bark()
    {
        Console.WriteLine("Dog is barking.");
    }

}

// use override method without using virtual keyword in the parent class