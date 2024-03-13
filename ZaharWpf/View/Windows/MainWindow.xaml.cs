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
using ZaharWpf.Model;
using ZaharWpf.View.Pages;

namespace ZaharWpf
{
    public partial class MainWindow : Window
    {
        private Users enteredUser;

        public MainWindow(Users enteredUser)
        {
            InitializeComponent();
            this.enteredUser = enteredUser; 
            MainFrm.Navigate(new SmartSolutionsPage());
        }

        private void ProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfilPage profilPage = new ProfilPage(enteredUser);
            MainFrm.NavigationService.Navigate(profilPage);
        }

        private void LearningBtn_Click(object sender, RoutedEventArgs e)
        {
           
            LearningPage learningPage = new LearningPage(enteredUser);
        
            MainFrm.NavigationService.Navigate(learningPage);
        }

        private void ResheniaBtn_Click(object sender, RoutedEventArgs e)
        {
            SmartSolutionsPage smartSolutionsPage = new SmartSolutionsPage();
            MainFrm.NavigationService.Navigate(smartSolutionsPage);
        }
    }
}
