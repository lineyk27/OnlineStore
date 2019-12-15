
namespace OnlineStore.Models.Database
{
    public class Comment
    {
        public int UserId { get; set; }
        public int ProductId{ get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public string Text { get; set; }
    }
}
