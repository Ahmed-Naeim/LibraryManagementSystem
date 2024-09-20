namespace LibraryManagementSystem
{
    class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public bool Availability;

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
        }

        public void GetBookDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Available: {Availability}");
        }
    }

    class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }

        public void SearchBook(string searchTerm)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower().Contains(searchTerm.ToLower()) ||
                    books[i].Author.ToLower().Contains(searchTerm.ToLower()))
                {
                    books[i].GetBookDetails();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No books found with that search term.");
            }
        }

        public void BorrowBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower() == title.ToLower() && books[i].Availability)
                {
                    books[i].Availability = false;
                    Console.WriteLine($"You have borrowed '{books[i].Title}'.");
                    return;
                }
            }
            Console.WriteLine("The book is either not available or not found.");
        }

        public void ReturnBook(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.ToLower() == title.ToLower() && !books[i].Availability)
                {
                    books[i].Availability = true;
                    Console.WriteLine($"You have returned '{books[i].Title}'.");
                    return;
                }
            }
            Console.WriteLine("This book was not borrowed or not found.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
