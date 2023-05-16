using System.Text.Json.Serialization;

namespace GamersParadise.Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("authorId")]
        public string UserId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
