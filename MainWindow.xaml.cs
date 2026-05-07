using LinkShot.Models;
using LinkShot.Services;

using System;
using System.Windows;
using System.Windows.Controls;

namespace LinkShot
{
    public partial class MainWindow : Window
    {
        private readonly AuthService _authService = new();
        private readonly PostService _postService = new();

        private Post? _selectedPost;

        public MainWindow()
        {
            InitializeComponent();

            RefreshFeeds();
        }

        private void RefreshFeeds()
        {
            LinkedInList.ItemsSource = null;
            LinkedInList.ItemsSource = _postService.GetLinkedInPosts();

            HandshakeList.ItemsSource = null;
            HandshakeList.ItemsSource = _postService.GetHandshakePosts();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            bool success = await _authService.LoginAsync(
                UsernameBox.Text,
                PasswordBox.Password);

            AuthStatusText.Text =
                success
                ? "Authenticated successfully."
                : "Invalid credentials.";
        }

        private async void Post_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_authService.IsAuthenticated)
                {
                    MessageBox.Show("Please login first.");
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

                RefreshFeeds();

                ClearEditor();

                StatusText.Text = "Post published.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedPost == null)
                {
                    MessageBox.Show("Select a post first.");
                    return;
                }

                await _postService.UpdatePostAsync(
                    _selectedPost,
                    ContentBox.Text,
                    ImageBox.Text,
                    LinkedInCheck.IsChecked == true,
                    HandshakeCheck.IsChecked == true);

                RefreshFeeds();

                StatusText.Text = "Post updated.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedPost == null)
                {
                    MessageBox.Show("Select a post first.");
                    return;
                }

                await _postService.DeletePostAsync(_selectedPost);

                RefreshFeeds();

                ClearEditor();

                StatusText.Text = "Post deleted.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LinkedInList_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (LinkedInList.SelectedItem is Post post)
            {
                LoadPost(post);
            }
        }

        private void HandshakeList_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (HandshakeList.SelectedItem is Post post)
            {
                LoadPost(post);
            }
        }

        private void LoadPost(Post post)
        {
            _selectedPost = post;

            ContentBox.Text = post.Content;
            ImageBox.Text = post.ImagePath;

            LinkedInCheck.IsChecked = post.PostToLinkedIn;
            HandshakeCheck.IsChecked = post.PostToHandshake;
        }

        private void ClearEditor()
        {
            _selectedPost = null;

            ContentBox.Text = "";
            ImageBox.Text = "";

            LinkedInCheck.IsChecked = false;
            HandshakeCheck.IsChecked = false;
        }

        private void ContentBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            CharacterCountText.Text =
                $"{ContentBox.Text.Length} characters";
        }
    }
}