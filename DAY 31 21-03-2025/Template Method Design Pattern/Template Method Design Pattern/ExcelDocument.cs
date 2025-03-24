using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method_Design_Pattern
{
    internal class ExcelDocument : Files
    {
        protected override void Close()
        {
            Console.WriteLine("Closing Excel File");
        }

        protected override void Open()
        {
            Console.WriteLine("Opening Excel File");
        }

        protected override void Write()
        {
            Console.WriteLine("Writing Excel File");
        }
    }
}
