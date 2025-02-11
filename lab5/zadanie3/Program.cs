namespace zadanie3
{
    enum Kolor
    {
        Czerwony,
        Niebieski,
        Zielony,
        Żółty,
        Fioletowy
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Kolor> kolory = new List<Kolor>()
            {
                Kolor.Czerwony,
                Kolor.Niebieski,
                Kolor.Zielony,
                Kolor.Żółty,
                Kolor.Fioletowy
            };

            Random random = new Random();
            Kolor wylosowanyKolor = kolory[random.Next(kolory.Count)];

            bool isTrue = false;

            Console.WriteLine("Gra do zgadywania kolorów. Dostępne kolory: ");
            int i = 1;
            foreach (var kolor in kolory)
            {
                Console.WriteLine($"{i} - {kolor} ");
                i++;
            }

            while (!isTrue)
            {
                try
                {
                    Console.WriteLine("Zgadnij kolor: ");
                    string strzal = Console.ReadLine();

                    Kolor wybranyKolor = (Kolor)Enum.Parse(typeof(Kolor), strzal, true);

                    if (wybranyKolor == wylosowanyKolor)
                    {
                        Console.WriteLine("Gratulacje, zgadłeś wylosowany kolor!");
                        isTrue = true;
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy strzał. Spróbuj ponownie.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Nieprawidłowy kolor, nie ma takiego na liście!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
                }
            }
            Console.WriteLine("Koniec gry.");
        }
    }
}