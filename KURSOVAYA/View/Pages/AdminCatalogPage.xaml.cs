using KURSOVAYA.AppData;
using KURSOVAYA.Model;
using KURSOVAYA.View.Windows;
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
    /// Логика взаимодействия для AdminCatalogPage.xaml
    /// </summary>
    public partial class AdminCatalogPage : Page
    {
        private List<Show> show = App.context.Show.ToList();
        private List<AgeLimit> ageLimits = App.context.AgeLimit.ToList();
        public AdminCatalogPage()
        {
            InitializeComponent();

            ShowLv.ItemsSource = show;

            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.DisplayMemberPath = "Ttitle";
            FilterCmb.ItemsSource = ageLimits;

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });
        }

        private void AddShowRecorbBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecordsWindow addRecordsWindow = new AddRecordsWindow();

            if (addRecordsWindow.ShowDialog() == true)
            {
                ShowLv.ItemsSource = App.context.Show.ToList();
            }

        }

        private void DeleteShowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShowLv.SelectedItem == null)
            {
                MessageBoxHelper.Information("Выберите шоу для удаления");
                return;
            }

            Show selectedShow = ShowLv.SelectedItem as Show;

            var res = MessageBox.Show($"Вы уверены, что хотите удалить?",
                "Подтверждение", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                App.context.Show.Remove(selectedShow);
                App.context.SaveChanges();
                MessageBoxHelper.Information("Удалено");
            }
                ShowLv.ItemsSource = show;
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            AgeLimit ageLimit = FilterCmb.SelectedItem as AgeLimit;
            if (FilterCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = show.Where(x => x.NameShow.AgeLimit.Id == ageLimit.Id);

            }
            else
            {
                ShowLv.ItemsSource = show;
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowLv.ItemsSource = show.
               Where(a => a.NameShow.Title.Contains(SearchTb.Text)).ToList();
        }

        private void MoreInformationBtn_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            if (button == null) return;

            var selectedShow = button.DataContext as Show;
            if (selectedShow == null) return;
            NavigationService.Navigate(new View.Pages.AdminInformationAboutShowPage(selectedShow));
        }
    }
}
