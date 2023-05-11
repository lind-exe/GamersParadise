namespace GamersParadise.Models
{
    public class UserThread
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public string? ImageURL { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
