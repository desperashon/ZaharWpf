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

           
            if (_solutions != null)
            {
               
                if (!string.IsNullOrEmpty(_solutions.Image))
                {
                    var bitmapImage = new BitmapImage(new Uri(_solutions.Image, UriKind.RelativeOrAbsolute));
                    solutionImage.Source = bitmapImage;
                }

              
                solutionTitle.Text = _solutions.Title;

 
                solutionDescription.Text = _solutions.Description;
            }
        }

        private void BackBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
