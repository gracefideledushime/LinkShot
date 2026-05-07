using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShot.Interfaces;
using LinkShot.Models;

namespace LinkShot.Services
{
    public abstract class SocialPlatformBase : ISocialPlatform
    {
        protected readonly List<Post> _posts = new();

        public abstract string PlatformName { get; }

        public virtual async Task CreatePostAsync(Post post)
        {
            await Task.Delay(500);
            _posts.Add(post);
        }

        public virtual async Task DeletePostAsync(Post post)
        {
            await Task.Delay(300);
            _posts.Remove(post);
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }
    }
}
