using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LinkShot.Models
{
    public enum Platform
    {
        LinkedIn,
        Handshake
    }

    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string AssetId { get; set; }
        public bool PostToLinkedIn { get; set; }
        public bool PostToHandshake { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public Post() { }
        public Post(int Id, string Content, string ImagePath, string AssetId, bool PostToLinkedIn, bool PostToHandshake) { }

        public Post Clone()
        {
            return new Post
            {
                Id = this.Id,
                Content = this.Content,
                ImagePath = this.ImagePath,
                PostToLinkedIn = this.PostToLinkedIn,
                PostToHandshake = this.PostToHandshake,
                Timestamp = this.Timestamp
            };
        }
    }
}
