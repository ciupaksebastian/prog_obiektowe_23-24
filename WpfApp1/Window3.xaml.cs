using Npgsql;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private readonly string connectionString;
        private readonly string currentUser;
        public Window3(string currentUser, string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.currentUser = currentUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string site = txtSite.Text;
            string user = txtUser.Text;
            string password = txtPassword.Password;
            string password2 = txtPasswordRep.Password;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("User i hasło nie mogą być puste!");
                return;
            }
            if (password != password2)
            {
                MessageBox.Show("Powtórzone hasło jest błędne");
                return;
            }

            string encryptedPassword = EncryptionHelper.Encrypt(password);
            int userId = 0;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT employee_id FROM users WHERE login=@login";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", currentUser);
                        //userId = cmd.ExecuteScalar()?.ToString();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
                try
                {
                    string query = "INSERT INTO passwords (user_id, username, site, password) VALUES (@user_id, @user, @site, @password)";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@user_id",userId);
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@site", site);
                        cmd.Parameters.AddWithValue("@password", encryptedPassword);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Dodano hasło.");
                        var MainWindow = new Window2(currentUser, connectionString);
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
