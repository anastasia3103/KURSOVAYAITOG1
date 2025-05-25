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

        private List<Show> show = App.context.Show.ToList();
        public RecordPage()
        {
            InitializeComponent();

            FilterAgeCmb.SelectedValuePath = "Id";
            FilterAgeCmb.DisplayMemberPath = "Ttitle";
            FilterAgeCmb.ItemsSource = App.context.AgeLimit.ToList();

            FilterCategoryCmb.SelectedValuePath = "Id";
            FilterCategoryCmb.DisplayMemberPath = "Title";
            FilterCategoryCmb.ItemsSource = App.context.CategoryShow.ToList();

            App.context.AgeLimit.ToList().Insert(0, new AgeLimit() { Ttitle = "Все" });
            App.context.CategoryShow.ToList().Insert(0, new CategoryShow() { Title = "Все" });


            ShowLv.ItemsSource = App.context.Record.
                Where(u => u.User.Id == App.currentUser.Id).ToList();
        }



        private void MoreInformationBtn_Click(object sender, RoutedEventArgs e)
        {

        }
 

        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {
            ShowLv.ItemsSource = show.
             Where(a => a.NameShow.Title.Contains(ActivityTb.Text)).ToList();
        }

        private void FilterAgeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AgeLimit ageLimit = FilterAgeCmb.SelectedItem as AgeLimit;
            if (FilterAgeCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = App.context.Record.
                Where(u => u.User.Id == App.currentUser.Id).ToList().Where(x => x.Show.NameShow.AgeLimit.Id == ageLimit.Id);

            }
            else
            {


                ShowLv.ItemsSource = App.context.Record.
                    Where(u => u.User.Id == App.currentUser.Id).ToList();
            }
        }

        private void FilterCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CategoryShow categoryShows = FilterCategoryCmb.SelectedItem as CategoryShow;
            if (FilterCategoryCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = App.context.Record.
                Where(u => u.User.Id == App.currentUser.Id).ToList().Where(x => x.Show.NameShow.CategoryShow.Id == categoryShows.Id);


            }
            else
            {


                ShowLv.ItemsSource = App.context.Record.
                    Where(u => u.User.Id == App.currentUser.Id).ToList();
            }
        }

        private void ShowLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedShow = ShowLv.SelectedItem as Show;


            if (selectedShow == null) return;
            NavigationService.Navigate(new View.Pages.RecordInformationShowPage(selectedShow));
        }

        private void ShowLv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var selectedShow = ShowLv.SelectedItem as Show;


            if (selectedShow == null) return;
            NavigationService.Navigate(new View.Pages.RecordInformationShowPage(selectedShow));
        }
    }
}
