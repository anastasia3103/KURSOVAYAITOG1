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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        private List<Show> show = App.context.Show.OrderByDescending(s => s.Date).ToList();
        private List<AgeLimit> ageLimits = App.context.AgeLimit.ToList();
        private List<CategoryShow> categoryShows = App.context.CategoryShow.ToList();
        public CatalogPage()
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

        private void MoreInformationBtn_Click(object sender, RoutedEventArgs e)
        {
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
            var selectedShow = ShowLv.SelectedItem as Show;


            if (selectedShow == null) return;
            NavigationService.Navigate(new View.Pages.InformationAboutShowPage(selectedShow));

        }

        private void FilterAndSearchShow()
        {
            string search = ActivityTb.Text;
            AgeLimit ageLimit = FilterAgeCmb.SelectedItem as AgeLimit;
            CategoryShow categoryShow = FilterCategoryCmb.SelectedItem as CategoryShow;
            //DateTime selectedDate = DateDP.SelectedDate == null ? DateTime.MinValue : DateDP.SelectedDate.Value;

            if (ageLimit != null && categoryShow != null  /* && selectedDate != null*/ && search != null)
            {

                var filteredShow = show.Where(s => (string.IsNullOrEmpty(search) || s.NameShow.Title.ToLower().Contains(search.ToLower())) &&
                (ageLimit.Id == 0 || s.NameShow.AgeLimitID == ageLimit.Id) &&
                (categoryShow.Id == 0 || s.NameShow.CategoryShowID == categoryShow.Id));
                //(string.IsNullOrEmpty(selectedDate.ToShortDateString()) ||*/ s.Date.ToShortDateString() == selectedDate.ToShortDateString()));

                ShowLv.ItemsSource = filteredShow;
            }

        }

        private void DateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndSearchShow();
        }
    }
}

