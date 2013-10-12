namespace SpessartiteTwitter.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public Tweet Tweet { get; set; }
    }
}