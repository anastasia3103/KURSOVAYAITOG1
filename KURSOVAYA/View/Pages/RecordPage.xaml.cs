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
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {

        private List<NameShow> nameShow = App.context.NameShow.ToList();
        private List<AgeLimit> ageLimits = App.context.AgeLimit.ToList();
        private List<CategoryShow> categoryShows = App.context.CategoryShow.ToList();
        public RecordPage()
        {
            InitializeComponent();

            FilterAgeCmb.SelectedValuePath = "Id";
            FilterAgeCmb.DisplayMemberPath = "Ttitle";

            FilterCategoryCmb.SelectedValuePath = "Id";
            FilterCategoryCmb.DisplayMemberPath = "Title";

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });
            categoryShows.Insert(0, new CategoryShow() { Title = "Все" });


            FilterAgeCmb.ItemsSource = ageLimits;
            FilterCategoryCmb.ItemsSource = categoryShows;

            ShowLv.ItemsSource = App.context.Record.
                Where(u => u.User.Id == App.currentUser.Id && u.IsArchived == false).ToList();

        }


        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {
            ShowLv.ItemsSource = nameShow.
             Where(a => a.Title.Contains(ActivityTb.Text)).ToList();
        }

        private void FilterAgeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndSearchShow();
        }

        private void FilterCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndSearchShow();
        }


        private void ShowLv_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecordShow = ShowLv.SelectedItem as Record;

            if (selectedRecordShow != null)
            {
                NavigationService.Navigate(new View.Pages.RecordInformationShowPage(selectedRecordShow));
            }
        }

        private void FilterAndSearchShow()
        {
            string searchText = ActivityTb.Text.Trim();
            AgeLimit ageLimit = FilterAgeCmb.SelectedItem as AgeLimit;
            CategoryShow categoryShow = FilterCategoryCmb.SelectedItem as CategoryShow;
            DateTime? selectedDate = DateDP.SelectedDate;

            var filteredShows = nameShow.Where(s =>
                           (string.IsNullOrEmpty(searchText) ||
                            s.Title.ToLower().Contains(searchText.ToLower())) &&
                           (ageLimit == null || ageLimit.Id == 0 ||
                            s.CategoryShowID == categoryShow.Id))
                           .ToList();

            ShowLv.ItemsSource = filteredShows;

        }

        private void DateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
