using ConsoleApp1;
using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person author = new Person("Jan", "Kowalski", 45);
            Person author1 = new Person("Osoba", "Pierwsza", 50);
            Person author2 = new Person("Osoba", "Druga", 60);
            Person author3 = new Person("Osoba", "Trzecia", 70);

            Book book1 = new Book("Książka1", author1, new DateTime(1997, 10, 30));
            Book book2 = new Book("Książka2", author2, new DateTime(1988, 9, 27));
            Book book3 = new Book("Książka3", author3, new DateTime(2010, 1, 1));
            Book book4 = new Book("Książka4", author2, new DateTime(2020, 1, 1));
            Book book5 = new Book("Książka5", author2, new DateTime(1000, 12, 30));

            Reader reader1 = new Reader("Anna", "Nowak", 20);
            Reader reader2 = new Reader("Ewa", "Wiśniewska", 30);
            Reader reader3 = new Reader("Adam", "Nowak", 55);

            reader1.AddReadBook(book1);
            reader1.AddReadBook(book3);
            reader1.AddReadBook(book5);

            reader2.AddReadBook(book2);
            reader2.AddReadBook(book4);

            reader3.AddReadBook(book1);
            reader3.AddReadBook(book2);
            reader3.AddReadBook(book3);
            reader3.AddReadBook(book4);
            reader3.AddReadBook(book5);

            reader1.ViewBooks();
            Console.WriteLine();
            reader2.ViewBooks();
            Console.WriteLine();
            reader3.ViewBooks();
            Console.WriteLine();
            author.View();
            Console.WriteLine();
            reader1.View();
            Console.WriteLine();

            Person o = new Reader("Czytelnik", "Testowy", 99);
            o.View();
            //author.View();
            //book.View();
        }
    }
}
//Book book = new Book("Programowanie w C#", author, new DateTime(2020, 10, 15));