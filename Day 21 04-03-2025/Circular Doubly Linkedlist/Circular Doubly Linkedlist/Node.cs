using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Circular_Doubly_Linkedlist
{
    internal class Node
    {
        public object Data;
        public Node Next;
        public Node Prev;

        public Node(object obj) 
        { 
            Data = obj;
            Next = null;
            Prev = null;

        }
    }
}
