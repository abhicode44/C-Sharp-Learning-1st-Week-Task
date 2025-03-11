internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int, string> sub = new Dictionary<int, string>();

        
        sub.Add(1, "C#");
        sub.Add(2, "Javascript");
        sub.Add(3, "Dart");

        foreach (var ele in sub)
        {
            Console.WriteLine($"Key: {ele.Key}, Value: {ele.Value}");
        }

        sub.Remove(1);

        Console.WriteLine("\nAfter Remove() method:");
        foreach (KeyValuePair<int, string> ele in sub)
        {
            Console.WriteLine("key: {0}, Value: {1}", ele.Key, ele.Value);
        }

        Console.WriteLine();

        if (sub.ContainsKey(1))
            Console.WriteLine("Key is found...!!");
        else
            Console.WriteLine("Key is not found...!!");

        Console.WriteLine();
        if (sub.ContainsValue("Dart"))
            Console.WriteLine("Value is found...!!");
        else
            Console.WriteLine("Value is not found...!!");

    }
}
