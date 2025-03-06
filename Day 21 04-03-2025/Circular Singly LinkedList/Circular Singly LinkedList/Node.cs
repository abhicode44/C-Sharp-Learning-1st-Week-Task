using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Singly_LinkedList
{
    internal class Node
    {
        public Object Data;
        public Node Next;

        public Node(Object obj)
        {
            Data = obj;
            Next = null;

        }
    }    
}
