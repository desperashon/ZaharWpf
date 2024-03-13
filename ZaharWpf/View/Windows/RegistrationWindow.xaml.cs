using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ZaharWpf.Model;

namespace ZaharWpf.View.Windows
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            InitializeProgrammingLanguages();
        }

        private void InitializeProgrammingLanguages()
        {
            using (var context = new zahartextEntities())
            {
                var programmingLanguages = context.ProgrammingLanguages.Select(p => p.Name).ToList();
                foreach (var language in programmingLanguages)
                {
                    ProgrammingLanguageCmb.Items.Add(language);
                }
            }
        }


        private void RegistretionBtn_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(EmailTb.Text))
            {
                errorMessage += "Введите email\n";
            }
            else if (!IsValidEmail(EmailTb.Text))
            {
                errorMessage += "Введите корректный email\n";
            }

            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
            {
                errorMessage += "Введите пароль\n";
            }
            else if (!IsStrongPassword(PasswordPb.Password))
            {
                errorMessage += "Введите пароль, содержащий не менее 8 символов, включая заглавные и строчные буквы, цифры и специальные символы\n";
            }

            if (string.IsNullOrWhiteSpace(ProgrammingLanguageCmb.Text))
            {
                errorMessage += "Выберите ЯП\n";
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                return;
            }

          
            using (var context = new zahartextEntities())
            {
                var existingUser = context.Users.FirstOrDefault(u => u.Email == EmailTb.Text);
                if (existingUser != null)
                {
                    MessageBox.Show("Пользователь с таким email уже зарегистрирован.");
                    return;
                }
            }

            Users user = new Users()
            {
                Email = EmailTb.Text,
                Password = PasswordPb.Password,
                ProgrammingLanguages = ProgrammingLanguageCmb.SelectedItem as ProgrammingLanguages,
                Photo = PhotoUrlTb.Text,
            };

       
            App.context.Users.Add(user);
            App.enteredUser = user;
            App.context.SaveChanges();

            MessageBox.Show("Успешная регистрация!");
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            this.Close();
            authorizationWindow.Show();
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private bool IsStrongPassword(string password)
        {
         
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
           AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            this.Close();
            authorizationWindow.Show();
        }
    }
}
