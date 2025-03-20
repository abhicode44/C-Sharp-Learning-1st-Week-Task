using Decorators_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        IContractor contractor = (new Hall(new Kitchen(new BedRoom(new CiviWork()))));

        contractor.BuildHouse();


    }
}