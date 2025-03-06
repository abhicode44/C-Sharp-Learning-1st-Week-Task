using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Operations
{

    internal class Node
    {
        public Object Data;
        public Node Next;



        public Node(Object obj) { 
            Data = obj;
            Next = null;
           
        }

    }
}
