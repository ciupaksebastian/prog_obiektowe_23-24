namespace ConsoleApp1
{
    internal class Student : Osoba
    {
        private string NrAlbumu { get; set; }

        public Student(string firstName, string lastName, int age, string nrAlbumu) :
            base(firstName, lastName, age)
        {
            NrAlbumu = nrAlbumu;
        }
        public void ViewStudent()
        {
            View();
            Console.WriteLine($"NR albumu: {NrAlbumu}");
        }
    }
}
