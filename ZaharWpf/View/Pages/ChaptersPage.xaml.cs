using System.Windows;
using System.Windows.Controls;
using System.Linq;
using ZaharWpf.Model;

namespace ZaharWpf.View.Pages
{
    /// <summary>
    /// Interaction logic for ChaptersPage.xaml
    /// </summary>
    public partial class ChaptersPage : Page
    {
        private Chapters _chapter;

        public ChaptersPage(Chapters chapter)
        {
            InitializeComponent();

            _chapter = chapter;
            LoadChapterData();
        }

        private void LoadChapterData()
        {
            if (_chapter != null)
            {
                ChapterTitle.Text = _chapter.Title;

                // Получаем текст главы из соответствующей таблицы по ChapterID
                using (var context = new zahartextEntities())
                {
                    var chapterText = context.ChapterTexts.FirstOrDefault(ct => ct.ChapterID == _chapter.ChapterID);
                    if (chapterText != null)
                    {
                        ChapterText.Text = chapterText.Text;
                    }
                    else
                    {
                        MessageBox.Show("Текст главы не найден.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Глава не найдена.");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
