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
                var existingRecord = App.context.Record.FirstOrDefault
                    (r => r.UserID == App.currentUser.Id && r.ShowID == _selectedShow.Id);

                if (existingRecord != null)
                {
                    MessageBoxHelper.Warning("Вы уже зарегистрированы на это шоу!");
                    return;
                }

                int registeredCount = App.context.Record.Count(r => r.ShowID == _selectedShow.Id);

                if (registeredCount >= _selectedShow.QtyPersons)
                {
                    MessageBoxHelper.Warning("Извините, все места на это шоу уже заняты!");
                    return;
                }

                Record record = new Record()
                {
                    UserID = App.currentUser.Id,
                    ShowID = _selectedShow.Id,
                    IsArchived = false                
                };

                App.context.Record.Add(record);
                App.context.SaveChanges();

                MessageBoxHelper.Information($"Вы успешно записались на шоу! ");
            }
        }

        private void BackBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
