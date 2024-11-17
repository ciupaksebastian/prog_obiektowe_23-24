namespace ConsoleApp1
{
    internal class Licz
    {
        public int Value { get; set; }

        public Licz(int value) 
        {
            Value = value;
        }
        public void Dodaj(int add)
        {
            Value += add;
        }
        public void Odejmij(int odj)
        {
            Value -= odj;
        }

        public void View()
        {
            Console.WriteLine($"Suma: {Value}");
        }
    }
}
