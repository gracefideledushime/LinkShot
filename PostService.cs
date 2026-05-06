using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShot
{
         public class PostService
        {
            private int _idCounter = 1;

            public ObservableCollection<Post> Posts { get; } = new ObservableCollection<Post>();

            private readonly LinkedInService _linkedIn = new LinkedInService();
            private readonly HandshakeService _handshake = new HandshakeService();

            public async Task AddPostAsync(Post post)
            {
                post.Id = _idCounter++;
                Posts.Add(post);

                if (post.PostToLinkedIn)
                    await _linkedIn.PostAsync(post);

                if (post.PostToHandshake)
                    await _handshake.PostAsync(post);
            }

            public async Task DeletePostAsync(Post post)
            {
                if (post.PostToLinkedIn)
                    await _linkedIn.DeleteAsync(post);

                if (post.PostToHandshake)
                    await _handshake.DeleteAsync(post);

                Posts.Remove(post);
            }
        }
    
}
