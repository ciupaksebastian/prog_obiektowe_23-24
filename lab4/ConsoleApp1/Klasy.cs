namespace ConsoleApp1
{
    public class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }

        public int Width { get; set; }

        public Shape(int x, int y, int height, int width)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }

        public virtual void Draw()
        {
            Console.WriteLine("placeholder");
        }
    }

    public class Rectangle(int x, int y, int height, int width) : Shape(x, y, height, width)
    {
        public override void Draw()
        {
            Console.WriteLine("Rysuj prostokąt ");
            //Console.WriteLine($"X - {X}");
            //Console.WriteLine($"Y - {Y}");
            //Console.WriteLine($"wysokość - {Height}");
            //Console.WriteLine($"szerokość - {Width}");
        }
    }

    public class Triangle(int x, int y, int height, int width) : Shape(x, y, height, width)
    {
        public override void Draw()
        {
            Console.WriteLine("Rysuj trójkąt ");
        }

    }

    public class Circle(int x, int y, int height, int width) : Shape(x, y, height, width)
    {
        public override void Draw()
        {
            Console.WriteLine("Rysuj kółko ");
        }

    }

    public abstract class Osoba
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Pesel { get; private set; }
        public string School { get; private set; }


        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetPesel(string pesel)
        {
            if (pesel.Length == 11)
                Pesel = pesel;
            else
                throw new ArgumentException("Pesel musi mieć 11 znaków");
        }

        public int GetAge()
        {
            int rok = int.Parse(Pesel.Substring(0, 2));
            int miesiac = int.Parse(Pesel.Substring(2, 2));
            int dzien = int.Parse(Pesel.Substring(4, 2));

            if (miesiac > 80 && miesiac < 93)
                rok += 1800;
            else if (miesiac > 0 && miesiac < 13)
                rok += 1900;
            else if (miesiac > 20 && miesiac < 33)
                rok += 2000;
            else if (miesiac > 40 && miesiac < 53)
                rok += 2100;
            else if (miesiac > 60 && miesiac < 73)
                rok += 2200;

            DateTime dataUrodzenia = new DateTime(rok, miesiac % 20, dzien);
            int wiek = DateTime.Now.Year - dataUrodzenia.Year;

            if (DateTime.Now.Month < dataUrodzenia.Month || (DateTime.Now.Month == dataUrodzenia.Month && DateTime.Now.Day < dataUrodzenia.Day))
                wiek--;

            return wiek;
        }

        public string GetGender()
        {
            int ostatniaCyfra = int.Parse(Pesel[9].ToString());
            return (ostatniaCyfra % 2 == 0) ? "Kobieta" : "Mężczyzna";
        }
        public abstract string GetEducationInfo();
        public abstract string GetFullName();
        public abstract bool CanGoAloneToHome();
    }

    public class Uczen : Osoba
    {
        public string School { get; private set; }
        public bool MozeSamWracacDoDomu { get; private set; }

        public void SetSchool(string school)
        {
            School = school;
        }

        public void ChangeSchool(string newSchool)
        {
            School = newSchool;
        }

        public void SetCanGoHomeAlone(bool canGoHomeAlone)
        {
            MozeSamWracacDoDomu = canGoHomeAlone;
        }

        public override string GetEducationInfo()
        {
            return $"Uczeń {FirstName} uczęscza do szkoły: {School}";
        }

        public override string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override bool CanGoAloneToHome()
        {
            int age = GetAge();
            return (age > 12 || MozeSamWracacDoDomu);
        }

        public void Info()
        {
            Console.WriteLine($"Uczeń: {GetFullName()}, Wiek: {GetAge()}, Płeć: {GetGender()}");
            Console.WriteLine($"Szkoła: {School}, Może sam wracać do domu: {CanGoAloneToHome()}\n");
        }
    }

    public class Nauczyciel : Uczen
    {
        public string TytulNaukowy { get; private set; }
        public List<Uczen> PodwladniUczniowie { get; private set; }

        public Nauczyciel()
        {
            PodwladniUczniowie = new List<Uczen>();
        }

        public void DodajTytulNaukowy(string tytulNaukowy)
        {
            TytulNaukowy = tytulNaukowy;
        }

        public void DodajUcznia(Uczen uczen)
        {
            PodwladniUczniowie.Add(uczen);
        }

        public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        {
            Console.WriteLine($"Uczniowie, którzy mogą sami wrócić do domu ({dateToCheck.ToShortDateString()})");
            foreach (var uczen in PodwladniUczniowie)
            {
                if (uczen.CanGoAloneToHome())
                {
                    Console.WriteLine($"- {uczen.GetFullName()}");
                }
            }
        }
    }
}
