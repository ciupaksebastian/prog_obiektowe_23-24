using ConsoleApp1;
using System;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> people = [];

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

            Reviewer reviewer1 = new Reviewer("Recenzent", "Pierwszy", 20);
            Reviewer reviewer2 = new Reviewer("Recenzent", "Drugi", 29);
            Reviewer reviewer3 = new Reviewer("Recenzent", "Trzeci", 44);

            reviewer3.AddReadBook(book5);
            reviewer3.AddReadBook(book4);

            reviewer1.AddReadBook(book1);
            reviewer1.AddReadBook(book4);

            reviewer2.AddReadBook(book2);
            reviewer2.AddReadBook(book3);

            people.Add(author1);
            people.Add(reviewer1);
            people.Add(reviewer2);
            people.Add(reader1);
            people.Add(reader2);
            //reviewer1.Wypisz();
            //Console.WriteLine();

            //reviewer2.Wypisz();
            //Console.WriteLine();

            //reviewer3.View();
            //Console.WriteLine();
            //reader1.ViewBooks();
            //Console.WriteLine();
            //reader2.ViewBooks();
            //Console.WriteLine();
            //reader3.ViewBooks();
            //Console.WriteLine();
            //author.View();
            //Console.WriteLine();
            //reader1.View();
            //Console.WriteLine();

            //Person o = new Reader("Czytelnik", "Testowy", 99);
            //o.View();
            //author.View();
            //book.View();


            //foreach (var person in people)
            //{
            //    person.View();
            //}

            AdventureBook adventureBook1 = new("Harry Potter and the Philosopher's Stone", author, new DateTime(1997, 6, 26), "Harry Potter");
            AdventureBook adventureBook2 = new("Harry Potter and the Chamber of Secrets", author, new DateTime(1998, 7, 2), "Harry Potter");

            DocumentaryBook documentaryBook1 = new("Cosmos", new Person("Carl", "Sagan", 62), new DateTime(1980, 10, 1), "Astronomia");
            DocumentaryBook documentaryBook2 = new("A Brief History of Time", new Person("Stephen", "Hawking", 76), new DateTime(1988, 4, 1), "Fizyka");

            List<Book> books =
            [
                adventureBook1,
                adventureBook2,
                documentaryBook1,
                documentaryBook2
            ];


            Reader reader10 = new("Czytelnik", "testowy", 99);
            reader10.AddReadBook(documentaryBook1);
            reader10.AddReadBook(book1);
            reader10.ViewBooks();
            //foreach (var book in books)
            //{
            //    book.View();
            //}
        }
    }
}
//Book book = new Book("Programowanie w C#", author, new DateTime(2020, 10, 15));