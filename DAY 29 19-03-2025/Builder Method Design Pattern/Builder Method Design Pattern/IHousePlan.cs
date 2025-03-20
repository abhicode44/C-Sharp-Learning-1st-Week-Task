using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Method_Design_Pattern
{
    internal interface IHousePlan
    {
        public void SetBasement(string BasementName);
        public void SetStructure(string StructureName);
        public void SetRoof(string RoofName);
        public void SetInterior(string InteriorName);

    }
}
