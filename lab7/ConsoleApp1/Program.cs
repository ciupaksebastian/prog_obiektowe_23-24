using Microsoft.Data.SqlClient;
// Importowanie przestrzeni nazw dla Microsoft.Data.SqlClient


class Program
{
    static string connectionString =
          "Data Source=DESKTOP-I4HQBS8\\SQLEXPRESS;" +
          "Initial Catalog=SampleDB;" +
          "Integrated Security=SSPI;" +
          "Encrypt=True;" +
          "TrustServerCertificate=True;";
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Wybierz operację:");
            Console.WriteLine("1. Dodaj klienta");
            Console.WriteLine("2. Wyświetl wszystkich klientów");
            Console.WriteLine("3. Zaktualizuj klienta");
            Console.WriteLine("4. Usuń klienta");
            Console.WriteLine("5. Wyszukaj klienta po nazwisku");
            Console.WriteLine("6. Wyjdź");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DodajKlienta();
                    break;
                case "2":
                    WyswietlKlientow();
                    break;
                case "3":
                    AktualizujKlienta();
                    break;
                case "4":
                    UsunKlienta();
                    break;
                case "5":
                    WyszukajKlienta();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór");
                    break;
            }
        }
    }

    static void DodajKlienta()
    {
        Console.WriteLine("Podaj imie:");
        string imie = Console.ReadLine();

        Console.WriteLine("Podaj nazwisko:");
        string nazwisko = Console.ReadLine();

        Console.WriteLine("Podaj email:");
        string email = Console.ReadLine();


        Console.WriteLine("Podaj numer telefonu (9 cyfr):");
        string telefon = Console.ReadLine();

        if ((telefon.Length) != 9)
        {
            Console.WriteLine("Nieprawidłowy format numeru!");
        }

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Klienci (imie, nazwisko, email, telefon) VALUES (@imie, @nazwisko, @email, @telefon)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@imie", imie);
            cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telefon", telefon);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Klient dodany pomyślnie");
        }




    }

    static void WyswietlKlientow()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Klienci";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Imię: {reader["Imie"]}, Nazwisko: {reader["Nazwisko"]}, Email: {reader["Email"]}, Telefon: {reader["Telefon"]}");
            }
        }

    }

    static void AktualizujKlienta()
    {
        Console.WriteLine("Podaj ID klienta do aktualizacji: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nowy email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Podaj nowy numer telefonu: ");
        string telefon = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "UPDATE Klienci SET Email = @email, telefon = @telefon WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@telefon", telefon);
            cmd.Parameters.AddWithValue("@id", id);
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Klient zaktualizowany pomyślnie");
            else
                Console.WriteLine("Nie znaleziono klienta o podanym ID");


        }
    }

    static void UsunKlienta()
    {
        Console.WriteLine("Podaj ID klienta do usunięcia: ");
        int id = int.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "DELETE FROM Klienci WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Klient usunięty pomyślnie");
            else
                Console.WriteLine("Nie znaleziono klienta o podanym ID");
        }
    }

    static void WyszukajKlienta()
    {
        Console.WriteLine("Podaj nazwisko do wyszukania: ");
        string naziwsko = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Klienci WHERE nazwisko LIKE @nazwisko";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nazwisko", $"%{naziwsko}%");
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Imię: {reader["Imie"]}, Nazwisko: {reader["Nazwisko"]}, Email: {reader["Email"]}, Telefon: {reader["Telefon"]}");
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono klienta o podanym nazwisku");
            }
        }
    }
}