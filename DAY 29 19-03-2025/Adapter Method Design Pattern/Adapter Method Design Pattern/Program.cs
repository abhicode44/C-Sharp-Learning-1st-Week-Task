using Adapter_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        NewServices newServices = new NewServices();

        ILegacyServices legacyServices = new Adapter(newServices);

        legacyServices.LegacyRequest();

    }
}