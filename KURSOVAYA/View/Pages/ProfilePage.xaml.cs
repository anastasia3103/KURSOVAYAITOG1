using KURSOVAYA.AppData;
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

namespace KURSOVAYA.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            AboutMeGrid.DataContext = App.context.User.ToList();

            PersonalDataGrid.DataContext = App.context.Profile.ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            MainWindow mainWindow = new MainWindow();
            authorizationWindow.Show();
            mainWindow.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditTb_Click(object sender, RoutedEventArgs e)
        {
            App.context.SaveChanges();

            MessageBoxHelper.Information("Информация успешно изменена!");
        }
    }
}
