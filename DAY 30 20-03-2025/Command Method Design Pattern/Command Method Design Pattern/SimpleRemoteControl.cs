using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Method_Design_Pattern
{
    internal class SimpleRemoteControl 
    {
        public ICommand slot ;

        public SimpleRemoteControl() 
        {
           
        }

        public void setCommand(ICommand command) 
        { 
            slot = command;
        }

        

        public void ButtonPressedByUSer()
        {
            slot.Execute();
        }

    }
}
