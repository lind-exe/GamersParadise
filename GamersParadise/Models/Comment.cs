namespace GamersParadise.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
