using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShot.Models;

namespace LinkShot.Services
{
        public class HandshakeService : SocialPlatformBase
        {
            public override string PlatformName => "Handshake";

            public override async Task CreatePostAsync(Post post)
            {
                await base.CreatePostAsync(post);

                Debug.WriteLine($"[Handshake] {post.Content}");
            }
        }
    
}
