
namespace OnlineStore.Models.Database
{
    public class Comment
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public string Text { get; set; }
    }
}
