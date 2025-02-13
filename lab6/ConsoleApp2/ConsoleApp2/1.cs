namespace ConsoleApp2
{


    internal class z1
    {
        public static void Zadanie1()
        {
            Console.WriteLine("Podaj nazwę pliku: ");
            string nazwa = Console.ReadLine();
            Console.WriteLine("Podaj nr albumu: ");
            string nrAlbumu = Console.ReadLine();

            File.WriteAllText(nazwa, nrAlbumu);
            Console.WriteLine("Nr albumu zapisano do pliku.");
        }

        public static void Zadanie2()
        {
            Console.WriteLine("Podaj nazwę pliku: ");
            string nazwa = Console.ReadLine();

            if (File.Exists(nazwa))
            {
                Console.WriteLine("Zawartość pliku:");
                using (StreamReader reader = new StreamReader(nazwa))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(linia);
                    }
                }
            }
            else
                Console.WriteLine("Plik nie istnieje");
        }

        public static void Zadanie3()
        {
            string path = "pesel.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Plik pesel.txt nie istnieje.");
                return;
            }

            var pesels = File.ReadAllLines(path);
            int nr = pesels.Count(p => p.Length == 11 && (p[9] - '0') % 2 == 0);

            Console.WriteLine($"Liczba żeńskich numerów PESEL: {nr}");
        }
    }
}