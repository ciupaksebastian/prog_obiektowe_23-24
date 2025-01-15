using System.ComponentModel.Design;

namespace ConsoleApp1
{
    internal class Student2
    {
        private string FirstName;
        private string LastName;
        private double[] grades; 
        private int countGrades;

        public Student2(string FirstName, string LastName, int maxGrades = 10)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            grades = new double[maxGrades]; 
            countGrades = 0;
        }

        public double SredniaOcen
        {
            get
            {
                if (grades == null || countGrades == 0)
                {
                    Console.WriteLine("Tablica nie może być pusta lub brak ocen.");
                    return 0;
                }
                double sum = 0;
                for (int i = 0; i < countGrades; i++)
                {
                    sum += grades[i];
                }
                return sum / countGrades; 
            }
        }

        public void AddGrades(double ocena)
        {
            if (ocena < 2 || ocena > 5)
            {
                Console.WriteLine($"Ocena musi byc z przedzialu 2-5. Podana ocena: {ocena:F2}");
                return;
            }
            if (countGrades >= grades.Length)
            {
                Console.WriteLine("Nie mozna dodac wiecej ocen. Tablica jest pełna");
                return;
            }
            grades[countGrades] = ocena;
            countGrades++;
            Console.WriteLine($"Dodano ocenę: {ocena:F1}. Aktualna średnia: {SredniaOcen:F2}");
        }
    }
}
