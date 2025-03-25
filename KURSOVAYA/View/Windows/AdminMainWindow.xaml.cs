using KURSOVAYA.View.Pages;
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

namespace KURSOVAYA.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddShowBtn_Click(object sender, RoutedEventArgs e)
        {

            MainAdminFrame.Navigate(new View.Pages.ListNameShowPage());

        }

        private void CatalogBtn_Click_1(object sender, RoutedEventArgs e)
        {

            MainAdminFrame.Navigate(new View.Pages.AdminCatalogPage());

        }


        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            MainAdminFrame.Navigate(new View.Pages.OrderListPage());

        }
    }
}
