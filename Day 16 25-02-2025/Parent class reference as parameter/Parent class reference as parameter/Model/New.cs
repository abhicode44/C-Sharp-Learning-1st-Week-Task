﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent_class_reference_as_parameter.Model
{   
                             //Using Hierarchical Inheritance 
    internal class New   //parent class
    {
        public virtual void Welcome()
        {   
            Console.WriteLine("This is a parent class");
        }

    }

    class Child : New
    {

        public override void Welcome()
        {
            Console.WriteLine("This is a child class override");
        }

    }

    class Child2 : New
    {
        public override void Welcome()
        {
            Console.WriteLine("This is a child2 class override ");
        }

    }


}
