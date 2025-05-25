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
        private List<Show> show = App.context.Show.OrderByDescending(s => s.Date).ToList();
        private List<AgeLimit> ageLimits = App.context.AgeLimit.ToList();
        private List<CategoryShow> categoryShows = App.context.CategoryShow.ToList();
        public AdminCatalogPage()
        {
            InitializeComponent();

            ShowLv.ItemsSource = show;

            FilterAgeCmb.SelectedValuePath = "Id";
            FilterAgeCmb.DisplayMemberPath = "Ttitle";
            FilterAgeCmb.ItemsSource = ageLimits;

            FilterCategoryCmb.SelectedValuePath = "Id";
            FilterCategoryCmb.DisplayMemberPath = "Title";
            FilterCategoryCmb.ItemsSource = categoryShows;

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });
            categoryShows.Insert(0, new CategoryShow() { Title = "Все" });
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


        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {

            ShowLv.ItemsSource = show.
               Where(a => a.NameShow.Title.Contains(SearchTb.Text)).ToList();
        }

        private void FilterAgeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            AgeLimit ageLimit = FilterAgeCmb.SelectedItem as AgeLimit;
            if (FilterAgeCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = show.Where(x => x.NameShow.AgeLimit.Id == ageLimit.Id);

            }
            else
            {
                ShowLv.ItemsSource = show;
            }
        }

        private void FilterCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CategoryShow categoryShows = FilterCategoryCmb.SelectedItem as CategoryShow;
            if (FilterCategoryCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = show.Where(x => x.NameShow.CategoryShow.Id == categoryShows.Id);

            }
            else
            {
                ShowLv.ItemsSource = show;
            }
        }

        private void ShowLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedShow = ShowLv.SelectedItem as Show;


            if (selectedShow == null) return;
            NavigationService.Navigate(new View.Pages.AdminInformationAboutShowPage(selectedShow));
        }
    }
}
