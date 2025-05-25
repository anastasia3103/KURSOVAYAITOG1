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
    /// Логика взаимодействия для AdminInformationAboutShowPage.xaml
    /// </summary>
    public partial class AdminInformationAboutShowPage : Page
    {
        public AdminInformationAboutShowPage( object selectedShow )
        {
            InitializeComponent();


            DataContext = selectedShow;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            App.context.SaveChanges();
            MessageBoxHelper.Information("Информация о записи успешно изменена!");
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
