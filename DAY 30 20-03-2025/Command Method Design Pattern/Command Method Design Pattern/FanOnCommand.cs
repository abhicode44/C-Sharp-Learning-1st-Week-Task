using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Method_Design_Pattern
{
    internal class FanOnCommand : ICommand
    {
        private Fan Fan { get; set; }

        public FanOnCommand(Fan fan)
        {
            Fan = fan;
        }

        public void Execute()
        {
            Fan.ON();
        }
    }
}
