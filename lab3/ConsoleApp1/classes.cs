using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public Person(string firstName, string lastName, int age)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
        }

        public virtual void View()
        {
            Console.WriteLine($"Osoba: {FirstName} {LastName}, Wiek: {Age}");
            Console.WriteLine();
        }
    }

    public class Book
    {
        protected string _title;
        protected Person _author;
        protected DateTime _releaseDate;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Person Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        public Book(string title, Person author, DateTime releaseDate)
        {
            _title = title;
            _author = author;
            _releaseDate = releaseDate;

        }

        public virtual void View()
        {
            Console.WriteLine($"Książka:  {_title}");
            Console.WriteLine($"Autor:  {_author.FirstName} {_author.LastName}");
            Console.WriteLine($"Data wydania: {_releaseDate}");
        }

    }

    public class Reader : Person
    {
        private List<Book> _readBooks;

        public List<Book> ReadBooks
        {
            get { return _readBooks; }
            set { _readBooks = value; }
        }

        public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            _readBooks = new List<Book>();
        }

        public void AddReadBook(Book book)
        {
            _readBooks.Add(book);
        }


        protected List<Book> GetReadBooks()
        {
            return _readBooks;
        }

        public void ViewBooks()
        {
            Console.WriteLine($"Książki przeczytane przez {FirstName} {LastName}:");
            foreach (var book in _readBooks)
            {
                book.View();
            }
        }

        public override void View()
        {
            Console.WriteLine($"Osoba: {FirstName} {LastName}, Wiek: {Age}");
            ViewBooks();
            Console.WriteLine();
        }
    }

    public class Reviewer : Reader
    {
        public Reviewer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public override void View()
        {
            Console.WriteLine($"Recenzent: {FirstName} {LastName}");
            var books = GetReadBooks();
            Random random = new();

            foreach (var book in books)
            {
                int ocena = random.Next(1, 11);
                Console.WriteLine($"- {book.Title} (Ocena: {ocena})");
            }
            Console.WriteLine();
        }


    }

    public class AdventureBook(string title, Person author, DateTime releaseDate, string mainCharacter) : Book(title, author, releaseDate)
    {
        public string MainCharacter { get; set; } = mainCharacter;

        public override void View()
        {
            base.View();
            Console.WriteLine($"Główny bohater: {MainCharacter}");
            Console.WriteLine();
        }
    }

    public class DocumentaryBook(string title, Person author, DateTime releaseDate, string topic) : Book(title, author, releaseDate)
    {
        public string Topic { get; set; } = topic;

        public override void View()
        {
            base.View();
            Console.WriteLine($"Temat: {Topic}");
            Console.WriteLine();
        }
    }
}
