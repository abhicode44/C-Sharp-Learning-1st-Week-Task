

using System.Reflection.Metadata;
using State_Method_Design_Pattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Paper paper = new Paper();

        paper.Request();

        paper.ChangeState(new ReviewState());
        paper.Request();

        paper.ChangeState(new PublishedState());
        paper.Request();


    }
}