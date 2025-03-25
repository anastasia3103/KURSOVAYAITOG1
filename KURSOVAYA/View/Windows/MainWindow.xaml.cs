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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KURSOVAYA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            MainUserFrame.Navigate(new View.Pages.MainPage());

        }

        private void CatalogBtn_Click(object sender, RoutedEventArgs e)
        {

            MainUserFrame.Navigate(new View.Pages.CatalogPage());
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUserFrame.Navigate(new View.Pages.MainPage());
        }

        private void MyRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUserFrame.Navigate(new View.Pages.RecordPage());
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUserFrame.Navigate(new View.Pages.ProfilePage());
        }
    }
}
