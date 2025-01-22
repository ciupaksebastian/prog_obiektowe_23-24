using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BCrypt.Net;
using Npgsql;
using System.Security.Cryptography;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        private readonly string connectionString;

        public Window1(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLoginReg.Text;
            string password = txtPasswordReg.Password;
            string password2 = txtPasswordRegRep.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Login i hasło nie mogą być puste!");
                return;
            }
            if (password != password2) 
            {
                MessageBox.Show("Powtórzone hasło jest błędne");
                return;
            }

            string encryptedPassword = EncryptionHelper.Encrypt(password);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO users (login, password) VALUES (@login, @password)";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", encryptedPassword);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Użytkownik został zarejestrowany.");
                        var MainWindow = new MainWindow();
                        MainWindow.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
        }
    }

}



