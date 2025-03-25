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
        private List<Show> show = App.context.Show.ToList();
        private List<AgeLimit> ageLimits = App.context.AgeLimit.ToList();
        public CatalogPage()
        {
            InitializeComponent();

            ShowLv.ItemsSource = show;

            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.DisplayMemberPath = "Ttitle";
            FilterCmb.ItemsSource = ageLimits;

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });
        }

        private void MoreInformationBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var selectedShow = button.DataContext as Show; 
            if (selectedShow == null) return;
            NavigationService.Navigate(new View.Pages.InformationAboutShowPage(selectedShow));
        }

        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {
            ShowLv.ItemsSource = show.
               Where(a => a.NameShow.Title.Contains(ActivityTb.Text)).ToList();
        }

        private void FilterCmb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
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
    }
}

