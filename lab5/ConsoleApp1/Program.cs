namespace Kalkulator
{
    enum Operacja
    {
        Dodawanie,
        Odejmowanie,
        Mnozenie,
        Dzielenie
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<double> wyniki = [];
            bool kontynuuj = true;

            while (kontynuuj)
            {
                try
                {
                    Console.WriteLine("Podaj pierwszą liczbę: ");
                    double liczba1 = double.Parse(Console.ReadLine());

                    Console.WriteLine("Podaj drugą liczbę: ");
                    double liczba2 = double.Parse(Console.ReadLine());

                    Console.WriteLine("Wybierz operację: ");
                    Console.WriteLine("1. Dodawanie");
                    Console.WriteLine("2. Odejmowanie");
                    Console.WriteLine("3. Mnożenie");
                    Console.WriteLine("4. Dzielenie");
                    Console.Write("Twój wybór (1-4): ");
                    int wybor = int.Parse(Console.ReadLine());

                    if (wybor < 1 || wybor > 4)
                    {
                        Console.WriteLine("Nieprawidłowa operacja. Wybierz liczbę od 1 do 4.");
                        continue;
                    }

                    Operacja operacja = (Operacja)(wybor - 1);
                    double wynik = WykonajOperacje(liczba1, liczba2, operacja);

                    wyniki.Add(wynik);
                    Console.WriteLine($"Wynik: {wynik}");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Błąd: Wprowadzono nieprawidłowe dane. Podaj liczby");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
                }

                Console.WriteLine("Czy chcesz wykonać kolejne obliczenie? (Y/N)");
                string odpowiedz = Console.ReadLine().ToLower();
                if (odpowiedz != "y")
                {
                    kontynuuj = false;
                }
            }

            Console.WriteLine("\nHistoria wyników:");
            foreach (var wynik in wyniki)
            {
                Console.WriteLine(wynik);
            }

            static double WykonajOperacje(double liczba1, double liczba2, Operacja operacja)
            {
                switch (operacja)
                {
                    case Operacja.Dodawanie:
                        return liczba1 + liczba2;
                    case Operacja.Odejmowanie:
                        return liczba1 - liczba2;
                    case Operacja.Mnozenie:
                        return liczba1 * liczba2;
                    case Operacja.Dzielenie:
                        if (liczba2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        return liczba1 / liczba2;
                    default:
                        throw new InvalidOperationException("Nieznana operacja");
                }
            }
        }
    }
}
