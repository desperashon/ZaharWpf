using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ZaharWpf.Model;
using static System.Net.Mime.MediaTypeNames;

namespace ZaharWpf.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для DescriptionSmartSolutionsPage.xaml
    /// </summary>
    public partial class DescriptionSmartSolutionsPage : Page
    {
        public DescriptionSmartSolutionsPage(Solutions _solutions)
        {
            InitializeComponent();

            // Устанавливаем свойства элементов управления на основе переданного объекта Solutions
            if (_solutions != null)
            {
                // Установка изображения
                if (!string.IsNullOrEmpty(_solutions.Image))
                {
                    var bitmapImage = new BitmapImage(new Uri(_solutions.Image, UriKind.RelativeOrAbsolute));
                    solutionImage.Source = bitmapImage;
                }

                // Установка заголовка
                solutionTitle.Text = _solutions.Title;

                // Установка описания
                solutionDescription.Text = _solutions.Description;
            }
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
