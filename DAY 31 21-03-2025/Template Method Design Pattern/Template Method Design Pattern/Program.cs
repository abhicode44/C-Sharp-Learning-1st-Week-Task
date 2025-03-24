using System.Reflection.Metadata;
using Template_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        ExcelDocument exceldoc = new ExcelDocument();
        PdfDocument pdfdoc = new PdfDocument();

        Console.WriteLine("\n");
        Console.WriteLine("Process For Excel Documnet");
        exceldoc.Save();

        Console.WriteLine("\n");
        Console.WriteLine("Process For PDF Documnet");
        pdfdoc.Save();



    }
}