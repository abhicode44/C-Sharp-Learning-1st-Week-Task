using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Method_Design_Pattern
{
    internal class Child : IFamily
    {   
        public  int Age { get; set; }
        public Child(int  age) 
        {
            Age = age;
        }
        public int GetAge()
        {
            return Age;
        }


    }
}
