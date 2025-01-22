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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window

    {
        private readonly string currentUser;
        private readonly string connectionString;

        public Window2(string currentUser, string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.currentUser = currentUser;
            lblCurrentUser.Content = $"Zalogowany użytkownik: {currentUser}";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var menuWindow = new MainWindow();
            menuWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var menuAdd = new Window3(currentUser,connectionString);
            menuAdd.Show();
            this.Close();
        }
    }
}
