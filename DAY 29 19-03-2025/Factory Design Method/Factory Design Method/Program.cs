using Factory_Design_Method;

internal class Program
{
    private static void Main(string[] args)
    {
        Client client = new Client();

        client.BuildVehicle(VehicleType.Bike);
        client.GetVehicle().PrintVehicleInfo();

        client.BuildVehicle(VehicleType.Rickshaw);
        client.GetVehicle().PrintVehicleInfo();

        client.BuildVehicle(VehicleType.Car);
        client.GetVehicle().PrintVehicleInfo();

    }
}