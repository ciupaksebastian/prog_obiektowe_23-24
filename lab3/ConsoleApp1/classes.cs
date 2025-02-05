using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public virtual void View()
        {
            Console.WriteLine($"Osoba: {FirstName} {LastName}, Wiek: {Age}");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Book(string title, Person author, DateTime releaseDate)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;

        }

        public void View()
        {
            Console.WriteLine($"Książka:  {Title}");
            Console.WriteLine($"Autor:  {Author.FirstName} {Author.LastName}");
            Console.WriteLine($"Data wydania: {ReleaseDate}");
        }

    }

    public class Reader : Person
    {
        public List<Book> ReadBooks { get; set; }

        public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age) 
        { 
            ReadBooks = new List<Book>();
        }

        public void AddReadBook(Book book)
        { 
            ReadBooks.Add(book); 
        }


        public void ViewBooks()
        {
            Console.WriteLine($"Książki przeczytane przez {FirstName} {LastName}:");
            foreach (var book in ReadBooks)
            {
                Console.WriteLine($"- {book.Title}");
            }
        }

        public override void View()
        {
            Console.WriteLine($"Osoba: {FirstName} {LastName}, Wiek: {Age}");
            ViewBooks();
        }
    }






}
