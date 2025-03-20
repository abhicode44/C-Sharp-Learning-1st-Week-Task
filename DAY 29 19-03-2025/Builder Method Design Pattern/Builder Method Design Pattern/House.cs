using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Method_Design_Pattern
{
    internal class House : IHousePlan
    {
        private string BasementName { get; set; }
        private string StructureName { get; set; }
        private string RoofName     { get; set; }
        private string InteriorName { get; set; }

        public void SetBasement (string basement)
        {
            BasementName = basement;
        }

        public void SetStructure(string sturcture)
        {
            StructureName = sturcture;
        }

        public void SetRoof(string roof)
        {
            RoofName = roof;
        }

        public void SetInterior(string interior)
        {
            InteriorName = interior;
        }

        public override string ToString()
        {
            return $"Basement: {BasementName}, Structure: {StructureName}, Roof: {RoofName}, Interior: {InteriorName}";
        }

    }
}
