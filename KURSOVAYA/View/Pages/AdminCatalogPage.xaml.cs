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

            FilterCategoryCmb.SelectedValuePath = "Id";
            FilterCategoryCmb.DisplayMemberPath = "Title";

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });
            categoryShows.Insert(0, new CategoryShow() { Title = "Все" });

            FilterAgeCmb.ItemsSource = ageLimits;
            FilterCategoryCmb.ItemsSource = categoryShows;
        }

        private void AddShowRecorbBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecordsWindow addRecordsWindow = new AddRecordsWindow();

            if (addRecordsWindow.ShowDialog() == true)
            {
                ShowLv.ItemsSource = App.context.Show.ToList();
            }

        }


        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {

            FilterAndSearchShow();
        }

        private void FilterAgeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FilterAndSearchShow();
        }

        private void FilterCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FilterAndSearchShow();
        }

        private void ShowLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedShow = ShowLv.SelectedItem as Show;


            //if (selectedShow == null) return;
            //NavigationService.Navigate(new View.Pages.AdminInformationAboutShowPage(selectedShow));
        }

        private void FilterAndSearchShow()
        {
            string searchText = SearchTb.Text.Trim();
            AgeLimit ageLimit = FilterAgeCmb.SelectedItem as AgeLimit;
            CategoryShow categoryShow = FilterCategoryCmb.SelectedItem as CategoryShow;
            DateTime? selectedDate = DateDP.SelectedDate;

            var filteredShows = show.Where(s =>
                (string.IsNullOrEmpty(searchText) ||
                 s.NameShow.Title.ToLower().Contains(searchText.ToLower())) &&
                (ageLimit == null || ageLimit.Id == 0 ||
                 s.NameShow.AgeLimitID == ageLimit.Id) &&
                (categoryShow == null || categoryShow.Id == 0 ||
                 s.NameShow.CategoryShowID == categoryShow.Id) &&
                (!selectedDate.HasValue ||
                 s.Date.Date == selectedDate.Value.Date))
                .ToList();

            ShowLv.ItemsSource = filteredShows;
        }


    }
}
