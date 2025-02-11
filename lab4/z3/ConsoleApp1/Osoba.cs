namespace ConsoleApp1
{
    public class Osoba : IOsoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string ZwrocPelnaNazwe()
        {
            return $"{Imie} {Nazwisko}";
        }
    }

    public static class OsobaExtension
    {
        public static void WypiszOsoby(this List<IOsoba> osoby)
        {
            foreach (var osoba in osoby)
            {
                Console.WriteLine($"{osoba.Imie} {osoba.Nazwisko}");
            }
        }

        public static void WypiszOsoby(this List<IStudent> studenci)
        {
            foreach (var student in studenci)
            {
                if (student is StudentWSIiZ)
                {
                    Console.WriteLine(((StudentWSIiZ)student).WypiszPelnaNazweIUczelnie());
                }
                else
                {
                    Console.WriteLine(student.ZwrocPelnaNazwe());
                }
            }
        }

        public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
        {
            osoby.Sort((o1, o2) => string.Compare(o1.Nazwisko, o2.Nazwisko, StringComparison.Ordinal));
        }
    }
}
