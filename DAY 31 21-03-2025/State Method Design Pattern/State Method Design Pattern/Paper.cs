using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Method_Design_Pattern
{
    internal class Paper
    {
        public IState currentState;

        public Paper()
        {
            currentState = new DraftState(); 
        }

        public void ChangeState(IState newState)
        {
            currentState = newState;
        }

        public void Request()
        {
            currentState.Handle();
        }

    }
}
