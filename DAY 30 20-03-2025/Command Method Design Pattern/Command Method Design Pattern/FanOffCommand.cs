using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Method_Design_Pattern
{
    internal class FanOffCommand : ICommand
    {
        private Fan Fan { get; set; }

        public FanOffCommand(Fan fan)
        {
            Fan = fan;
        }

        public void Execute()
        {
            Fan.OFF();
        }
    }
}
