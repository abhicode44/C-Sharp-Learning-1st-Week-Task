using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace input_and_output_parameter
{
    internal class Person
    {
        public string Name { get; set; } //properties
        public int Age { get; set; }
        public Person GetPerson()
        {
            return new Person { Name = "Abhishek", Age = 21 };
        }

    }
}
