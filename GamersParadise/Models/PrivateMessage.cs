namespace GamersParadise.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public bool IsRead { get; set; }

        public int RecipientId { get; set; }
        public int SenderId { get; set; }
    }
}
