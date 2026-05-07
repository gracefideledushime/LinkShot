using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShot.Models;

namespace LinkShot.Services
{
    public class LinkedInService : SocialPlatformBase
    {
        public override string PlatformName => "LinkedIn";

        public override async Task CreatePostAsync(Post post)
        {
            await base.CreatePostAsync(post);

            Debug.WriteLine($"[LinkedIn] {post.Content}");
        }
    }
}
