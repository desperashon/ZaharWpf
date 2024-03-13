using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZaharWpf.Model;

namespace ZaharWpf.View.Pages
{
    /// <summary>
    /// Interaction logic for ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        private Users currentUser;

        public ProfilPage(Users enteredUser)
        {
            InitializeComponent();
            currentUser = enteredUser;
            FillUserData();
            FillProgrammingLanguagesComboBox();
            FillUserPhoto();
        }

        private void FillUserData()
        {
            if (currentUser != null)
            {
                EmailTextBox.Text = currentUser.Email;
                PasswordBox.Password = currentUser.Password;
            }
        }

        private void FillProgrammingLanguagesComboBox()
        {
            
            ProgrammingLanguageComboBox.DisplayMemberPath = "Name";
            ProgrammingLanguageComboBox.SelectedValuePath = "LanguageID";
            ProgrammingLanguageComboBox.ItemsSource = App.context.ProgrammingLanguages.ToList();

            if (currentUser != null && currentUser.LanguageID != null)
            {
                int selectedLanguageID = currentUser.LanguageID.Value;
                foreach (var item in ProgrammingLanguageComboBox.Items)
                {
                    if ((item as ProgrammingLanguages).LanguageID == selectedLanguageID)
                    {
                        ProgrammingLanguageComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void FillUserPhoto()
        {
            if (currentUser != null && !string.IsNullOrEmpty(currentUser.Photo))
            {
                try
                {
                    
                    BitmapImage bitmap = new BitmapImage(new Uri(currentUser.Photo));
                    UserPhoto.Source = bitmap; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке фото: {ex.Message}");
                }
            }
        }


        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
  
                Users existingUser = App.context.Users.FirstOrDefault(u => u.UserID == currentUser.UserID);

                if (existingUser != null)
                {
                    
                    existingUser.Email = EmailTextBox.Text;
                    existingUser.Password = PasswordBox.Password;
                    if (ProgrammingLanguageComboBox.SelectedItem != null)
                    {
                        existingUser.LanguageID = (ProgrammingLanguageComboBox.SelectedItem as ProgrammingLanguages).LanguageID;
                    }

              
                    App.context.SaveChanges();

                    MessageBox.Show("Изменения сохранены успешно.");
                }
                else
                {
                    MessageBox.Show("Ошибка: пользователь не найден.");
                }
            }
            else
            {
                MessageBox.Show("Ошибка: пользователь не определен.");
            }
        }
    }
}
