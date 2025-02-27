using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace over_riding_objects_method
{
    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }


        public Person(string name , int age) {
            Name = name;
            Age = age;
            
        }

        public override bool Equals(object obj )
        {   

            if ( obj == null || GetType() != obj.GetType() )
            {
                return false;
            }
            else
            {
                Person other  =  (Person) obj;  //type casting of obj  
                return Name == other.Name && Age == other.Age;
                    
            }

            
        }

    }


}
