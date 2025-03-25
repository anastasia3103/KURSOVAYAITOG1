using KURSOVAYA.AppData;
using KURSOVAYA.Model;
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
    /// Логика взаимодействия для InformationAboutShowPage.xaml
    /// </summary>
    public partial class InformationAboutShowPage : Page
    {

        private Show _selectedShow;
        public InformationAboutShowPage(object selectedShow) 
        {
            InitializeComponent();

            _selectedShow = selectedShow as Show;

            DataContext = selectedShow;

        }

        private void RecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedShow != null)
            {
                Record record = new Record()
                {
                    UserID = App.currentUser.Id,
                    ShowID = _selectedShow.Id
                };

                App.context.Record.Add(record);
                App.context.SaveChanges();

                MessageBoxHelper.Information("Вы успешно записались на шоу");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.MainUserFrame.Navigate(new CatalogPage());
        }
    }
}
