using Newtonsoft.Json;
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

        public List<string> UsersLike { get; set; }
        public string JsonUsersLike
        {
            get { return UsersLike == null ? "" : JsonConvert.SerializeObject(UsersLike); }
            set
            {
                if (value == null)
                {
                    UsersLike = new List<string>();
                }
                else
                {
                    UsersLike = JsonConvert.DeserializeObject<List<string>>(value);
                }
            }
        }

        public string Html { get; set; }
        public string Lang { get; set; }
        public DateTime DateTimePublish { get; set; }
        public DateTime DateTimeLasteChange { get; set; }
    }

    public class Comment
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<string> UsersLike { get; set; }
        public string JsonUsersLike
        {
            get { return UsersLike == null ? "" : JsonConvert.SerializeObject(UsersLike); }
            set
            {
                if (value == null)
                {
                    UsersLike = new List<string>();
                }
                else
                {
                    UsersLike = JsonConvert.DeserializeObject<List<string>>(value);
                }
            }
        }

        public string Html { get; set; }
        public DateTime DateTimePublish { get; set; }
        public DateTime DateTimeLasteChange { get; set; }
    }
}
