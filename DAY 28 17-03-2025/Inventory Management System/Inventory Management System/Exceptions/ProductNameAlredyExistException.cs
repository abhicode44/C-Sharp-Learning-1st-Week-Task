using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Exceptions
{
    internal class ProductNameAlredyExistException : Exception
    {
        public ProductNameAlredyExistException(string message) : base(message) { }
    }
}
