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

            CategoryCmb.SelectedValuePath = "Id";
            CategoryCmb.DisplayMemberPath = "Title";

            PayoutCmb.Items.Add("С оплатой");
            PayoutCmb.Items.Add("Без оплаты");


            AgeLimitCmb.ItemsSource = App.context.AgeLimit.ToList();
            CategoryCmb.ItemsSource = App.context.CategoryShow.ToList();



        }

        private void AddShowBtn_Click(object sender, RoutedEventArgs e)
        {
            NameShow nameShow = new NameShow()
            {
                Title = TitleTb.Text,
                Discription = DescriptionTb.Text,
                AgeLimit = AgeLimitCmb.SelectedItem as AgeLimit,
                Photo = PhotoPathTbl.Text,
                CategoryShow = CategoryCmb.SelectedItem as CategoryShow,
                Address = AddressTb.Text,
                IsPayout = (string)PayoutCmb.SelectedItem == "С оплатой" ? true : false


            };

            App.context.NameShow.Add(nameShow);
            App.context.SaveChanges();
            MessageBoxHelper.Information("Шоу добавлено!");

            TitleTb.Text = "";
            DescriptionTb.Text = "";
            AgeLimitCmb.Text = "";
            PayoutCmb.Text = "";
            CategoryCmb.Text = "";
            AddressTb.Text = "";
        }

        private void PhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                PhotoPathTbl.Text = openFileDialog.FileName;

                MessageBoxHelper.Information("Фото успешно добавлено!");
            }
        }
    }
}
