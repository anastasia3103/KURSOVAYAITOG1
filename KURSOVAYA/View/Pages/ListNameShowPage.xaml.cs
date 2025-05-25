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
    /// Логика взаимодействия для ListNameShowPage.xaml
    /// </summary>
    public partial class ListNameShowPage : Page
    {
        private List<NameShow> nameShow = App.context.NameShow.ToList();
        private List<AgeLimit> ageLimits = App.context.AgeLimit.ToList();
        private List<CategoryShow> categoryShows = App.context.CategoryShow.ToList();
        public ListNameShowPage()
        {
            InitializeComponent();

            ShowLv.ItemsSource = nameShow;

            FilterAgeCmb.SelectedValuePath = "Id";
            FilterAgeCmb.DisplayMemberPath = "Ttitle";
            FilterAgeCmb.ItemsSource = ageLimits;

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });

            FilterCategoryCmb.SelectedValuePath = "Id";
            FilterCategoryCmb.DisplayMemberPath = "Title";
            FilterCategoryCmb.ItemsSource = categoryShows;

            categoryShows.Insert(0, new CategoryShow() { Title = "Все" });
        }

        private void DeleteShowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShowLv.SelectedItem == null)
            {
                MessageBoxHelper.Information("Выберите шоу для удаления");
                return;
            }

            NameShow selectedNameShow = ShowLv.SelectedItem as NameShow;

            var res = MessageBox.Show($"Вы уверены, что хотите удалить?",
                "Подтверждение", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                App.context.NameShow.Remove(selectedNameShow);
                App.context.SaveChanges();
                MessageBoxHelper.Information("Удалено");
            }
            ShowLv.ItemsSource = nameShow;
        }

        private void AddShowRecorbBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNameShowWindow addNameShowWindow = new AddNameShowWindow();
            addNameShowWindow.ShowDialog();
        }


        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            ShowLv.ItemsSource = nameShow.
               Where(a => a.Title.Contains(SearchTb.Text)).ToList();
        }


        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {

            ShowLv.ItemsSource = nameShow.
               Where(a => a.Title.Contains(SearchTb.Text)).ToList();
        }

        private void FilterAgeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            AgeLimit ageLimit = FilterAgeCmb.SelectedItem as AgeLimit;
            if (FilterAgeCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = nameShow.Where(x => x.AgeLimit.Id == ageLimit.Id);

            }
            else
            {
                ShowLv.ItemsSource = nameShow;
            }
        }

        private void FilterCategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
