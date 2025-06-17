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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private List<Record> record = App.context.Record.OrderByDescending(s => s.Show.Date).ToList();
        private List<User> user = App.context.User.Where(u => u.Id == App.currentUser.Id).ToList();
        public ProfilePage()
        {
            InitializeComponent();

            AboutMeGrid.DataContext = App.context.User
                .FirstOrDefault(u => u.ProfileID == App.currentUser.Id);


            PersonalDataGrid.DataContext = App.context.Profile.Where(u => u.Id == App.currentUser.Id).ToList();


            ShowLv.ItemsSource = record.
                Where(u => u.User.Id == App.currentUser.Id && u.IsArchived == true).ToList();


        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();

            MainWindow mw = Window.GetWindow(this) as MainWindow;
            mw.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditTb_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохранить изменения?",
                "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.context.SaveChanges();
                MessageBoxHelper.Information("Информация о записи успешно изменена!");
            }
            else
            {
                MessageBoxHelper.Warning("Изменения отменены");
            }
        }

        private void ShowLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RatingCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Record selectedRecord = ShowLv.SelectedItem as Record;
            //int rating = Convert.ToInt32(((sender as ComboBox).SelectedItem as ComboBoxItem).Content);

            //if (selectedRecord != null)
            //{
            //    if (MessageBoxHelper.Question("Выставить оценку?") == true)
            //    {
            //        selectedRecord.Rating = rating;
            //        App.context.SaveChanges();
            //    }
            //}
            ComboBox comboBox = sender as ComboBox;
            Record selectedRecord = ShowLv.SelectedItem as Record;

            if (selectedRecord != null && comboBox.SelectedItem != null)
            {
                int rating = Convert.ToInt32(((sender as ComboBox).SelectedItem as ComboBoxItem).Content);

                if (MessageBoxHelper.Question("Вы действительно хотите выставить данную оценку?") == true)
                {// Сохраняем новую оценку
                    selectedRecord.Rating = rating;
                    App.context.SaveChanges();

                    // Извлекаем сохранённую ссылку на TextBlock из свойства Tag
                    TextBlock ratingText = comboBox.Tag as TextBlock;

                    // Переключаемся между элементами
                    comboBox.Visibility = Visibility.Collapsed;
                    ratingText.Text = $"Вы уже выставили оценку {rating}.";
                    ratingText.Visibility = Visibility.Visible;
                }
            }
        }

    }
}
