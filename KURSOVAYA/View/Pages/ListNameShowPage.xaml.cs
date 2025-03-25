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
        public ListNameShowPage()
        {
            InitializeComponent();

            ShowLv.ItemsSource = nameShow;

            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.DisplayMemberPath = "Ttitle";
            FilterCmb.ItemsSource = ageLimits;

            ageLimits.Insert(0, new AgeLimit() { Ttitle = "Все" });
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

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AgeLimit ageLimit = FilterCmb.SelectedItem as AgeLimit;
            if (FilterCmb.SelectedIndex != 0)
            {
                ShowLv.ItemsSource = nameShow.Where(x => x.AgeLimit.Id == ageLimit.Id);

            }
            else
            {
                ShowLv.ItemsSource = nameShow;
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            ShowLv.ItemsSource = nameShow.
               Where(a => a.Title.Contains(SearchTb.Text)).ToList();
        }
    }
}
