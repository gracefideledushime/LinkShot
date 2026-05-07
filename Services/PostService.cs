using LinkShot.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShot.Models;

namespace LinkShot
{
    public class PostService
    {
        private int _idCounter = 1;

        public ObservableCollection<Post> AllPosts { get; } = new();

        public LinkedInService LinkedIn { get; } = new();
        public HandshakeService Handshake { get; } = new();

        public async Task AddPostAsync(Post post)
        {
            post.Id = _idCounter++;

            AllPosts.Add(post);

            // Create platform-specific copies
            if (post.PostToLinkedIn)
            {
                var linkedInCopy = post.Clone();

                await LinkedIn.CreatePostAsync(linkedInCopy);
            }

            if (post.PostToHandshake)
            {
                var handshakeCopy = post.Clone();

                await Handshake.CreatePostAsync(handshakeCopy);
            }
        }

        public async Task UpdatePostAsync(
     Post originalPost,
     string newContent,
     string newImagePath,
     bool updateLinkedIn,
     bool updateHandshake)
        {
            await Task.Delay(300);

            // Update LinkedIn version only
            if (updateLinkedIn)
            {
                var linkedInPost =
                    LinkedIn.GetPosts()
                    .FirstOrDefault(p => p.Id == originalPost.Id);

                if (linkedInPost != null)
                {
                    linkedInPost.Content = newContent;
                    linkedInPost.ImagePath = newImagePath;
                }
            }

            // Update Handshake version only
            if (updateHandshake)
            {
                var handshakePost =
                    Handshake.GetPosts()
                    .FirstOrDefault(p => p.Id == originalPost.Id);

                if (handshakePost != null)
                {
                    handshakePost.Content = newContent;
                    handshakePost.ImagePath = newImagePath;
                }
            }
        }

        public async Task DeletePostAsync(Post post)
        {
            if (post == null)
                return;

            // Remove from LinkedIn
            if (post.PostToLinkedIn)
            {
                await LinkedIn.DeletePostAsync(post);
            }

            // Remove from Handshake
            if (post.PostToHandshake)
            {
                await Handshake.DeletePostAsync(post);
            }

            // Remove from master collection
            AllPosts.Remove(post);
        }

        // LINQ Examples
        public List<Post> GetLinkedInPosts()
        {
            return LinkedIn.GetPosts()
                .OrderByDescending(p => p.Timestamp)
                .ToList();
        }

        public List<Post> GetHandshakePosts()
        {
            return Handshake.GetPosts()
                .OrderByDescending(p => p.Timestamp)
                .ToList();
        }

        public List<Post> SearchPosts(string keyword)
        {
            return AllPosts
                .Where(p => p.Content.Contains(keyword))
                .ToList();
        }
    }

}
