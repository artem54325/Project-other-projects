using System;
using System.Collections.Generic;

namespace ProjectAboutProjects.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<Comment> Comments { get; set; }
        public string ShortDescription { get; set; }

        public int Views { get; set; }
        public int Likes { get; set; }

        public string Html { get; set; }
        public DateTime DateTimePublish { get; set; }
        public DateTime DateTimeLasteChange { get; set; }
    }

    public class Comment
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int Likes { get; set; }

        public string Html { get; set; }
        public DateTime DateTimePublish { get; set; }
        public DateTime DateTimeLasteChange { get; set; }
    }
}
