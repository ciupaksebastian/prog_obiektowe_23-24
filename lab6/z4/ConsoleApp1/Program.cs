using Newtonsoft.Json;
namespace ConsoleApp2
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            var data = LoadData("db.json");

            while (true)
            {
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Różnica populacji Indii między 1970 a 2000");
                Console.WriteLine("2. Różnica populacji USA między 1965 a 2010");
                Console.WriteLine("3. Różnica populacji Chin między 1980 a 2018");
                Console.WriteLine("4. Wyświetl populację dla wybranego kraju i roku");
                Console.WriteLine("5. Oblicz różnicę populacji dla wybranego zakresu lat i kraju");
                Console.WriteLine("6. Oblicz procentowy wzrost populacji dla każdego kraju względem roku poprzedniego");
                Console.WriteLine("7. Wyjdź");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculatePopulationDifference(data, "IN", 1970, 2000);
                        break;
                    case "2":
                        CalculatePopulationDifference(data, "US", 1965, 2010);
                        break;
                    case "3":
                        CalculatePopulationDifference(data, "CN", 1980, 2018);
                        break;
                    case "4":
                        DisplayPopulationForYearAndCountry(data);
                        break;
                    case "5":
                        CalculateCustomPopulationDifference(data);
                        break;
                    case "6":
                        CalculatePercentageGrowth(data);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }

            static List<PopulationRecord> LoadData(string filePath)
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<PopulationRecord>>(json);
            }

            static void CalculatePopulationDifference(List<PopulationRecord> data, string countryCode, int startYear, int endYear)
            {
                var startPopulation = data.FirstOrDefault(d => d.Country.Id == countryCode && d.Date == startYear.ToString())?.Value;
                var endPopulation = data.FirstOrDefault(d => d.Country.Id == countryCode && d.Date == endYear.ToString())?.Value;

                if (startPopulation == null || endPopulation == null)
                {
                    Console.WriteLine("Brak danych dla podanego zakresu lat lub kraju.");
                    return;
                }

                var difference = long.Parse(endPopulation) - long.Parse(startPopulation);
                Console.WriteLine($"Różnica populacji dla {GetCountryName(countryCode)} między {startYear} a {endYear} wynosi: {Math.Abs(difference)}");
            }

            static void DisplayPopulationForYearAndCountry(List<PopulationRecord> data)
            {
                Console.WriteLine("Podaj kod kraju.");
                var countryCode = Console.ReadLine().ToUpper();

                Console.Write("Podaj rok:");
                var year = Console.ReadLine();

                var record = data.FirstOrDefault(d => d.Country.Id == countryCode && d.Date == year);

                if (record == null)
                {
                    Console.WriteLine("Brak danych dla podanego kraju i roku.");
                    return;
                }

                Console.WriteLine($"Populacja {GetCountryName(countryCode)} w roku {year} wynosi: {record.Value}");
            }

            static void CalculateCustomPopulationDifference(List<PopulationRecord> data)
            {
                Console.Write("Podaj kod kraju (np. IN, CN, US): ");
                var countryCode = Console.ReadLine().ToUpper();

                Console.Write("Podaj początkowy rok: ");
                var startYear = Console.ReadLine();

                Console.Write("Podaj końcowy rok: ");
                var endYear = Console.ReadLine();

                CalculatePopulationDifference(data, countryCode, int.Parse(startYear), int.Parse(endYear));
            }

            static void CalculatePercentageGrowth(List<PopulationRecord> data)
            {
                var countries = new[] { "IN", "CN", "US" };

                foreach (var countryCode in countries)
                {
                    var countryData = data.Where(d => d.Country.Id == countryCode).OrderBy(d => d.Date).ToList();

                    for (int i = 1; i < countryData.Count; i++)
                    {
                        if (countryData[i].Value == null)
                        {
                            Console.WriteLine($"Brak danych dla {GetCountryName(countryCode)} w roku {countryData[i].Date}");
                            continue;
                        }

                        var previousYearPopulation = long.Parse(countryData[i - 1].Value);
                        var currentYearPopulation = long.Parse(countryData[i].Value);

                        if (previousYearPopulation == 0)
                        {
                            Console.WriteLine($"Brak danych dla {GetCountryName(countryCode)} w roku {countryData[i - 1].Date}");
                            continue;
                        }

                        var growthPercentage = ((currentYearPopulation - previousYearPopulation) / (double)previousYearPopulation) * 100;
                        Console.WriteLine($"Procentowy wzrost populacji {GetCountryName(countryCode)} w roku {countryData[i].Date}: {growthPercentage:F2}%");
                    }
                }
            }

            static string GetCountryName(string countryCode)
            {
                return countryCode switch
                {
                    "IN" => "Indie",
                    "CN" => "Chiny",
                    "US" => "USA",
                    _ => "Nieznany kraj"
                };
            }

        }
        public class PopulationRecord
        {
            public Indicator Indicator { get; set; }
            public Country Country { get; set; }
            public string Value { get; set; }
            public string Decimal { get; set; }
            public string Date { get; set; }
        }

        public class Indicator
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }

        public class Country
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }
    }

}
