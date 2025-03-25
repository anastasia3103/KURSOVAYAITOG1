using KURSOVAYA.AppData;
using KURSOVAYA.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddNameShowWindow.xaml
    /// </summary>
    public partial class AddNameShowWindow : Window
    {
        NameShow _nameShow = new NameShow();
        public AddNameShowWindow()
        {
            InitializeComponent();

            AgeLimitCmb.SelectedValuePath = "Id";
            AgeLimitCmb.DisplayMemberPath = "Ttitle";
            AgeLimitCmb.ItemsSource = App.context.AgeLimit.ToList();
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void AddShowBtn_Click(object sender, RoutedEventArgs e)
        {
            NameShow nameShow = new NameShow()
            {
                Title = TitleTb.Text,
                Discription = DescriptionTb.Text,
                AgeLimit = AgeLimitCmb.SelectedItem as AgeLimit,
                Photo = PhotoTb.Text

            };

            App.context.NameShow.Add(nameShow);
            App.context.SaveChanges();
            MessageBoxHelper.Information("Шоу добавлено!");

            TitleTb.Text = "";
            DescriptionTb.Text = "";
            AgeLimitCmb.Text = "";
            PhotoTb.Text = "";
        }
    }
}
