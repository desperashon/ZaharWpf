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

namespace ZaharWpf.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SmartSolutionsPage.xaml
    /// </summary>
    public partial class SmartSolutionsPage : Page
    {
        public SmartSolutionsPage()
        {
            InitializeComponent();
            basketLb.ItemsSource = App.context.Solutions.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTb.Text.ToLower(); 

           
            var filteredSolutions = App.context.Solutions.Where(solution => solution.Title.ToLower().Contains(searchText)).ToList();

         
            basketLb.ItemsSource = filteredSolutions;
        }


        private void basketLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            var selectedSolution = (sender as ListBox).SelectedItem as Solutions;

            
            if (selectedSolution != null)
            {
                
                NavigationService?.Navigate(new DescriptionSmartSolutionsPage(selectedSolution));
            }
        }
    }
}
