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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User()
                {
                    Surname = SurnameTb.Text.Trim(),
                    Name = NameTb.Text.Trim(),
                    Middlename = MiddlenameTb.Text.Trim(),
                    DateOfBirth = DateOfBirthDp.SelectedDate.Value,
                    NumberPhone = PhoneTb.Text.Trim(),
                    Email = EmailTb.Text.Trim(),
                    GenderID = 1
                };

                Profile profile = new Profile()
                {
                    Login = LoginTb.Text.Trim(),
                    Password = PasswordPb.Password,
                    RoleID = 1
                };
                App.context.User.Add(user);
                App.context.Profile.Add(profile);

                App.context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();

                EmailTb.Text = "";
                MiddlenameTb.Text = "";
                LoginTb.Text = "";
                NameTb.Text = "";
                PhoneTb.Text = "";
                SurnameTb.Text = "";
                DateOfBirthDp.Text = "";
                PasswordPb.Password = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void EntryHl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
