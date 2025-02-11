namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            List<IOsoba> osoby = new List<IOsoba>
            {
                new Osoba { Imie = "Jan", Nazwisko = "Kowalski" },
                new Osoba { Imie = "Anna", Nazwisko = "Nowak" },
                new Osoba {Imie = "Adam", Nazwisko = "AAAAAA"}
            };
            osoby.PosortujOsobyPoNazwisku();
            osoby.WypiszOsoby();
            Console.WriteLine();

            List<IStudent> studenci = new List<IStudent>
            {
                new Student { Imie = "Jan", Nazwisko = "Kowalski", Uczelnia = "WSIiZ", Kierunek = "IID", Rok = 4, Semestr = 2 },
                new Student { Imie = "Anna", Nazwisko = "Nowak", Uczelnia = "WSIiZ", Kierunek = "IID", Rok = 3, Semestr = 1 },
                new Student { Imie = "Paweł", Nazwisko = "ANowak", Uczelnia = "WSIiZ", Kierunek = "IID", Rok = 3, Semestr = 1 }
            };
            studenci.WypiszOsoby();
            Console.WriteLine();


            List<IStudent> studenciWSIiZ = new List<IStudent>
            {
                new StudentWSIiZ { Imie = "Jan", Nazwisko = "Kowalski", Uczelnia = "WSIiZ", Kierunek = "IID", Rok = 4, Semestr = 2 },
                new StudentWSIiZ { Imie = "Anna", Nazwisko = "Nowak", Uczelnia = "WSIiZ", Kierunek = "IID", Rok = 3, Semestr = 1 }
            };

            studenciWSIiZ.WypiszOsoby();
        }
    }
}