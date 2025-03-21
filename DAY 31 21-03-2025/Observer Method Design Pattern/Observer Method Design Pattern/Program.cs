using Observer_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        WeatherStation weatherStation = new WeatherStation();

        DisplayDevice realme_phone = new DisplayDevice("Real Me Phone");
        DisplayDevice oppo_phone = new DisplayDevice("Oppo Phone");
        DisplayDevice vivo_phone = new DisplayDevice("Vivo Phone");

        weatherStation.AddObserver(realme_phone);
        weatherStation.AddObserver(oppo_phone);
        weatherStation.AddObserver(vivo_phone);

        weatherStation.SetWeather("Android Version 14 Ruled out");
        Console.WriteLine("\n");

        weatherStation.SetWeather("Android Version 13 Ruled out");
        Console.WriteLine("\n");





    }
}