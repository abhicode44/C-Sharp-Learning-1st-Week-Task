using System.Windows.Input;
using Command_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        SimpleRemoteControl remote  = new SimpleRemoteControl();

        Light light = new Light();
        Fan fan = new Fan();

        remote.setCommand(new LightOnCommand(light));

        remote.ButtonPressedByUSer();

        remote.setCommand(new FanOnCommand(fan));

        remote.ButtonPressedByUSer();

        remote.setCommand(new LightOffCommand(light));

        remote.ButtonPressedByUSer();
    }
}