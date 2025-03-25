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
    /// Логика взаимодействия для RecordInformationShowPage.xaml
    /// </summary>
    public partial class RecordInformationShowPage : Page
    {
        public RecordInformationShowPage(object selectedShow)
        {
            InitializeComponent();


            DataContext = selectedShow;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.MainUserFrame.Navigate(new View.Pages.RecordPage());
        }

        private void RemoveRecordBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
