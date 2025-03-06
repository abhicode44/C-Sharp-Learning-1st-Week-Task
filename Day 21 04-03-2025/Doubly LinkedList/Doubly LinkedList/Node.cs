using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_LinkedList
{
    internal class Node
    {
        public Object Data;
        public Node Next ;
        public Node Prev;

        public Node(Object obj) {
            Data = obj ;
            Next = null;
            Prev = null;

        }
    }
}
