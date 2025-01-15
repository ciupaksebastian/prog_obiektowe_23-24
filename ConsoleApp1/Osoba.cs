namespace ConsoleApp1;


internal class Osoba
{


    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value.Length > 2) firstName = value;
            else Console.WriteLine("Imie musi posiadać co najmniej 2 znaki!");
        }
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value.Length > 2) firstName = value;
            else Console.WriteLine("Nazwisko musi posiadać co najmniej 2 znaki!");
        }

    }
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0) Console.WriteLine("wiek nie moze byc liczba ujemna");
            else age = value;
        }
    }


    public Osoba(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public void View()
    {
        Console.WriteLine($"Imie:\t{firstName}" + $"Nazwisko:\t{lastName}" + $"wiek:\t{age}");
    }
}