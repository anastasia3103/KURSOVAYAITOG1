﻿using KURSOVAYA.Model;
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
    /// Логика взаимодействия для OrderListPage.xaml
    /// </summary>
    public partial class OrderListPage : Page
    {

        private List<Record> record = App.context.Record.ToList();
        private List<NameShow> nameShow = App.context.NameShow.ToList();


        public OrderListPage()
        {
            InitializeComponent();


            FilterCmb.SelectedValuePath = "Id";
            FilterCmb.DisplayMemberPath = "Title";

            nameShow.Insert(0, new NameShow() { Title = "Все" });

            FilterCmb.ItemsSource = nameShow;

            OrderLv.ItemsSource = record;

        }

        private void OrderLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
             
        }

        private void FilterCmb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            NameShow nameShow = FilterCmb.SelectedItem as NameShow;

            if (FilterCmb.SelectedIndex != 0)
            {
                OrderLv.ItemsSource = record.
                    Where(x => x.Show.NameShow.Id == nameShow.Id);

            }
            else
            {
                OrderLv.ItemsSource = record;
            }
        }

    }
}
