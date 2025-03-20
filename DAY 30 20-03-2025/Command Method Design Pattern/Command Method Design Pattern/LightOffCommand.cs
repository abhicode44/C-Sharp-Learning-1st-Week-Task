using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Method_Design_Pattern
{
    internal class LightOffCommand : ICommand
    {
        public Light _light;
        public LightOffCommand(Light light) 
        { 
            _light = light;
        }

        public void Execute()
        {
            _light.OFF();
        }
    }
}
