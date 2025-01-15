namespace ConsoleApp1
{
    internal class Licz
    {
        private double value { get; set; }

        public Licz(double initialValue)
        {
            value = initialValue;
        }
        public void Dodaj(double add)
        {
            value += add;
            Console.WriteLine($"Dodano {add}. Aktualna wartość: {value}");
        }
        public void Odejmij(double odj)
        {
            value -= odj;
            Console.WriteLine($"Odjęto {odj}. Aktualna wartość: {value}");
        }

        public void View()
        {
            Console.WriteLine($"Suma: {value}");
        }
    }
}
