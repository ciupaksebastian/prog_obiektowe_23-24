namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "plik.txt";

            //tworzenie i zapis do pliku
            // FILE StreamWriter StreamReader

            //using (StreamWriter writer = new StreamWriter(path))
            //{
            //    writer.WriteLine("Witaj dziś jest niedziela 19.01.2025r");
            //    writer.WriteLine("TO jest przykładowyt tekst");
            //}

            //Console.WriteLine("Plik został zapisany");

            ////dodanie tekstu do pliku
            //using (StreamWriter writer = new StreamWriter(path,true))
            //{
            //    writer.WriteLine("Nowa linia, która zostałą dodana do pliku");
            //}

            //Console.WriteLine("Dodano nową linię");

            ////odczyt

            //Console.WriteLine("Zawartość pliku:");
            //using (StreamReader reader = new StreamReader(path))
            //{
            //    string linia;
            //    while((linia = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(linia);
            //    }
            //}

            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //    Console.WriteLine("Plik usunięto");
            //}
            //else
            //    Console.WriteLine("Plk nie istnieje");

            //string zawartosc = File.ReadAllText(path);
            //Console.WriteLine("Zawartość pliku: \n" + zawartosc);

            //string[] lineArr = File.ReadAllLines(path);
            //foreach (var line in lineArr)
            //    Console.WriteLine(line);

            //Directory.CreateDirectory("Zajęcia GL02");
            //Console.WriteLine("Katalog został utworzony");
            //string[] pliki = Directory.GetFiles(".");
            //foreach (string file in pliki)
            //Console.WriteLine(file);

            //main

            //Osoba osoba = new Osoba("Jan Nowak", 25);

            //string path = "osoba.json";

            ////serializacja danych
            //string json = JsonSerializer.Serialize(osoba);
            //File.WriteAllText(path, json);

            //Console.WriteLine("Obiekt został zapisany do JSON");

            ////deserializacja danych
            //string jsonD = File.ReadAllText(path);
            //Osoba inputOsoba = JsonSerializer.Deserialize<Osoba>(jsonD);
            //Console.WriteLine($"danie z pliku JSON: Osoba: {inputOsoba.Imie}, wiek: {inputOsoba.Wiek}");

            //public class Osoba
            //{
            //    public string Imie { get; set; }
            //    public int Wiek { get; set; }

            //    public Osoba(string imie, int wiek)
            //    {
            //        Imie = imie;
            //        Wiek = wiek;
            //    }
            //}


            // z1.Zadanie1();
            Console.WriteLine();
            //z1.Zadanie2();
            z1.Zadanie3();
        }
    }
}
