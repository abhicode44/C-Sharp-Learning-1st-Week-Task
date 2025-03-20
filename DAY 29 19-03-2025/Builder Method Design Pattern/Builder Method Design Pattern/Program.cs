using Builder_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        IHouseBuilder  aritraBuilder = new AritraBuilder();
        CivilEngineer engineer = new CivilEngineer(aritraBuilder);

        engineer.ConstructHouse();

        House house = engineer.GetHouse();

        Console.WriteLine("Builder Constructed :- " + house );
    }
}