using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShot
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
        public bool PostToLinkedIn { get; set; }
        public bool PostToHandshake { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
