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
        public RecordPage()
        {
            InitializeComponent();

            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.DisplayMemberPath = "Ttitle";
            FilterCmb.ItemsSource = App.context.AgeLimit.ToList();

            App.context.AgeLimit.ToList().Insert(0, new AgeLimit() { Ttitle = "Все" });


            ShowLv.ItemsSource = App.context.Record.
                Where(u => u.User.Id == App.currentUser.Id).ToList();
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void FilterCmb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MoreInformationBtn_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            if (button == null) return;

            var selectedShow = button.DataContext as Show;
            if (selectedShow == null) return;
            FrameHelper.MainUserFrame.Navigate(new RecordInformationPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            if (ShowLv.SelectedItem == null)
            {
                MessageBoxHelper.Information("Выберите шоу для отмены");
                return;
            }

            Record selectedShow = ShowLv.SelectedItem as Record;

            var res = MessageBox.Show($"Вы уверены, что хотите удалить?",
                "Подтверждение", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                App.context.Record.Remove(selectedShow);
                App.context.SaveChanges();
                MessageBoxHelper.Information("Удалено");
                ShowLv.ItemsSource = App.context.Record.
                Where(u => u.User.Id == App.currentUser.Id).ToList();
            }
        }
    }
}
