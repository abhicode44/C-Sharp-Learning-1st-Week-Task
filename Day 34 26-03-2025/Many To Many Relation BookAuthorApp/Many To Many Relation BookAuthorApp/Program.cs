using Many_To_Many_Relation_BookAuthorApp.DataBase;
using Many_To_Many_Relation_BookAuthorApp.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void AddAuthorBook()
    {
        Books book1 = new Books()
        {
            BookName = "Maths",
        };
        Books book2 = new Books()
        {
            BookName = "Science",
        };
        var context = new MyContext();
        context.AddRange(
            new Author
            {
                AuthorName = "Aritra",
                Books = new List<Books> { book1 },
            },
        new Author
            {
                AuthorName = "Abhishek",
                Books = new List<Books> { book1, book2 },
            }
            );
        context.SaveChanges();
    }

    public static void DisplayByAuthor()
    {
        Console.WriteLine("Enter Author Id :- ");
        int id = Convert.ToInt32(Console.ReadLine());
        var context = new MyContext();
        Author author = context.Author.Include(b => b.Books).FirstOrDefault(u => u.AuthorId == id);
        
        if (author != null)
        {
            Console.WriteLine($"Author ID: {author.AuthorId}, Name: {author.AuthorName}");
            foreach(var book in author.Books)
            {
                Console.WriteLine($"{book.BookName}");
            }
        }
        else
        {
            Console.WriteLine("Author not found.");
        }
    }

    public static void DisplayByBook()
    {
        Console.WriteLine("Enter Book Id :- ");
        int id = Convert.ToInt32(Console.ReadLine());
        var context = new MyContext();
        Books book = context.Books.Include(b => b.Authors).FirstOrDefault(u => u.BookId == id);

        if (book != null)
        {
            Console.WriteLine($"Book ID: {book.BookId}, BookName: {book.BookName}");
            foreach (var author in book.Authors)
            {
                Console.WriteLine($"{author.AuthorName}");
            }
        }
        else
        {
            Console.WriteLine("Book ID not found.");
        }
    }

    private static void Main(string[] args)
    {
        //AddAuthorBook();
        DisplayByAuthor();
        //DisplayByBook();
    }
}