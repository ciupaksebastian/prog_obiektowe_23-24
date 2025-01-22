using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString;

        //private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=passmanager";
        public MainWindow()
        {
            InitializeComponent();

            // Konfiguracja za pomocą ConfigurationBuilder
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Pobranie connection string z konfiguracji
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Login i hasło nie mogą być puste!");
                return;
            }

            using var connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();

                string query = "SELECT password FROM users WHERE login=@login";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    string storedEncryptedPassword = cmd.ExecuteScalar()?.ToString();
                    
                    if (storedEncryptedPassword != null)
                    {
                        string decryptedPassword = EncryptionHelper.Decrypt(storedEncryptedPassword);

                        if (password == decryptedPassword )
                        {
                            string currentUser = login;
                            MessageBox.Show("Zalogowano");
                            var menuWindow = new Window2(currentUser,connectionString);
                            menuWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Błędne hasło!");
                        }

                        txtLogin.Clear();
                        txtPassword.Clear();
                    }
                    else 
                    {
                        MessageBox.Show("Błędny login!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
        private void OpenRegisterWindow_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new Window1(connectionString);
            registerWindow.Show();
            this.Close();
        }

    }
}

