using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinkShot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            private readonly PostService _postService = new PostService();

            public MainWindow()
            {
                InitializeComponent();
                PostList.ItemsSource = _postService.Posts;
            }

            private async void Post_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(ContentBox.Text))
                {
                    MessageBox.Show("Post content cannot be empty.");
                    return;
                }

                var post = new Post
                {
                    Content = ContentBox.Text,
                    ImagePath = ImageBox.Text,
                    PostToLinkedIn = LinkedInCheck.IsChecked == true,
                    PostToHandshake = HandshakeCheck.IsChecked == true
                };

                await _postService.AddPostAsync(post);

                ContentBox.Text = "";
                ImageBox.Text = "";
                LinkedInCheck.IsChecked = false;
                HandshakeCheck.IsChecked = false;
            }

            private async void Delete_Click(object sender, RoutedEventArgs e)
            {
                var button = sender as FrameworkElement;
                var post = button.Tag as Post;

                if (post != null)
                {
                    await _postService.DeletePostAsync(post);
                }
            }

        private void ContentBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }