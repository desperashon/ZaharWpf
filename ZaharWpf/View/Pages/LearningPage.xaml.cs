using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using ZaharWpf.Model;
using System.Linq;

namespace ZaharWpf.View.Pages
{
    public partial class LearningPage : Page
    {
        private zahartextEntities dbContext = App.context;

        public class LearningPageData
        {
            public List<Chapters> Chapters { get; set; }
        }

        public LearningPage(Users enteredUser)
        {
            InitializeComponent();
            App.enteredUser = enteredUser;
            TitleTb.Text = enteredUser.ProgrammingLanguages.Name.ToString();
            DataContext = GetLearningPageData(enteredUser);
        }

        private LearningPageData GetLearningPageData(Users enteredUser)
        {
            var learningPageData = new LearningPageData();
            if (enteredUser != null)
            {
                var currentUserLanguageID = enteredUser.LanguageID;

             
                ProgrammingLanguages selectedLanguage = dbContext.ProgrammingLanguages.FirstOrDefault(lang => lang.LanguageID == currentUserLanguageID);

                if (selectedLanguage != null)
                {
      
                    Books book = dbContext.Books.FirstOrDefault(b => b.LanguageID == selectedLanguage.LanguageID);

                    if (book != null)
                    {
    
                        learningPageData.Chapters = dbContext.Chapters.Where(c => c.BookID == book.BookID).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Книга не найдена для выбранного языка программирования");
                    }
                }
                else
                {
                    MessageBox.Show("Язык программирования не найден для текущего пользователя");
                }
            }
            else
            {
                MessageBox.Show("Текущий пользователь не задан");
            }

            return learningPageData;
        }

        private void OpenChapter(Chapters chapter)
        {
            MessageBox.Show($"Открыта глава: {chapter.Title}");
        }

        private void GlavaBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Chapters chapter = button?.DataContext as Chapters;
            if (chapter != null)
            {
                ChaptersPage chaptersPage = new ChaptersPage(chapter);
                NavigationService.Navigate(chaptersPage);
            }
        }

    }
}
