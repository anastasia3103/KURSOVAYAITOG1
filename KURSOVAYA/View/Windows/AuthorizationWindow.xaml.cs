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
using System.Windows.Shapes;

namespace KURSOVAYA
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Profile currentUser = App.context.Profile.FirstOrDefault(p => p.Login == LoginTb.Text
                && p.Password == PasswordPb.Password);

                if (currentUser != null)
                {
                    App.currentUser = currentUser;
                    MessageBoxHelper.Information("Авторизация прошла успешно!");

                    ArchiveRecord();

                    if (currentUser.RoleID == 1)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        AdminMainWindow adminMainWindow = new AdminMainWindow();
                        adminMainWindow.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBoxHelper.Warning("Пользователь не найден!");
                }

            }
            catch (Exception exception)
            {
                MessageBoxHelper.Error(exception);
            }
        }



        public void ArchiveRecord()
        {
            List<Record> records = App.context.Record.ToList();

            foreach (Record record in records)
            {
                DateTime dateTime = record.Show.Date.Add(record.Show.EndTime);

                if (dateTime < DateTime.Now)
                {
                    record.IsArchived = true;
                    record.Show.StatusID = 3;

                    App.context.SaveChanges();
                }
            }
        }

        private void RegHl_Click(object sender, RoutedEventArgs e)
        {

            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
