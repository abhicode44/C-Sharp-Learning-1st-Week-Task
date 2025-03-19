using StudentAppWithDatabase.Model;

internal class Program
{
    private static void Main(string[] args)
    {
       Student_Store student_store = new Student_Store();

        student_store.ChooseMenu();
    }
}