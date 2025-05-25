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
            Show show = new Show()
            {
                TitleID = Convert.ToInt32(TitleCmb.SelectedItem as NameShow),
                Date = (DateTime)DateDp.SelectedDate,
                StartTime = TimeSpan.Parse(StartTimeTb.Text),
                EndTime = TimeSpan.Parse(EndTimeTb.Text),
                QtyPersons= Convert.ToInt32(QtyTb.Text)
            };


            App.context.Show.Add(show);
            App.context.SaveChanges();
            MessageBoxHelper.Information("Занятие добавлено!");

            TitleCmb.Text = "";
            EndTimeTb.Text = "";
            StartTimeTb.Text = "";
            DateDp.Text = "";
            QtyTb.Text = "";

        }

        private void AddShowBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNameShowWindow addNameShowWindow = new AddNameShowWindow();
            addNameShowWindow.ShowDialog();
        }
    }
}
