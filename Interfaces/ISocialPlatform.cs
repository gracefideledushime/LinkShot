using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShot.Models;

namespace LinkShot.Interfaces
{
    public interface ISocialPlatform
    {
        string PlatformName { get; }

        Task CreatePostAsync(Post post);

        Task DeletePostAsync(Post post);

        List<Post> GetPosts();
    }
}
