using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Singly_LinkedList
{
    internal class Node
    {
        public object Data;
        public Node Next;

        public Node(object obj)
        {
            Data = obj;
            Next = null;

        }
    }    
}
