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
using System.Windows.Shapes;

namespace KURSOVAYA.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddRecordsWindow.xaml
    /// </summary>
    public partial class AddRecordsWindow : Window
    {
        public AddRecordsWindow()
        {
            InitializeComponent();

            TitleCmb.SelectedValuePath = "Id";
            TitleCmb.DisplayMemberPath = "Title";
            TitleCmb.ItemsSource = App.context.NameShow.ToList();
        }


        private void AddRecordBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TitleCmb.Text))
                mes += "Ввыберите название шоу\n";
            if (string.IsNullOrWhiteSpace(DateDp.Text))
                mes += "Выберите дату\n";
            if (string.IsNullOrWhiteSpace(StartTimeTb.Text))
                mes += "Введите время начала\n";
            if (string.IsNullOrWhiteSpace(EndTimeTb.Text))
                mes += "Введите время окончания\n";
            if (string.IsNullOrWhiteSpace(QtyTb.Text))
                mes += "Введите количество людей\n";
            if (mes != "")
            {
                MessageBoxHelper.Warning(mes);
                mes = "";
                return;
            }
            try
                {
                int qtyPersons;
                if (!int.TryParse(QtyTb.Text, out qtyPersons))
                {
                    MessageBox.Show("Количество мест должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                TimeSpan startTime;
                if (!TimeSpan.TryParse(StartTimeTb.Text, out startTime))
                {
                    MessageBox.Show("Время начала указано неверно! Формат времени должен быть H:mm:ss", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                TimeSpan endTime;
                if (!TimeSpan.TryParse(EndTimeTb.Text, out endTime))
                {
                    MessageBox.Show("Время окончания указано неверно! Формат времени должен быть H:mm:ss", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Show show = new Show()
                    {
                        Date = (DateTime)DateDp.SelectedDate,
                        Title = TitleCmb.SelectedItem as NameShow,
                        StartTime = TimeSpan.Parse(StartTimeTb.Text),
                        EndTime = TimeSpan.Parse(EndTimeTb.Text),
                        QtyPersons = Convert.ToInt32(QtyTb.Text)
                    };

                    App.context.Show.Add(show);
                    App.context.SaveChanges();
                    MessageBoxHelper.Information("Шоу добавлено!");

                    TitleCmb.Text = "";
                    EndTimeTb.Text = "";
                    StartTimeTb.Text = "";
                    DateDp.Text = "";
                    QtyTb.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании объекта шоу: {ex.Message}");
                }

        }

        private void AddShowBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNameShowWindow addNameShowWindow = new AddNameShowWindow();
            addNameShowWindow.ShowDialog();
        }
    }
}
