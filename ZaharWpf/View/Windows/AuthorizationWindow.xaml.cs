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
using ZaharWpf.Model;

namespace ZaharWpf.View.Windows
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

        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            Users user = App.context.Users
                        .FirstOrDefault(w => w.Password == PasswordPb.Password && w.Email == LoginTb.Text);

            if (user != null)
            {
                App.enteredUser = user;

                MainWindow midWindow = new MainWindow(user);
                midWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
                PasswordPb.Clear();
                LoginTb.Clear();
            }
        }

        private void RegistretionBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }

    }
}
