using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Method_Design_Pattern
{
    internal class Parents : IFamily
    {   
        List<IFamily>family_membar = new List<IFamily>();

        public int Age { get; set; }

        public Parents(int age) 
        {
            Age = age;
        }

        public Parents() { } 

        public int GetAge()
        {
            int age = 0;

            foreach (IFamily family in family_membar)
            {
                age += family.GetAge();
            }
            return Age + age ;
        }

        public void AddFamilyMember(IFamily member)
        {
            family_membar.Add(member);
        }
    }
}
