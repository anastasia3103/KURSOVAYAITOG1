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
    /// Логика взаимодействия для AdminInformationAboutShowPage.xaml
    /// </summary>
    public partial class AdminInformationAboutShowPage : Page
    {

        private List<CategoryShow> categoryShows = App.context.CategoryShow.ToList();
        public AdminInformationAboutShowPage( object selectedShow )
        {
            InitializeComponent();

            CategoryCmb.SelectedValuePath = "Id";
            CategoryCmb.DisplayMemberPath = "Title";

            CategoryCmb.ItemsSource = categoryShows;

            DataContext = selectedShow;


            PayoutCmb.Items.Add("С оплатой");
            PayoutCmb.Items.Add("Без оплаты");
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохранить изменения?", 
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.context.SaveChanges();
                MessageBoxHelper.Information("Информация о записи успешно изменена!");
            }
            else
            {
                MessageBoxHelper.Warning("Изменения отменены");
            }
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancellationBtn_Click(object sender, RoutedEventArgs e)
        {

            //if (MessageBox.Show("Вы уверены, что хотите отменить шоу?",
            //              "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            //{
            //    return;
            //}

            //App.context.Record.Remove(selectedShow);
            //App.context.SaveChanges();

            //MessageBoxHelper.Information("Вы успешно отменили шоу.");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
