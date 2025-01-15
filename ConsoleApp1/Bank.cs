namespace ConsoleApp1
{
    internal class BankAccount
    {
        public decimal Saldo { get; private set; }
        public string Wlasciciel { get; set; }

        public BankAccount(decimal saldo, string wlasciciel)
        {
            Saldo = saldo;
            Wlasciciel = wlasciciel;
        }

        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota do wpłaty nie może być ujemna");
                return;
            }
            Saldo += kwota;
            Console.WriteLine($"Wpłacono: {kwota:C}. Aktualny stan konta: {Saldo:C}.");
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota do wyłaty nie może być ujemna");
                return;
            }
            if (kwota > Saldo)
            {
                Console.WriteLine("Niewystarczajaco środków na koncie!");
                return;
            }
            Saldo -= kwota;
            Console.WriteLine($"Wypłacono: {kwota:C}. Aktualny stan konta: {Saldo:C}.");
        }

        public void View()
        {
            Console.WriteLine($"Właściciel : {Wlasciciel}\t\tSaldo: {Saldo}");
        }
    }
}
