using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShot.Models;

namespace LinkShot.Test
{
    public static class TestData
    {
        public static List<Post> GenerateTestPosts()
        {
            return Enumerable.Range(1, 10)
                .Select(i => new Post
                {
                    Id = i,
                    Content = $"Test Post #{i}",
                    PostToLinkedIn = i % 2 == 0,
                    PostToHandshake = i % 3 == 0
                })
                .ToList();
        }
    }
}
