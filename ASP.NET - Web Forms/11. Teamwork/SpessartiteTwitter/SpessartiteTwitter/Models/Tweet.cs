namespace SpessartiteTwitter.Models
{
    using System.Collections.Generic;

    public class Tweet
    {
        public Tweet()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int ID { get; set; }

        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}