namespace zadanie2
{
    enum StatusZamowienia
    {
        Oczekujące,
        Przyjęte,
        Zrealizowane,
        Anulowane
    }
    class Program
    {
        private static readonly Dictionary<int, (List<string> Produkty, StatusZamowienia Status)> zamowienia = [];
        static void Main(string[] args)
        {
            bool kontynuuj = true;

            while (kontynuuj)
            {
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1.Dodaj nowe zamówienie:");
                Console.WriteLine("2.Zmień status zamówienia:");
                Console.WriteLine("3.Wyświetl wszystkie zamówienia:");
                Console.WriteLine("4.Zakońćz program:");
                Console.WriteLine("Twój wybór: ");

                string wybor = Console.ReadLine();

                switch (wybor)
                {
                    case "1":
                        DodajZamowienie();
                        break;
                    case "2":
                        ZmienStatusZamowienia();
                        break;
                    case "3":
                        WyswietlZamowienia();
                        break;
                    case "4":
                        kontynuuj = false;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void DodajZamowienie()
        {
            Console.Write("Podaj numer zamówienia: ");
            int numerZamowienia = int.Parse(Console.ReadLine());

            if (zamowienia.ContainsKey(numerZamowienia))
            {
                Console.WriteLine("Zamówienie o podanym numerze już istnieje");
                return;
            }

            Console.Write("Podaj produkty (oddzielone przecinkami: ");
            string podajProdukty = Console.ReadLine();
            List<string> produkty = new List<string>(podajProdukty.Split(','));

            zamowienia[numerZamowienia] = (produkty, StatusZamowienia.Oczekujące);
            Console.WriteLine("Zamówienie dodane pomyślnie");
        }

        static void ZmienStatusZamowienia()
        {
            try
            {
                Console.WriteLine("Podaj numer zamówienia: ");
                int numerZamowienia = int.Parse(Console.ReadLine());

                if (!zamowienia.ContainsKey(numerZamowienia))
                {
                    throw new KeyNotFoundException("Zamówienie o podanym numerze nie istnieje.");
                }

                Console.WriteLine("Dostępne statusy: ");
                int i = 1;
                foreach (var status in Enum.GetValues(typeof(StatusZamowienia)))
                {
                    Console.WriteLine($"{i} - {status}");
                    i++;
                }

                Console.WriteLine("Podaj nowy status: ");
                int wyborStatusu = int.Parse(Console.ReadLine());
                if (wyborStatusu < 1 || wyborStatusu > Enum.GetValues(typeof(StatusZamowienia)).Length)
                {
                    throw new KeyNotFoundException("Nieprawidłowy numer statusu");
                }

                StatusZamowienia nowyStatus = (StatusZamowienia)(wyborStatusu - 1);
                var zamowienie = zamowienia[numerZamowienia];

                if (zamowienie.Status == nowyStatus)
                {
                    throw new ArgumentException("Nowy status jest taki sam co poprzednio");
                }
                zamowienia[numerZamowienia] = (zamowienie.Produkty, nowyStatus);
                Console.WriteLine("Status zamówienia zmieniony pomyślnie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
        }

        static void WyswietlZamowienia()
        {
            if (zamowienia.Count == 0)
            {
                Console.WriteLine("Brak zamówień.");
                return;
            }

            Console.WriteLine("\nLista zamówień:");
            foreach (var zamowienie in zamowienia)
            {
                Console.WriteLine($"Numer zamówienia: {zamowienie.Key}");
                Console.WriteLine($"Produkty: {string.Join(", ", zamowienie.Value.Produkty)}");
                Console.WriteLine($"Status: {zamowienie.Value.Status}");
                Console.WriteLine();
            }
        }
    }
}
