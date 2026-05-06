using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShot
{
    public class HandshakeService
    {
        public async Task PostAsync(Post post)
        {
            await Task.Delay(500);
            Debug.WriteLine($"[Handshake] Posted: {post.Content}");
        }

        public async Task DeleteAsync(Post post)
        {
            await Task.Delay(300);
            Debug.WriteLine($"[Handshake] Deleted: {post.Content}");
        }
    }
}
