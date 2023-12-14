// Nama     : Vincent T E Saragih
//NRP       : 5222600022

using System;
using System.Collections.Generic;

public class StackOverflowException : Exception
{
    public StackOverflowException(string message) : base(message)
    {
    }
}

public class StackEmptyException : Exception
{
    public StackEmptyException(string message) : base(message)
    {
    }
}

public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }

    public Book(string author, string title, DateTime publicationDate)
    {
        Author = author;
        Title = title;
        PublicationDate = publicationDate;
    }
}

public class BookStack
{
    private Stack<Book> bookStack;

    public BookStack()
    {
        bookStack = new Stack<Book>();
    }

    public void Push(Book book)
    {
        bookStack.Push(book);
    }

    public Book Pop()
    {
        if (IsEmpty())
        {
            throw new StackEmptyException("Stack masih kosong.");
        }

        return bookStack.Pop();
    }

    public bool IsEmpty()
    {
        return bookStack.Count == 0;
    }

    public void PrintBooks()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Tidak ada buku dalam stack.");
        }
        else
        {
            Console.WriteLine("Daftar buku dalam stack:");
            foreach (var book in bookStack)
            {
                Console.WriteLine($"Penulis: {book.Author}, Judul: {book.Title}, Tanggal Rilis: {book.PublicationDate.ToShortDateString()}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            BookStack bookStack = new BookStack();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Tambahkan buku baru");
                Console.WriteLine("2. Tampilkan daftar buku");
                Console.WriteLine("3. Keluar");

                Console.Write("Pilih menu (1-3): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Masukkan penulis buku: ");
                        string author = Console.ReadLine();
                        Console.Write("Masukkan judul buku: ");
                        string title = Console.ReadLine();
                        Console.Write("Masukkan tanggal rilis buku (yyyy-mm-dd): ");
                        DateTime publicationDate = DateTime.Parse(Console.ReadLine());

                        Book newBook = new Book(author, title, publicationDate);
                        bookStack.Push(newBook);
                        Console.WriteLine("Buku berhasil ditambahkan ke dalam stack.");
                        break;

                    case 2:
                        bookStack.PrintBooks();
                        break;

                    case 3:
                        Console.WriteLine("Program selesai.");
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan pilih kembali.");
                        break;
                }
            }
        }
        catch (StackEmptyException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
