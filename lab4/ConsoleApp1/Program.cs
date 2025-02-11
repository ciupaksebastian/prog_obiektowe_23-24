namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Shape> shapes = [new Rectangle(10, 10, 50, 100), new Triangle(20, 20, 60, 80), new Circle(30, 30, 70, 70)];

            //foreach (var shape in shapes)
            //{
            //    shape.Draw();
            //}

            //Osoba osoba = new Osoba();
            //osoba.SetPesel("022117728237");
            //osoba.SetFirstName("imie");
            //osoba.SetLastName("nazwisko");

            //int wiek = osoba.GetAge();
            //string plec = osoba.GetGender();
            //Console.WriteLine(wiek);
            //Console.WriteLine(plec);

            Uczen uczen1 = new();
            uczen1.SetFirstName("Jan");
            uczen1.SetLastName("Kowalski");
            uczen1.SetPesel("05210212345");
            uczen1.SetSchool("Szkoła Podstawowa nr 1");
            uczen1.SetCanGoHomeAlone(true);

            Uczen uczen2 = new();
            uczen2.SetFirstName("Adam");
            uczen2.SetLastName("Nowak");
            uczen2.SetPesel("15221593112");
            uczen2.SetSchool("Szkoła Podstawowa nr 2");
            uczen2.SetCanGoHomeAlone(false);

            Uczen uczen3 = new();
            uczen3.SetFirstName("uczen");
            uczen3.SetLastName("testowy");
            uczen3.SetPesel("11211756354");
            uczen3.SetSchool("Szkoła Podstawowa nr 3");
            uczen3.SetCanGoHomeAlone(false);

            uczen1.Info();
            uczen2.Info();
            uczen3.Info();

            Nauczyciel nauczyciel = new();
            nauczyciel.DodajTytulNaukowy("Dr");
            nauczyciel.DodajUcznia(uczen1);
            nauczyciel.DodajUcznia(uczen3);
            nauczyciel.DodajUcznia(uczen2);

            nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Now);


        }
    }
}
