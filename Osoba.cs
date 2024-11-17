using ConsoleApp1;

//RunBank();


//Dziedziczenie();

//RunLicz();
Zadanie3();
void Zadanie3()
{
    Student2 student2 = new Student2("Jan", "Nowak");
    student2.AddGrades(4);
    student2.AddGrades(4);
}

static void RunLicz()
{
    Licz licz = new Licz(100);
    licz.View();
    licz.Dodaj(50);
    licz.View();
    licz.Odejmij(200);
    licz.View();
}

void Dziedziczenie()
{
    Student student = new Student("Jan", "Nowak",24,"w12345");
    student.View();
    student.ViewStudent();
}
static void RunBank()
{
    BankAccount bankAccount = new BankAccount(4500m, "Jan Kowalski");

    bankAccount.View();
    bankAccount.Wplata(500m);

    bankAccount.View();
    bankAccount.Wyplata(500000m);
}

//Console.WriteLine("Podaj imie: ");
//string firstName = Console.ReadLine();

//Console.WriteLine("Podaj nazwisko");
//string lastName = Console.ReadLine();

//Console.WriteLine("Podaj wiek ");
//int age = int.Parse(Console.ReadLine());

//Osoba osoba = new Osoba(firstName, lastName, age);
//osoba.View();