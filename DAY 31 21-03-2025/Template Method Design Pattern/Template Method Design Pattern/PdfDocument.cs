using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method_Design_Pattern
{
    internal class PdfDocument : Files
    {
        protected override void Close()
        {
            Console.WriteLine("Closing Pdf File");
        }

        protected override void Open()
        {
            Console.WriteLine("Opening Pdf File");
        }

        protected override void Write()
        {
            Console.WriteLine("Writing Pdf File");
        }

    }
}
